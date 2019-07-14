using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class City : ICity
    {
        public City()
        {
            this.Citizens = new List<ICitizen>();
            this.FakeCitizens = new List<ICitizen>();
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
    }
}
