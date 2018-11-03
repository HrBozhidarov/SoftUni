using Microsoft.EntityFrameworkCore;
using MishMash.App.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MishMash.App.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (User.IsLoggedIn)
            {
                var user = this.db.Users.FirstOrDefault(x => x.Username == User.Username);

                var channels = new CollectionChannelModel();

                var yourChannels = this.db.Channels.Where(x => x.Followers.Any(w => w.User.Username == this.User.Username))
                    .Select(x => new ChannelModel
                    {
                        Name = x.Name,
                        ChannelType = x.Type.ToString(),
                        FollewrsCoun = x.Followers.Count()
                    }).ToArray();

                var followedChannelsTags = this.db.Channels
                    .Where(x => x.Followers.Any(f => f.User.Username == User.Username)).SelectMany(x => x.ChannelTags.Select(t => t.Tag.Id)).ToArray();

                var suggestedChannels = this.db.Channels.Where(x => !x.Followers.Any(w => w.UserId == user.Id)
                        && x.ChannelTags.Any(w => followedChannelsTags.Contains(w.TagId)))
                        .Select(x => new ChannelModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            ChannelType = x.Type.ToString(),
                            FollewrsCoun = x.Followers.Count()
                        }).ToArray();

                var seeOtherChannels = this.db.Channels.Where(x => !x.Followers.Any(w => w.UserId == user.Id)
                        && !x.ChannelTags.Any(w => followedChannelsTags.Contains(w.TagId)))
                        .Select(x => new ChannelModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            ChannelType = x.Type.ToString(),
                            FollewrsCoun = x.Followers.Count()
                        }).ToArray();

                channels.YourChannels = yourChannels;
                channels.SuggestedChannels = suggestedChannels;
                channels.SeeOtherChannels = seeOtherChannels;

                return View("/home/loggedInIndex", channels);
            }
            else
            {
                return View();
            }

        }
    }
}
