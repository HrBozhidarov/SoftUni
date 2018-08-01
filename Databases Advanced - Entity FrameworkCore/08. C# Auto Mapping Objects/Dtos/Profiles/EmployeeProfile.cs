using AutoMapper;
using AutoMappingObjectsExercice.Models;
using System.Collections.Generic;

namespace AutoMappingObjectsExercice.Dtos.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeFullInfoDto>().ReverseMap();
            CreateMap<Employee, ManagerDto>().ReverseMap();
            CreateMap<Employee, EmployeManagerDto>()
                .ForMember(dto => dto.FirstName,
                    opt => opt.MapFrom(src =>
                          src.FirstName))
                .ForMember(dto => dto.LastName,
                    opt => opt.MapFrom(src =>
                          src.LastName));
        }
    }
}
