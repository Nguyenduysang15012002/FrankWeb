using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Autofac.Integration.Mvc;
using Frank.Web.Modules;
using Frank.Web.Core;
using Frank.Service.ProductService;




namespace Frank.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(double), new DoubleModelBinder());
            ModelBinders.Binders.Add(typeof(double?), new DoubleModelBinder());

            //ModelBinders.Binders.Add(typeof(long?), new LongModelBinder());
            //ModelBinders.Binders.Add(typeof(long), new LongModelBinder());
            ModelBinders.Binders.Add(typeof(string[]), new InArrayModelBinder());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new Autofac.ContainerBuilder();          
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());
            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterModule(new WebModule());

           
            //builder.RegisterModule(new RedisModule());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
            var pathConfig = Server.MapPath("~/App_Data/ConfigStatus.json");
            StatusProvider.loadData(pathConfig);
        }
    }
}
