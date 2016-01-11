using strICT.InFlow.AppWFM.Lib;
using strICT.InFlow.WFM.Core;
using strICT.InFlow.WFM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net;
namespace strICT.InFlow.AppWFM
{


    public class MyPolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(
              ServicePoint srvPoint
            , X509Certificate certificate
            , WebRequest request
            , int certificateProblem)
        {

            //Return True to force the certificate to be accepted.
            return true;

        } // end CheckValidationResult
    } // class MyPolicy
    class Program
    {
        /*
         //WS2012DEV
        static string cfgWFMBaseAddress = "https://WS2012Dev:12290/";
        static string cfgWFMUsername = "Administrator";
        static string cfgWFMPassword = "GH32$3e4r";
        static string cfgSQLConnectionString_InFlow = "Data Source=WS2012Dev;Initial Catalog=InFlow-DB;Integrated Security=False;User ID=admin;Password=admin;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

        const string SBServerFQDN = "WS2012Dev";
        const string SBNamespace = "TestSB";
        const string SBUsername = "Administrator";
        const string SBPassword = "GH32$3e4r";

        static string ScopeName = "InFlow";

        static string workflow_TaskHandler_Path = @"..\..\..\InFlow_Workflows\TaskTier.xaml";
        static string workflow_MessageHandler_Path = @"..\..\..\InFlow_Workflows\MessageTier.xaml";
        */
        /*
        //WA Demo-InFlow
        static string cfgWFMBaseAddress = "https://Demo-InFlow:12290/";
        static string cfgWFMUsername = "strictadmin";
        static string cfgWFMPassword = "STr!CT4KPass1";
        static string cfgSQLConnectionString_InFlow = "Server=tcp:cazgb51p61.database.windows.net,1433;Database=Demo-InFlow;User ID=strictadmin@cazgb51p61;Password=STr!CT4KPass1;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";


        static string workflow_TaskHandler_Path = @"C:\StrICT\InFlow\TaskTier.xaml";
        static string workflow_MessageHandler_Path = @"C:\StrICT\InFlow\MessageTier.xaml";*/

        /*
        static string cfgWFMBaseAddress = "https://Demo-InFlow:12290/";
        static string cfgWFMUsername = "strictadmin";
        static string cfgWFMPassword = "STr!CT4KPass1";
        static string cfgSQLConnectionString_InFlow = "Server=tcp:cazgb51p61.database.windows.net,1433;Database=WAAD-InFlow;User ID=strictadmin@cazgb51p61;Password=STr!CT4KPass1;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";


        static string ScopeName = "WAAD";


        static string workflow_TaskHandler_Path = @"C:\StrICT\InFlow\TaskTier.xaml";
        static string workflow_MessageHandler_Path = @"C:\StrICT\InFlow\MessageTier.xaml";
        

        
        //INFLOW_CLOUD
        static string cfgWFMBaseAddress = "https://Demo-InFlow:12290/";
        static string cfgWFMUsername = "strictadmin";
        static string cfgWFMPassword = "STr!CT4KPass1";
        static string cfgSQLConnectionString_InFlow = "Server=tcp:cazgb51p61.database.windows.net,1433;Database=inflow-{0};User ID=strictadmin@cazgb51p61;Password=STr!CT4KPass1;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
        */

        static string cfgWFMBaseAddress = "https://10.0.0.20:12290/";
        static string cfgWFMUsername = "Administrator";
        static string cfgWFMPassword = "GH32$3e4r";
        static string cfgSQLConnectionString_InFlow = "Data Source=10.0.0.20;Initial Catalog=InFlow-{0};Integrated Security=False;User ID=admin;Password=admin;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;MultipleActiveResultSets=True";

         
        
        static string ScopeName = "";

       

        static string workflow_TaskHandler_Path = @"C:\StrICT\InFlow\TaskTier.xaml";
        static string workflow_MessageHandler_Path = @"C:\StrICT\InFlow\MessageTier.xaml";

        /*
       static string cfgWFMBaseAddress = "https://localhost:12290/";
       static string cfgWFMUsername = "strictwfm";
       static string cfgWFMPassword = "Riegler2014!";
       static string cfgSQLConnectionString_InFlow = @"Data Source=WIN-60UHMF8LEV6\SQLEXPRESS;Initial Catalog=InFlow-DB;Integrated Security=False;User ID=rpadmin;Password=Riegler2014!;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

       const string SBServerFQDN = "WIN-60UHMF8LEV6";
       const string SBNamespace = "InFlow";
       const string SBUsername = "strictadmin";
       const string SBPassword = "Riegler2014!";
       
        static string ScopeName = "InFlow";

        static string workflow_TaskHandler_Path = @"C:\strict\InFlow\TaskTier.xaml";
        static string workflow_MessageHandler_Path = @"C:\strict\InFlow\MessageTier.xaml";
         */

        static void Main(string[] args)
        {
          //  System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            DConsole.Print("DPMS-Azure Management Console\n", ConsoleColor.Yellow);
            Console.WriteLine();
            start();
            
        }
        static void start()
        {
            DConsole.Print("ScopeName: ");
            string input = DConsole.ReadLine();

            ScopeName = input;
            cfgSQLConnectionString_InFlow = string.Format(cfgSQLConnectionString_InFlow, ScopeName);


            DConsole.Print("init? (yes/no)");
            string init = DConsole.ReadLine();


            if (init.Equals("yes"))
            {
                setUpScope();
            }
            else
            {
                listCompanyScopes();
            }
            DConsole.Print("clean? (yes/no)");
            string clean = DConsole.ReadLine();
            if (clean.Equals("yes"))
            {
                cleanScope();
            }


            Console.ReadLine();
        }

        static void listCompanyScopes()
        {
            InFlowWFM wfm = new InFlowWFM(cfgWFMBaseAddress, cfgWFMUsername, cfgWFMPassword, cfgSQLConnectionString_InFlow);

            DConsole.PrintList(wfm.listCompanyScopes(), "Company-Scopes:");
            Console.WriteLine();

            DConsole.PrintList(wfm.listProcessScopes(ScopeName), "Process Scopes of InFlow");
        }

        static void cleanScope()
        {
            InFlowWFM wfm = new InFlowWFM(cfgWFMBaseAddress, cfgWFMUsername, cfgWFMPassword, cfgSQLConnectionString_InFlow);

            

            string input = "...";

            do
            {
                DConsole.PrintEmptyLines();
                DConsole.Print("ProcessName:");
                input = Console.ReadLine();
                if(input.Length > 0)
                    DConsole.Print(wfm.deleteProcess(ScopeName, input));
                if (input.Length <= 0)
                    DConsole.Print(wfm.deleteCompanyScope(ScopeName));

                DConsole.PrintDone(); Console.WriteLine();

            } while (input.Length > 0);

            start();
        }

        static void setUpScope()
        {
            InFlowWFM wfm = new InFlowWFM(cfgWFMBaseAddress, cfgWFMUsername, cfgWFMPassword, cfgSQLConnectionString_InFlow);

       
                 Console.WriteLine("Create Company-Scope InFlow");

                 DConsole.Print(wfm.addCompanyScope(ScopeName, workflow_TaskHandler_Path) + "\n");

                 DConsole.PrintDone(); Console.WriteLine();
        }
    }
}
