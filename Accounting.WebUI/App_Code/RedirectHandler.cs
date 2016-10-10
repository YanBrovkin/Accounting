using System.Configuration;
using System.Web;

namespace Accounting.WebUI.App_Code
{
    public class RedirectHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var Request = context.Request;
            var Response = context.Response;

            if (Request.Url.LocalPath != "/")
                return;

            Response.Redirect(ConfigurationSettings.AppSettings["applicationRoot"], true);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}