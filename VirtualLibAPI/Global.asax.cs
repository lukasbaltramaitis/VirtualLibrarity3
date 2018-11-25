using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace VirtualLibAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IContainer container;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var builder = new ContainerBuilder();
            builder.RegisterType<PostHandler>().As<IPostHandler>().SingleInstance();
            builder.RegisterType<FileFaceReader>().As<IReader>().SingleInstance();
            builder.RegisterType<FileFaceWriter>().As<IWriter>().SingleInstance();
            builder.RegisterType<FacePlusRequest>().As<IRequest>();
            builder.RegisterType<APIRecognizer>().As<IRecognizer>().SingleInstance();
            container = builder.Build();


        }
    }
}
