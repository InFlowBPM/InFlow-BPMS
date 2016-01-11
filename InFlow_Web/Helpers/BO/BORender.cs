using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace strICT.InFlow.Web.Helpers.BO
{
    public class BORender
    {

        private string regexLabel = "#label\\(.[^\\)]*\\)#";
        private string regexEditor = "#editor\\(.[^\\)]*\\)#";

        private string regexList = @"(#foreach\(.*\){[^}]*(({[^}]*}#)+\s*(,)?)+[^{]*}#)|#foreach\(.*\){[^}]*}#";

        public JObject jsonschema;

        public string createHTML(string jsonData, string jsonSchema, string htmlBOTemplate)
        {
            jsonschema = JObject.Parse(jsonSchema);
            JObject data = JObject.Parse(jsonData);

            return parse(htmlBOTemplate, data, "", false, "");
        }

        private string parse(string originalhtml, JObject data, string rootpath, bool isList, string listitemname)
        {

            int idcounter = -1;

            List<DataList> datalist = new List<DataList>();

            List<LabelList> labelList = new List<LabelList>();
            List<EditorList> editorList = new List<EditorList>();



            Regex rgx = new Regex(regexList, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(originalhtml);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    idcounter = idcounter + 1;
                    string path = parseListPath(match.ToString());
                    string pt;
                    if (isList)
                    {
                        if (path.Contains('.'))
                        {
                            pt = rootpath + path.Replace(listitemname, "");
                        }
                        else
                        {
                            pt = rootpath;
                        }
                    }
                    else
                    {
                        pt = rootpath + path;
                    }
                    DataList dl = new DataList() { id = idcounter, data = data.SelectToken(path).ToList(), htmloriginal = match.ToString(), origPath = pt, boRender = this };
                    datalist.Add(dl);


                    originalhtml = originalhtml.Replace(dl.htmloriginal, "#" + idcounter + "#");
                }
            }

            Regex rgxlabel = new Regex(regexLabel, RegexOptions.IgnoreCase);
            MatchCollection matcheslabel = rgxlabel.Matches(originalhtml);
            if (matcheslabel.Count > 0)
            {
                foreach (Match match in matcheslabel)
                {
                    idcounter = idcounter + 1;

                    string path = parsePath(match.ToString());
                    string pt;
                    if (isList)
                    {
                        if (path.Contains('.'))
                        {
                            pt = rootpath + path.Replace(listitemname, "");
                        }
                        else
                        {
                            pt = rootpath;
                        }
                    }
                    else
                    {
                        pt = rootpath + path;
                    }
                    LabelList item = new LabelList() { id = idcounter, Path = pt, boRender = this };
                    labelList.Add(item);

                    originalhtml = originalhtml.Replace(match.ToString(), "#" + idcounter + "#");
                }
            }

            Regex rgxEditor = new Regex(regexEditor, RegexOptions.IgnoreCase);
            MatchCollection matcheseditor = rgxEditor.Matches(originalhtml);
            if (matcheseditor.Count > 0)
            {
                foreach (Match match in matcheseditor)
                {
                    idcounter = idcounter + 1;

                    string path = parsePath(match.ToString());

                    string value = "NULL";

                    try
                    {
                        value = data.SelectToken(path).ToString();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    string pt;
                    if (isList)
                    {
                        if (path.Contains('.'))
                        {
                            pt = rootpath + path.Replace(listitemname, "");
                        }
                        else
                        {
                            pt = rootpath;
                        }
                    }
                    else
                    {
                        pt = rootpath + path;
                    }

                    EditorList item = new EditorList() { id = idcounter, Path = pt, Value = value, boRender = this };
                    editorList.Add(item);

                    originalhtml = originalhtml.Replace(match.ToString(), "#" + idcounter + "#");
                }
            }

            foreach (var i in labelList)
            {
                originalhtml = originalhtml.Replace("#" + i.id + "#", i.getHtml());
            }

            foreach (var i in editorList)
            {
                originalhtml = originalhtml.Replace("#" + i.id + "#", i.getHtml());
            }

            foreach (var i in datalist)
            {
                string html = "";
                int cnt = 0;
                foreach (var item in i.data)
                {
                    JObject mydata;
                    if (!item.GetType().Equals(new JObject()))
                    {
                        mydata = new JObject();

                        mydata.Add(i.getname(), item);
                    }
                    else
                    {
                        mydata = item.Value<JObject>();
                    }
                    html = html + parse(i.getHtml(), mydata, i.origPath + "[" + cnt + "]", true, i.getname());
                    cnt = cnt + 1;
                }

                originalhtml = originalhtml.Replace("#" + i.id + "#", html);
            }

            return originalhtml;
        }



        private string parseListPath(string str)
        {
            int von = str.IndexOf("in ") + 3;
            int bis = str.IndexOf(')');

            return str.Substring(von, bis - von);
        }




        private string parsePath(String str)
        {
            int von = str.IndexOf('(');
            int bis = str.IndexOf(')');

            return str.Substring(von + 1, bis - von - 1);

        }

        public class LabelList
        {
            public BORender boRender { get; set; }
            public int id { get; set; }
            public string Path { get; set; }

            public string getHtml()
            {
                return Path;
            }
        }

        public class EditorList
        {
            public BORender boRender { get; set; }
            public int id { get; set; }
            public string Path { get; set; }

            public string Value { get; set; }

            public string getHtml()
            {

                Console.WriteLine("--------------------------------");
                Console.WriteLine("-- Path:  " + Path);
                Console.WriteLine("-- Value: " + Value);
                string spath = schemapath(Path);
                Console.WriteLine("-- SPath: " + spath);
                Console.WriteLine("-- DataType: " + boRender.jsonschema.SelectToken(spath));

                string type = (string)boRender.jsonschema.SelectToken(spath);

                if (type.Equals("boolean"))
                {
                    string strue = "";
                    string sfalse = "";
                    if (Value.Equals("True"))
                    {
                        strue = @"selected=""selected""";
                    }
                    else
                    {
                        sfalse = @"selected=""selected""";
                    }

                    string input =
                    @"<select name=""{0}"" >
                            <option {1} value=""true"">true</option>
                            <option {2} value=""false"">false</option>
                        </select>";

                    return string.Format(input, Path, strue, sfalse);
                }
                else if (type.Equals("integer"))
                {
                    return string.Format(@"<input type=""text"" name=""{0}"" value=""{1}"" size=""8"" class=""form-control"" onkeypress=""validateinteger(event) "">", Path, Value);
                }
                else if (type.Equals("number"))
                {
                    return string.Format(@"<input type=""text"" name=""{0}"" value=""{1}"" size=""8"" class=""form-control"" onkeypress=""validatenumber(event) "">", Path, Value);
                }
                else
                {
                    return string.Format(@"<input type=""text"" name=""{0}"" value=""{1}"" class=""form-control"">", Path, Value);
                }




            }
        }

        private static string schemapath(string opath)
        {

            List<string> path = opath.Split('.').ToList();
            var spath = "";
            foreach (string i in path)
            {
                string p = i;
                if (i.Contains("["))
                {
                    p = i.Substring(0, i.IndexOf('[')) + ".items";
                }


                spath = spath + "properties." + p + ".";
            }
            return spath + "type";
        }

        public class DataList
        {
            public BORender boRender { get; set; }

            int idcounter = -1;

            public int id { get; set; }

            public string htmloriginal { get; set; }

            public string htmlItem { get; set; }

            public List<JToken> data { get; set; }

            public string origPath { get; set; }

            public string getname()
            {
                int von = htmloriginal.IndexOf("#foreach(") + 9;
                int bis = htmloriginal.IndexOf(" in");

                return htmloriginal.Substring(von, bis - von);
            }

            public string getHtml()
            {
                int start = htmloriginal.IndexOf("{");
                htmlItem = htmloriginal.Substring(start + 1, htmloriginal.Length - start - 3);

                return htmlItem;
            }


        }
    }
}
