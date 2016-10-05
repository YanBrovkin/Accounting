using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Funq;
using ServiceStack;
using ServiceStack.Configuration;
using ServiceStack.FluentValidation;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using System.Web.Mvc;
using ServiceStack.Text;
using System.Globalization;
using Ninject;
using Accounting.Data;
using System.Configuration;
using Accounting.Contracts;
using Ninject.Modules;

namespace Accounting.WebUI
{
    public class AppHost : AppHostBase
    {
        //public static AppConfig AppConfig;

        public AppHost(string serviceName, params Assembly[] assembliesWithServices) 
            : base(serviceName, assembliesWithServices)
        {
        }

        public override void Configure(Container container)
        {
            JsConfig.EmitCamelCaseNames = true;
            JsConfig.ExcludeTypeInfo = true;
            //JsConfig.DateHandler = DateHandler.ISO8601;
            JsConfig<long>.SerializeFn = c => c.ToString();
            JsConfig<DateTime>.DeSerializeFn = time =>
            {
                var result = DateTime.ParseExact(time.Substring(0, 23), "yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture);
                //ServiceStack.Text.Common.DateTimeSerializer.ParseDateTime(time);
                return result;
            };

            var modules = new List<NinjectModule>
            {
                new OrmLiteModule(ConfigurationManager.ConnectionStrings["AccountingDb"].ConnectionString,
                    (Language)Enum.Parse(typeof(Language), ConfigurationManager.AppSettings["Locale"]))
            };

            var kernel = new StandardKernel(modules.ToArray());

            this.Container.Adapter = new NinjectIocAdapter(kernel);
            //Set MVC to use the same Funq IOC as ServiceStack
            //ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
        }
    }
}