using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Models.Enums;
using PhotoShare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoShare.Services
{
    public class AlbumService : IAlbumService
    {
        private PhotoShareContext context;

        public AlbumService(PhotoShareContext context)
        {
            this.context = context;
        }

        public TModel ById<TModel>(int id) => By<TModel>(u => u.Id == id).SingleOrDefault();

        public TModel ByName<TModel>(string name) => By<TModel>(u => u.Name == name).SingleOrDefault();

        private IEnumerable<TModel> By<TModel>(Func<Album, bool> predicate) =>
                                        this.context.Albums
                                            .Include(x=>x.AlbumRoles)
                                            .Where(predicate)
                                            .AsQueryable()
                                            .ProjectTo<TModel>();

        public Album Create(int userId, string albumTitle, Color BgColor, params string[] tags)
        {
            var album = new Album
            {
                BackgroundColor = BgColor,
                Name = albumTitle
            };

            var albumRole = new AlbumRole
            {
                UserId = userId,
                Album = album
            };

            this.context.AlbumRoles.Add(albumRole);
            this.context.SaveChanges();

            foreach (var tag in tags)
            {
                var currentTag = this.context.Tags.SingleOrDefault(x => x.Name == tag);

                var albumTag = new AlbumTag
                {
                    Tag = currentTag,
                    Album = album
                };

                this.context.Add(albumTag);
            }

            this.context.SaveChanges();

            return album;
        }

        public bool Exists(int id) => ById<Album>(id) != null;

        public bool Exists(string name) => ByName<Album>(name) != null;

        public string ShareAlbum(int albumId, int userId, Role role)
        {
            context.AlbumRoles.Add(new AlbumRole
            {
                AlbumId = albumId,
                UserId = userId,
                Role = role
            });

            context.SaveChanges();

            var albumName = this.ById<Album>(albumId).Name;

            return albumName;
        }
    }
}
