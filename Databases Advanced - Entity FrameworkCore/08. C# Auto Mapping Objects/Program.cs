using AutoMapper;
using AutoMappingObjectsExercice.App;
using AutoMappingObjectsExercice.Dtos.Profiles;

namespace AutoMappingObjectsExercice
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<EmployeeProfile>());

            var engine = new Engine();

            engine.Run();
        }
    }
}
