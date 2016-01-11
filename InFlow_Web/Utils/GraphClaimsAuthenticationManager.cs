using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using strICT.InFlow.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace strICT.InFlow.Web.Helpers
{

    public class GraphClaimsAuthenticationManager : ClaimsAuthenticationManager
    {
        private static bool ad = Boolean.Parse(ConfigurationManager.AppSettings["AzureAD"]);
        private const string TenantIdClaimType = "http://schemas.microsoft.com/identity/claims/tenantid";
        private const string LoginUrl = "https://login.windows.net/{0}";
        private const string GraphUrl = "https://graph.windows.net";
        private const string GroupMemberUrl = "https://graph.windows.net/{0}/users/{1}/memberOf?api-version=2013-04-05";
        private static readonly string AppPrincipalId = ConfigurationManager.AppSettings["ida:ClientID"];
        private static readonly string AppKey = ConfigurationManager.AppSettings["ida:Password"];

        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
         {

             if (incomingPrincipal != null &&

                   incomingPrincipal.Identity.IsAuthenticated == true)
             {

                 string tenantId = incomingPrincipal.FindFirst(TenantIdClaimType).Value;

                 // Get a token for calling the Windows Azure Active Directory Graph
                 AuthenticationContext authContext = new AuthenticationContext(String.Format(CultureInfo.InvariantCulture, LoginUrl, tenantId));
                 ClientCredential credential = new ClientCredential(AppPrincipalId, AppKey);
                 AuthenticationResult assertionCredential = authContext.AcquireToken(GraphUrl, credential);
                 string authHeader = assertionCredential.CreateAuthorizationHeader();
                 string requestUrl = String.Format(
                     CultureInfo.InvariantCulture,
                       GroupMemberUrl,
                     HttpUtility.UrlEncode(tenantId),
                     HttpUtility.UrlEncode(incomingPrincipal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value));

                 HttpClient client = new HttpClient();
                 HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                 request.Headers.TryAddWithoutValidation("Authorization", authHeader);

                 var taskresponse = client.SendAsync(request);

                 var wat = taskresponse.Result;

                 HttpResponseMessage response = wat;

                 var response2 = response.Content.ReadAsStringAsync();

                 string responseString = response2.Result;

                 List<ADGroup> objects = JsonConvert.DeserializeObject<dynamic>(responseString)["value"].ToObject<List<ADGroup>>();

                 var groups = from g in objects where g.objectType.Equals("Group") select g.displayName;


                 foreach (string s in groups)

                     ((ClaimsIdentity)incomingPrincipal.Identity).AddClaim(

                              new Claim(ClaimTypes.Role, s, ClaimValueTypes.String, "GRAPH"));



             }

            return incomingPrincipal;

      
     
          
    }
    }
}