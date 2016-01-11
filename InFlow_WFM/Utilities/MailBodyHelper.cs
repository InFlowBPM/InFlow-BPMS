using strICT.InFlow.Db;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;


namespace strICT.InFlow.WFM.Utilities
{
    public class MailBodyHelper
    {

        private const string Email_NotificationTemplate = "Email_NotificationTemplate";


        private const string TaskURL = "Jobs/Index/{id}";

        private string baseURL = "";
        private string templatepath = "";

        private const String newLine = "<br/>";

        private T_Task task;

        public String getStateBody(T_Task task, string baseURL, string templatepath)
        {
            this.templatepath = templatepath;
            this.task = task;
            this.baseURL = baseURL;

            if (task.Type.Equals("F"))
            {
                return getFunctionStateBody();
            }

            if (task.Type.Equals("S"))
            {
                return getSendStateBody();
            }
            return null;
        }

        private string createURL(int id)
        {

            string url = TaskURL.Replace("{id}", "" + id);
            return baseURL + url;
        }


        private String getFunctionStateBody()
        {
            try
            {

                StreamReader reader = new StreamReader(templatepath);
                String body = reader.ReadToEnd();

                String tmp = "";

                tmp += "<h2>" + task.Name + "</h2>";
                tmp += "";
                tmp += "<h3>Details</h3>";
                /*
                tmp += "<b>Parameter</b>";
                tmp += "<table>";

                if (!String.IsNullOrEmpty(task.ReadableParameters))
                {
                    var readableparameters = Json.Decode<Dictionary<string, string>>(task.ReadableParameters);
                    foreach (var i in readableparameters)
                    {
                        tmp += "<tr><td>" + i.Key + "</td><td>" + i.Value + "</td><tr/>";
                    }
                }

                if (!String.IsNullOrEmpty(task.EditableParameters))
                {
                    var editableparameters = Json.Decode<Dictionary<string, string>>(task.EditableParameters);
                    foreach (KeyValuePair<string, string> i in editableparameters)
                    {
                        tmp += "<tr><td>" + i.Key + "</td><td>" + i.Value + "</td><tr/>";
                    }
                }
                tmp += "</table>";
                */
                tmp += "<b>Transitions</b>";
                tmp += "<table>";
                foreach (var i in task.TaskProperties)
                {
                    tmp += "<tr><td>" + i.Value + "</td><tr/>";
                }
                tmp += "</table>";

                body = body.Replace("#CONTENT#", tmp);

                string Link = createURL(task.Id);
                body = body.Replace("#LINK#", Link);

                return body;
            }
            catch (Exception e)
            {
                String body = "#F" + newLine;
                body += "id=" + task.Id.ToString() + newLine;
               
                body += "#transitions" + newLine;
                foreach (var i in task.TaskProperties)
                {
                    body += i.Value + newLine;
                }
                body += "#end";

                return body;
            }
        }

        private String getSendStateBody()
        {
            try
            {
                StreamReader reader = new StreamReader(templatepath);
                String body = reader.ReadToEnd();

                String tmp = "";

                tmp += "<h2>" + task.Name + "</h2>";
                tmp += "Platzhalter Prozessinfo";
                tmp += "<h3>Details</h3>";
                /*
                tmp += "<b>Parameter</b>";
                tmp += "<table>";

                if (!String.IsNullOrEmpty(task.ReadableParameters))
                {
                    var readableparameters = Json.Decode<Dictionary<string, string>>(task.ReadableParameters);
                    foreach (var i in readableparameters)
                    {
                        tmp += "<tr><td>" + i.Key + "</td><td>" + i.Value + "</td><tr/>";
                    }
                }

                if (!String.IsNullOrEmpty(task.EditableParameters))
                {
                    var editableparameters = Json.Decode<Dictionary<string, string>>(task.EditableParameters);
                    foreach (KeyValuePair<string, string> i in editableparameters)
                    {
                        tmp += "<tr><td>" + i.Key + "</td><td>" + i.Value + "</td><tr/>";
                    }
                }
                tmp += "</table>";
                */
                tmp += "<b>Recipients</b>";
                tmp += "<table>";
                foreach (var i in task.TaskProperties)
                {
                    tmp += "<tr><td>" + i.Value + "</td><tr/>";
                }
                tmp += "</table>";

                body = body.Replace("#CONTENT#", tmp);


                string Link = createURL(task.Id);
                body = body.Replace("#LINK#", Link);

                return body;
            }
            catch (Exception e)
            {
                String body = "#S" + newLine;
                body += "id=" + task.Id.ToString() + newLine;
                /*
                body += "#readable" + newLine;

                if (!String.IsNullOrEmpty(task.ReadableParameters))
                {
                    var readableparameters = Json.Decode<Dictionary<string, string>>(task.ReadableParameters);
                    foreach (KeyValuePair<string, string> i in readableparameters)
                    {
                        body += i.Key + "=" + i.Value + newLine;
                    }
                }
                body += "#editable" + newLine;
                if (!String.IsNullOrEmpty(task.EditableParameters))
                {
                    var editableparameters = Json.Decode<Dictionary<string, string>>(task.EditableParameters);
                    foreach (KeyValuePair<string, string> i in editableparameters)
                    {
                        body += i.Key + "=" + i.Value + newLine;
                    }
                }
                 */
                body += "#recipients" + newLine;
                foreach (var i in task.TaskProperties)
                {
                    body += i.Value + newLine;
                }
                body += "#end";

                return body;
            }
        }


        public String getReceiveStateBody(M_Message message, T_Task task, string baseURL, string templatepath)
        {
            this.templatepath = templatepath;
            this.baseURL = baseURL;
            try
            {

                StreamReader reader = new StreamReader(templatepath);
                String body = reader.ReadToEnd();

                String tmp = "";

                tmp += "<h3>" + task.Name + "</h3>";
                tmp += "<h2>" + message.Message_Type + " from " + message.Sender_Username + "</h2>";
                tmp += "Platzhalter Prozessinfo";


                body = body.Replace("#CONTENT#", tmp);


                string Link = createURL(task.Id);
                body = body.Replace("#LINK#", Link);

                return body;
            }
            catch (Exception e)
            {
                String body = message.Message_Type;

                return body;
            }
        }


    }
}
