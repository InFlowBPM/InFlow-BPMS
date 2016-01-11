using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace InFlow_Outlook2013
{
   public class ServiceHelper
    {
       private string baddr = Properties.Settings.Default.baseaddress;
       public bool btnDisplay = true;
        public async Task<List<StartProcessItemViewModel>> getProcessesToStart()
        {
            if (Auth.getAuthenticated()) { 
            string url = baddr + "/TaskServiceAPI/StartProcesses";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

           
             
          //  request.Headers.Add("Content-Type","application/json"); 
            HttpResponseMessage response = await Auth.httpClient.SendAsync(request);
            return JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync()).ToObject<List<StartProcessItemViewModel>>();
            }
            else
            {
                return null;
            }


        }
        public string getTaskContent(int taskid)
        {
            var str = Auth.httpClient.GetAsync(Properties.Settings.Default.baseaddress + "/Jobs/Mobile/" + taskid + "?btn=0").Result.Content.ReadAsStringAsync().Result.Replace("=\"/", "=\""+Properties.Settings.Default.baseaddress);
            if (!str.Contains("DONE") && !str.Contains("Process ended"))
            {
                btnDisplay = true;
            return str;
            }
            else
            {
             
                var done = Regex.Replace(str, @"<table.*>[\S\s]*<\/table>", "<p>Task already completed.</p>");
                btnDisplay = false;
                return done;
             
            }
        }
        public async Task<bool> startProcess(string id)
        {
            string url = baddr+"/TaskServiceAPI/StartProcess/"+id;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage response = await Auth.httpClient.SendAsync(request);
            return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        }

        public async Task<HttpResponseMessage> sendTask(SendTaskViewModel stm, string id)
        {
            string url = baddr + "/TaskServiceAPI/SendTask/" + id;
            return await HttpMagic(new StringContent(JsonConvert.SerializeObject(stm), System.Text.Encoding.UTF8, "application/json"), url);

    
        }
      
        public async Task<HttpResponseMessage> receiveTask(ReceiveTaskViewModel stm, string id)
        {
            string url = baddr + "/TaskServiceAPI/ReceiveTask/" + id;
            return await HttpMagic(new StringContent(JsonConvert.SerializeObject(stm), System.Text.Encoding.UTF8, "application/json"), url);


        }
        public async Task<HttpResponseMessage> functionTask(FunctionTaskViewModel stm, string id)
        {
            string url = baddr + "/TaskServiceAPI/FunctionTask/" + id;
            return await HttpMagic(new StringContent(JsonConvert.SerializeObject(stm), System.Text.Encoding.UTF8, "application/json"), url);

        }
        private async Task<HttpResponseMessage> HttpMagic(StringContent sc, string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            HttpResponseMessage response = await Auth.httpClient.PostAsync(url, sc);
            return response;
        }
        public async Task<string> taskType(string id)
        {
            string url = baddr + "/TaskServiceAPI/TaskType/" + id;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            //  request.Headers.Add("Content-Type", "application/json");
            HttpResponseMessage response = await Auth.httpClient.SendAsync(request);
            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }
        public class StartProcessItemViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int Version { get; set; }

            public string Description { get; set; }
        }



        public class FunctionTaskViewModel 
        {



            public List<TaskParameter> EditableParameters { get; set; }

            public string selectedTransiton { get; set; }


            public FunctionTaskViewModel()
            {

                EditableParameters = new List<TaskParameter>();
            }
        }

        public class ReceiveTaskViewModel 
        {




            public string[] selectedMessages { get; set; }

            public ReceiveTaskViewModel()
            {
            }

        }
        public class SendTaskViewModel
        {

            public SendTaskViewModel()
            {
                EditableParameters = new List<TaskParameter>();

            }

            public List<TaskParameter> EditableParameters { get; set; }


            public string selectedRecipient { get; set; }
        }
        public class TaskParameter
        {
            
            public string Name { get; set; }

            
            public string Value { get; set; }
        }

        public class SelectListItem
        {
            public SelectListItem() { }

      
     
            public string Text { get; set; }
          
            public string Value { get; set; }
        }

    }
}
