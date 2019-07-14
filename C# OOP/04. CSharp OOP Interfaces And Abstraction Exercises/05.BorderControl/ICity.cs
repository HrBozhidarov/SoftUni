using System.Collections.Generic;

namespace _05.BorderControl
{
    public interface ICity
    {
        ICollection<ICitizen> Citizens { get; }

        ICollection<ICitizen> FakeCitizens { get; }

        void AddCitizen(ICitizen citizen);

        void DentaineCitizens(string id);

        void PrintAllFakeCitizens();
    }
}