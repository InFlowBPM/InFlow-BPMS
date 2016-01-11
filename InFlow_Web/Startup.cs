using Microsoft.Owin;
using Owin;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(strICT.InFlow.Web.Startup))]
namespace strICT.InFlow.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            string ad = ConfigurationManager.AppSettings["AzureAD"];
            if (!ad.Equals("true"))
            {
                ConfigureAuth(app);
            }
        }
    }
}
