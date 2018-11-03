using MishMash.App.Models;
using MishMash.App.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System.Collections.Generic;
using System.Linq;

namespace MishMash.App.Controllers
{
    public class ChannelsController : BaseController
    {
        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return View();
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(ChannelInputModel model)
        {
            var tags = model.Tags.Split(", ");

            var channel = new Channel
            {
                Description = model.Description,
                Name = model.Name,
                Type = (Type)model.ChannelType
            };

            this.db.Channels.Add(channel);

            this.db.SaveChanges();

            var channelTags = new List<ChannelTag>();

            foreach (var tagName in tags)
            {
                Tag tag = this.db.Tags.FirstOrDefault(x => x.Name == tagName);

                if (tag == null)
                {
                    tag = new Tag { Name = tagName };
                    this.db.Tags.Add(tag);
                    this.db.SaveChanges();
                }

                channelTags.Add(new ChannelTag
                {
                    Tag = tag,
                    Channel = channel
                });
            }

            this.db.ChannelTags.AddRange(channelTags);

            this.db.SaveChanges();

            return Redirect("/");
        }

        public IHttpResponse Details(int id)
        {
            var model = this.db.Channels.Where(x => x.Id == id).Select(x => new ChannelModel
            {
                Description = x.Description,
                Name = x.Name,
                ChannelType = x.Type.ToString(),
                FollewrsCoun = x.Followers.Count,
                Tags = string.Join(", ", x.ChannelTags.Select(w => w.Tag.Name))
            }).FirstOrDefault();

            return View(model);
        }

        public IHttpResponse Following(int id)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == User.Username);
            var channel = this.db.Channels.Find(id);

            user.Channels.Add(new UserChannel
            {
                ChannelId = channel.Id
            });

            this.db.SaveChanges();

            return Redirect("/");
        }

        public IHttpResponse Followed()
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == User.Username);

            var model = this.db.UsersChannels.Where(x => x.UserId == user.Id)
                .Select(x => new ChannelModel
                {
                    ChannelType = x.Channel.Type.ToString(),
                    FollewrsCoun = x.Channel.Followers.Count,
                    Name = x.Channel.Name,
                    Id = x.Channel.Id
                }).ToArray();


            return View(model);
        }

        public IHttpResponse Unfollow(int id)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == User.Username);

            var channel = this.db.UsersChannels.FirstOrDefault(x => x.ChannelId == id && x.UserId == user.Id);

            this.db.UsersChannels.Remove(channel);

            this.db.SaveChanges();

            return Redirect("/");
        }
    }
}
