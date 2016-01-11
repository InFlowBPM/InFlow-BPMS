using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.WFM.BO_Utilities
{
    public static class FlatJson
    {

        public static string RequestFormToJsonTree(System.Collections.Specialized.NameValueCollection formdata , string schema)
        {
            JObject jsonschema = JObject.Parse(schema);
            Dictionary<string, object> graph = new Dictionary<string, object>();


            int i;
            String[] data = formdata.AllKeys;
            for (i = 0; i < data.Length; i++)
            {
                string key = data[i];
                string strvalue = formdata.GetValues(i)[0];

                List<string> path = key.Split('.').ToList();

                object value = null;

                string spath = schemapath(path);
                string type = (string)jsonschema.SelectToken(spath);
                try
                {
                    if (type.Equals("boolean"))
                    {
                        value = Boolean.Parse(strvalue);
                    }
                    else if (type.Equals("integer"))
                    {
                        value = Int32.Parse(strvalue);
                    }
                    else if (type.Equals("number"))
                    {
                        value = float.Parse(strvalue);
                    }
                    else
                    {
                        value = (string)strvalue;
                    }
                }
                catch (Exception e)
                {
                    value = (string)strvalue;
                }
                add(graph, path, value);
            }

            Dictionary<string, object> newgraph = makelists(graph);


            return Newtonsoft.Json.JsonConvert.SerializeObject(newgraph);
        }

       /* public static string FlatJsonToJsonTree(string flatJson, string schema)
        {
            JObject jsonschema = JObject.Parse(schema);
            Dictionary<string, object> graph = new Dictionary<string, object>();

            List<string> keyvaluePairs = flatJson.Split('&').ToList();

            foreach (string i in keyvaluePairs)
            {
                var kv = i.Split('=');
                List<string> path = kv[0].Split('.').ToList();

                object value = null;

                string spath = schemapath(path);
                string type = (string)jsonschema.SelectToken(spath);
                try
                {
                    if (type.Equals("boolean"))
                    {
                        value = Boolean.Parse(kv[1]);
                    }
                    else if (type.Equals("integer"))
                    {
                        value = Int32.Parse(kv[1]);
                    }
                    else if (type.Equals("number"))
                    {
                        value = float.Parse(kv[1]);
                    }
                    else
                    {
                        value = (string)kv[1];
                    }
                }
                catch (Exception e)
                {
                    value = (string)kv[1];
                }
                add(graph, path, value);
            }


            Dictionary<string, object> newgraph = makelists(graph);


            return Newtonsoft.Json.JsonConvert.SerializeObject(newgraph);
        }*/

        private static string schemapath(List<string> path)
        {
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

        private static Dictionary<string, object> makelists(Dictionary<string, object> graph)
        {
            Dictionary<string, object> newGraph = new Dictionary<string, object>();

            foreach (var i in graph)
            {
                string key = i.Key;
                if (key.Contains("["))
                {
                    key = i.Key.Substring(0, i.Key.IndexOf('['));
                    if (!((IDictionary<string, object>)newGraph).ContainsKey(key))
                    {
                        ((IDictionary<string, object>)newGraph).Add(key, new List<object>());
                    }
                    var newval = i.Value;
                    try
                    {
                        newval = makelists((Dictionary<string, object>)i.Value);
                    }
                    catch (Exception e) { }

                    ((List<object>)newGraph[key]).Add(newval);
                }
                else
                {
                    var newval = i.Value;
                    try
                    {
                        newval = makelists((Dictionary<string, object>)newval);
                    }
                    catch (Exception e) { }
                    newGraph.Add(key, newval);
                }
            }

            return newGraph;
        }

        private static void add(Dictionary<string, object> graph, List<string> path, object value)
        {
            if (path.Count == 1)
            {
                graph.Add(path[0], value);
            }
            else
            {
                if (!graph.ContainsKey(path[0]))
                {
                    graph.Add(path[0], new Dictionary<string, object>());
                }
                string next = path[0];
                path.RemoveAt(0);
                add(((Dictionary<string, object>)graph[next]), path, value);
            }

        }
    }
}
