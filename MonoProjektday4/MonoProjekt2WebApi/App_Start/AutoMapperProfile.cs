using AutoMapper;
using MonoProjekt2WebApi.Models;
using MonoProjekt2WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoProjekt2WebApi.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Course,CourseViewModel>().ForMember(p=>p.NumberOfStudent, s=>s.Ignore());
            CreateMap<CourseViewModel, Course>();
        }
    }
}