using Autofac;
using MonoProjekt2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace MonoProjekt2.Repositiry
{
     public class RepositoryDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>();
        }
    }
}
