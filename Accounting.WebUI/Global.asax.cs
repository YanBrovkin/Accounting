using Accounting.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Accounting.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            new AppHost(@"Accounting Host started", typeof(SKUService).Assembly).Init();
        }

        public override void Init()
        {
            base.Init();
            BeginRequest += OnBeginRequest;
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            var path = Request.Url.AbsolutePath;
            // http://stackoverflow.com/questions/1149750/using-asp-net-routing-to-serve-static-files
            //if(!path.StartsWith('api/'))
        }
    }
}
