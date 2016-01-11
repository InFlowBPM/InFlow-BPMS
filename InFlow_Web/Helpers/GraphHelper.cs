using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using strICT.InFlow.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;


namespace strICT.InFlow.Web.Helpers
{
    public class GraphHelper
    {
        private const string TenantIdClaimType = "http://schemas.microsoft.com/identity/claims/tenantid";
        private const string LoginUrl = "https://login.windows.net/{0}";
        private const string GraphUrl = "https://graph.windows.net";
        private const string GraphUserUrl = "https://graph.windows.net/{0}/users/{1}?api-version=2013-04-05";
        private const string GraphUsersUrl = "https://graph.windows.net/{0}/users/?api-version=2013-04-05";
        private const string GroupMemberUrl = "https://graph.windows.net/{0}/users/{1}/memberOf?api-version=2013-04-05";
        private const string GroupAddUrl = "https://graph.windows.net/{0}/groups/{1}/$links/members?api-version=2013-04-05";
        private const string GroupRemoveUrl = "https://graph.windows.net/{0}/groups/{1}/$links/members/{2}?api-version=2013-04-05";

        
        private const string DirectoryObjectsUrl = "https://graph.windows.net/{0}/directoryObjects/{1}?api-version=2013-04-05";

        private const string GroupUrl = "https://graph.windows.net/{0}/groups/?api-version=2013-04-05";

        private static readonly string AppPrincipalId = ConfigurationManager.AppSettings["ida:ClientID"];
        private static readonly string AppKey = ConfigurationManager.AppSettings["ida:Password"];
        public string tenantId;
       
        public GraphHelper()
        {
            try { 
            tenantId = ClaimsPrincipal.Current.FindFirst(TenantIdClaimType).Value;
            }
            catch
            {
                //local auth is used.
            }
            }
        public GraphHelper(string tId)
        {
            this.tenantId = tId;
        }
        public async Task<User> getUser(string identity)
        {
             string requestUrl = String.Format(
                CultureInfo.InvariantCulture,
                  GraphUserUrl,
                HttpUtility.UrlEncode(tenantId),
                HttpUtility.UrlEncode(identity));
             return JsonConvert.DeserializeObject<User>(await query(requestUrl));
        }
        public async Task<IEnumerable<User>> getUsers()
        {
            string requestUrl = String.Format(
                CultureInfo.InvariantCulture,
                  GraphUsersUrl,
                HttpUtility.UrlEncode(tenantId));
            var allUsers = JsonConvert.DeserializeObject<dynamic>(await query(requestUrl))["value"].ToObject<List<User>>();
            List<User> uList = allUsers;
            return (from u in uList where !u.userPrincipalName.Contains("#") select u);
        }
        public async Task<IEnumerable<string>> getGroups()
        {
            var objects = await getGroupsList();
        
            return (from g in objects where g.objectType.Equals("Group") select g.displayName);
        }
        public async Task<List<ADGroup>> getGroupsList()
        {
            string requestUrl = String.Format(
                CultureInfo.InvariantCulture,
                  GroupUrl,
                HttpUtility.UrlEncode(tenantId));

            return JsonConvert.DeserializeObject<dynamic>(await query(requestUrl))["value"].ToObject<List<ADGroup>>();
        }


        public async Task<List<ADGroup>> getGroupsForUser(User u)
        {
            string requestUrl = String.Format(
                       CultureInfo.InvariantCulture,
                         GroupMemberUrl,
                       HttpUtility.UrlEncode(tenantId),
                       HttpUtility.UrlEncode(u.userPrincipalName));

            return JsonConvert.DeserializeObject<dynamic>(await query(requestUrl))["value"].ToObject<List<ADGroup>>();
             
        }
        public async Task<ADGroup> getGroupByName(string groupName)
        {
            List<ADGroup> groups = await getGroupsList();

            return (from g in groups where g.displayName.Equals(groupName) select g).FirstOrDefault();
        }

        public async Task<string> removeUserFromGroup(string oid, string group)
        {
            string objectid = (await getGroupByName(group)).objectId;
            string requestUrl = String.Format(
                       CultureInfo.InvariantCulture,
                         GroupRemoveUrl,
                       HttpUtility.UrlEncode(tenantId),
                       HttpUtility.UrlEncode(objectid),HttpUtility.UrlEncode(oid));
            
          return await query(requestUrl,HttpMethod.Delete);
            
        }
        
        public async Task<string> addUserToGroup(string oid,string group)
        {
            string objectid = (await getGroupByName(group)).objectId;
            string requestUrl = String.Format(
                       CultureInfo.InvariantCulture,
                         GroupAddUrl,
                       HttpUtility.UrlEncode(tenantId),
                       HttpUtility.UrlEncode(objectid));
            JSONDObject jd = new JSONDObject();
            jd.url = String.Format(CultureInfo.InvariantCulture,
                DirectoryObjectsUrl,
                HttpUtility.UrlEncode(tenantId),
                HttpUtility.UrlEncode(oid));
            return await query(requestUrl,JsonConvert.SerializeObject(jd));
            
        }
        private string getAuthHeader()
        {
            AuthenticationContext authContext = new AuthenticationContext(String.Format(CultureInfo.InvariantCulture, LoginUrl, tenantId));
            ClientCredential credential = new ClientCredential(AppPrincipalId, AppKey);
            AuthenticationResult assertionCredential = authContext.AcquireToken(GraphUrl, credential);
           return assertionCredential.CreateAuthorizationHeader();

        }
        public async Task<string> query(string requestUrl, string content)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", getAuthHeader());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Host = new Uri(requestUrl).Host;
     
            StringContent sc = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await client.PostAsync(requestUrl,sc);
           
            return await response.Content.ReadAsStringAsync();
        }


        public async Task<string> query(string requestUrl, HttpMethod httpMethod = null)
        {
            if (httpMethod == null) { httpMethod = HttpMethod.Get; }
            
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(httpMethod, requestUrl);
            request.Headers.TryAddWithoutValidation("Authorization", getAuthHeader());
            HttpResponseMessage response = await client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
       
    }
}