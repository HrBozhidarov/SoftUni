using AutoMapper;
using Chushka.Models;

namespace Chushka.Common
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User>
        }
    }
}
