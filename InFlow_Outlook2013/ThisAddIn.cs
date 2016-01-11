using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace InFlow_Outlook2013
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            EnsureSolutionsModule();

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        private void EnsureSolutionsModule()
        {

            // Declarations.
            Outlook.Folder solutionRoot;

            bool firstRun = false;
            Outlook.Folder rootStoreFolder =
                Application.Session.DefaultStore.GetRootFolder()
                as Outlook.Folder;

            try
            {
                rootStoreFolder.Folders["Finanzierungskonzept"].Delete();
            }
            catch
            {
            }

            // If the solution root folder does not exist, create it.
            // Note that the solution root 
            // could also be in a PST or custom store.
            try
            {
                solutionRoot =
                    rootStoreFolder.Folders["Finanzierungskonzept"]
                    as Outlook.Folder;
            }
            catch
            {
                firstRun = true;
            }

            if (firstRun == true)
            {
                solutionRoot =
                    rootStoreFolder.Folders.Add("Finanzierungskonzept", Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox)
                    as Outlook.Folder;

            }
            else
            {
                solutionRoot =
                    rootStoreFolder.Folders["Finanzierungskonzept"]
                    as Outlook.Folder;

            }

            solutionRoot.WebViewURL = "http://fk.r-p.at";
            solutionRoot.WebViewOn = true;
            // Obtain a reference to the Solutions module.
            Outlook.Explorer explorer = Application.ActiveExplorer();
            Outlook.SolutionsModule solutionsModule =
                 explorer.NavigationPane.Modules.GetNavigationModule(
                 Outlook.OlNavigationModuleType.olModuleSolutions)
                 as Outlook.SolutionsModule;
            // Add the solution and hide folders in default modules.
            solutionsModule.AddSolution(solutionRoot,
                Outlook.OlSolutionScope.olHideInDefaultModules);
            // The following code sets the position and visibility
            // of the Solutions module.
            if (solutionsModule.Visible == false)
            {
                // Set Visibile to true
                solutionsModule.Visible = true;
            }
            if (solutionsModule.Position != 6)
            {
                // Move SolutionsModule to Position = 5
                solutionsModule.Position = 6;
            }
            // Create an instance variable for the Navigation Pane.
            Outlook.NavigationPane navPane = explorer.NavigationPane;
            if (navPane.DisplayedModuleCount != 6)
            {
                // Ensure that the Solutions module button is large.
                navPane.DisplayedModuleCount = 6;
            }
        }
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
