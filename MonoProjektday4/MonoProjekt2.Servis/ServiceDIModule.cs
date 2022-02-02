using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using System.Text;
using System.Threading.Tasks;
using MonoProjekt2.Servis.Common;
using Module = Autofac.Module;

namespace MonoProjekt2.Servis
{
    public class ServiceDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<CourseService>().As<ICourseService>();
        }
    }
}
