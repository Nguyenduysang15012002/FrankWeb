using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Frank.Web.Modules
{
    public class WebModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(Assembly.Load("Frank.Web"))

                      .Where(t => t.Name.EndsWith("Provider"))

                      .AsImplementedInterfaces()

                      .InstancePerLifetimeScope();



        }

    }
}