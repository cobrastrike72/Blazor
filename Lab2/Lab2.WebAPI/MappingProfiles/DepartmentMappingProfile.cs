using AutoMapper;
using Lab2.WebAPI.DTOs.DepartmentDTOs;
using Lab2.WebAPI.Models;

namespace Lab2.WebAPI.MappingProfiles
{
    public class DepartmentMappingProfile:Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentDisplayDTO>().AfterMap((src, des) =>
            {
                if(src.DeptManagerNavigation != null) // when an auto mapper access something it will be converted from deffered state to an immediate state
                    des.ManagerName = src.DeptManagerNavigation.InsName;
                des.DepartmentCapcity = src.Students.Count(); // mapping to a property that doesn't exist with the actual model
            });

            CreateMap<DepartmentAddDTO, Department>();

            CreateMap<DepartmentEditDTO, Department>();
        }
    }
}
