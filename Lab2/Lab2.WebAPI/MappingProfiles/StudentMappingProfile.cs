using AutoMapper;
using Lab2.WebAPI.DTOs.StudentDTOs;
using Lab2.WebAPI.Models;

namespace Lab2.WebAPI.MappingProfiles
{
    public class StudentMappingProfile: Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, StudentDisplayDTO>()
                .AfterMap((src, des) =>
                {
                    if (src.StSuperNavigation != null)
                    {
                        des.SuperStudentName = $"{src.StSuperNavigation.StFname} {src.StSuperNavigation.StLname}";
                    }
                    if (src.Dept != null)
                    {
                        des.DepartmentName = src.Dept.DeptName;
                    }
                });
            CreateMap<StudentAddDTO, Student>().AfterMap((src, des) =>
            {
                des.StSuper = src.SuperStudentId;
            });

            CreateMap<StudentEditDTO, Student>().AfterMap((src, des) =>
            {
                des.StSuper = src.SuperStudentId;
            });
        }

    }
}
