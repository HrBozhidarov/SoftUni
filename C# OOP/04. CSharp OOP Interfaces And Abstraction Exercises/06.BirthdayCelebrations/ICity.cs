using System.Collections.Generic;

namespace _06.BirthdayCelebrations
{
    public interface ICity
    {
        ICollection<ICitizen> Citizens { get; }

        ICollection<ILiveCitizen> LiveCitizens { get; }

        ICollection<ICitizen> FakeCitizens { get; }

        void AddCitizen(ICitizen citizen);

        void DentaineCitizens(string id);

        void PrintAllFakeCitizens();

        void PrintAllBirthdaysWhichConincides(string birthday);
    }
}