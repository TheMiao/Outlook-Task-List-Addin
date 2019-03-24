using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using MyTaskList.User_Control;
using Microsoft.Office.Tools;

namespace MyTaskList
{
    public partial class ThisAddIn
    {
        private MainPage mainPageUserControl;
        private CustomTaskPane myCustomTaskPane;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            mainPageUserControl = new MainPage();
            myCustomTaskPane = this.CustomTaskPanes.Add(mainPageUserControl, "My Case List");
            myCustomTaskPane.Visible = true;
            myCustomTaskPane.Width = 500;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
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
