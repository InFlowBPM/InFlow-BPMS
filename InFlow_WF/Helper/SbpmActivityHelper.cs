using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.WF.Helper
{
    /// <summary>
    /// Helps to convert a csv in Argument to list of string
    /// </summary>
    public class SbpmActivityHelper
    {
        /// <summary>
        /// Convert csv-string to list of string
        /// </summary>
        /// <param name="csv">csv string</param>
        /// <returns>list of string</returns>
        public static List<string> convertCSVtoListofString(String csv)
        {
            if (csv == null)
                csv = "";
            if (csv.Length > 0)
                return new List<string>(csv.Split(','));
            else
                return new List<string>();
        }

        /// <summary>
        /// Converts a csv In-Argument to list of string
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="inArgument">In-Argument with csv-string</param>
        /// <returns>list of string</returns>
        internal static List<string> getList(CodeActivityContext context, InArgument<string> inArgument)
        {
            List<string> returnList = new List<string>();
            if (convertCSVtoListofString(context.GetValue(inArgument)).Count() > 0)
            {
                foreach (string i in convertCSVtoListofString(context.GetValue(inArgument)))
                {
                    returnList.Add(i);
                }
            }
            return returnList;
        }
    }
}
