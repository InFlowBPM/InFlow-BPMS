using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using InFlow_Web;
using System.Web.Helpers;
using System.IdentityModel.Claims;
using System.Web.Hosting;
using strICT.InFlow.Web.Extensions;
using System.Globalization;
using System.Data.Entity;
namespace strICT.InFlow.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string ad = ConfigurationManager.AppSettings["AzureAD"];

        protected void Application_Start()
        {
            //HostingEnvironment.RegisterVirtualPathProvider(new DbPathProvider());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            if (ad.Equals("true")) { 
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
            }
        }
   
        void WSFederationAuthenticationModule_RedirectingToIdentityProvider(object sender, RedirectingToIdentityProviderEventArgs e)
        {
            if (ad.Equals("true"))
            {
                if (!String.IsNullOrEmpty(IdentityConfig.Realm))
                {
                    e.SignInRequestMessage.Realm = IdentityConfig.Realm;
                }
            }
        }
    }
}
