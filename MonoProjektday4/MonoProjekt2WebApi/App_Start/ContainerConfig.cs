using Autofac;
using Autofac.Integration.WebApi;
using MonoProjekt2.Repository;
using MonoProjekt2.Repository.Common;
using MonoProjekt2.Servis;
using MonoProjekt2.Servis.Common;
using MonoProjekt2WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace MonoProjekt2WebApi.App_Start
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<CourseService>().As<ICourseService>();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }
    }
}