using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.BirthdayCelebrations
{
    public class City : ICity
    {
        public City()
        {
            this.Citizens = new List<ICitizen>();
            this.FakeCitizens = new List<ICitizen>();
            this.LiveCitizens = new List<ILiveCitizen>();
        }

        public ICollection<ILiveCitizen> LiveCitizens
        {
            get;
            private set;
        }

        public ICollection<ICitizen> Citizens
        {
            get;
            private set;
        }

        public ICollection<ICitizen> FakeCitizens
        {
            get;
            private set;
        }

        public void AddCitizen(ICitizen citizen)
        {
            this.Citizens.Add(citizen);
        }

        public void DentaineCitizens(string id)
        {
            var citizens = new List<ICitizen>();

            foreach (var citizen in this.Citizens)
            {
                if (!citizen.Id.EndsWith(id))
                {
                    citizens.Add(citizen);
                }
                else
                {
                    this.FakeCitizens.Add(citizen);
                }
            }

            this.Citizens = citizens;
        }

        public void PrintAllFakeCitizens()
        {
            foreach (var fakeCitizen in this.FakeCitizens)
            {
                Console.WriteLine(fakeCitizen.Id);
            }
        }

        public void AddLiveCitizents(ILiveCitizen liveCitizen)
        {
            this.LiveCitizens.Add(liveCitizen);
        }

        public void PrintAllBirthdaysWhichConincides(string birthday)
        {
            var liveCitizents = this.LiveCitizens.Where(x => x.BirthDay.EndsWith(birthday)).ToList();

            if (string.IsNullOrEmpty(birthday) || liveCitizents.Count == 0)
            {
                Console.WriteLine();
            }
            else
            {
                foreach (var liveCitizen in liveCitizents)
                {
                    Console.WriteLine(liveCitizen.BirthDay);
                }
            }
        }
    }
}
