using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System.Linq;
using System;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;

namespace PhotoShare.Services
{
    public class TownService : ITownService
    {
        private PhotoShareContext context;

        public TownService(PhotoShareContext context)
        {
            this.context = context;
        }

        public Town Add(string townName, string countryName)
        {
            var town = new Town
            {
                Name = townName,
                Country = countryName
            };

            context.Towns.Add(town);

            context.SaveChanges();

            return town;
        }

        public TModel ById<TModel>(int id) => By<TModel>(x => x.Id == id).SingleOrDefault();

        public TModel ByName<TModel>(string name) => By<TModel>(x => x.Name == name).SingleOrDefault();

        private IEnumerable<TModel> By<TModel>(Func<Town, bool> predicate) =>
                                      this.context.Towns
                                          .Where(predicate)
                                          .AsQueryable()
                                          .ProjectTo<TModel>();

        public bool Exists(int id) => ById<Town>(id) != null;

        public bool Exists(string name) => ByName<Town>(name) != null;
    }
}
