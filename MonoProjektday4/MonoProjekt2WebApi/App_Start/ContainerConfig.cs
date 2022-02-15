using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MonoProjekt2.Repositiry;
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

            builder.RegisterModule(new RepositoryDIModule());
            builder.RegisterModule(new ServiceDIModule());

            //builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

               


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }
    }
}