using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InFlow_Outlook2013
{
    public static class Auth
    {
        private static bool authenticated;
        public static CredentialsDialog dialog;
        public static HttpClient httpClient;
        public static bool getAuthenticated()
        {
            if (!authenticated)
            {
                Login(null);
            }
            return authenticated;
        }
        public static bool Login(string name)
        {
            
            bool value = false;
            try
            {
                dialog = new CredentialsDialog("InFlow Outlook Add-In");
                //dialog.Persist = true;
               
                if (name != null) dialog.AlwaysDisplay = true; // prevent an infinite loop
                if (dialog.Show(name) == DialogResult.OK)
                {
                    if (Authenticate(dialog.Name, dialog.Password))
                    {
                        value = true;
                        if (dialog.SaveChecked) dialog.Confirm(true);
                    }
                    else
                    {
                        try
                        {
                            dialog.Confirm(false);
                        }
                        catch (ApplicationException applicationException)
                        {
                            // exception handling ...
                        }
                        value = Login(dialog.Name); // need to find a way to display 'Logon unsuccessful'
                    }
                }
            }
            catch (ApplicationException applicationException)
            {
                // exception handling ...
            }
            return value;
        }

        private static bool Authenticate(string username, string password)
        {
           string baseaddress = Properties.Settings.Default.baseaddress;

            httpClient = new HttpClient();
            //get RequestVerificationToken
            var response = httpClient.GetStringAsync(baseaddress + "/Account/Login");

            string token = "";
            string input = response.Result;
            string pattern = "<input name=\"__RequestVerificationToken\" type=\"hidden\" value=\".*\" \\/>";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);

            MatchCollection matches = rgx.Matches(input);
            if (matches.Count > 0)
            {
                token = matches[0].Value;
                token = token.Replace("<input name=\"__RequestVerificationToken\" type=\"hidden\" value=\"", "");
                token = token.Replace("\" />", "");

            }

            if (token.Length == 0)
            {
                throw new Exception("Login Page (" + baseaddress + "/Account/Login) Not Found!");
            }

            var content = new FormUrlEncodedContent(new[] 
                    {
                        new KeyValuePair<string, string>("UserName", username),
                        new KeyValuePair<string, string>("Password", password),
                        new KeyValuePair<string, string>("__RequestVerificationToken", token),
                        new KeyValuePair<string,string>("RememberMe","false"),
                        new KeyValuePair<string,string>("ClientType","OutlookWebservice")  
                    });

            var logoutToken = "";
            var response2 = httpClient.PostAsync(baseaddress + "/Account/Login", content).Result;

            input = response2.Content.ReadAsStringAsync().Result;
            pattern = "id=\"logoutForm\" method=\"post\"><input name=\"__RequestVerificationToken\" type=\"hidden\" value=\".*\" \\/>";
            rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            matches = rgx.Matches(input);
            if (matches.Count > 0)
            {
             //   logoutToken = matches[0].Value;
             //   logoutToken = logoutToken.Replace("id=\"logoutForm\" method=\"post\"><input name=\"__RequestVerificationToken\" type=\"hidden\" value=\"", "");
              //  logoutToken = logoutToken.Replace("\" />", "");
                authenticated = true;
                return true;
            }
            if (logoutToken.Length == 0)
            {
                authenticated = false;
                return false;
            }
            authenticated = false;
            return false;
        }
    }
}
