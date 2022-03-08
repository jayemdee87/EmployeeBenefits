using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeBenefitsAPICore.Models;
using EmployeeBenefitsAPICore.Models.Dtos;

namespace EmployeeBenefitsAPICore.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Dependent, DependentDto>().ReverseMap();
        }
    }
}
