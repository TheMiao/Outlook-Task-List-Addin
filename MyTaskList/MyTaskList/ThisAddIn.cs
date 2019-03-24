using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using MyTaskList.User_Control;
using Microsoft.Office.Tools;
using System.Windows.Forms;

namespace MyTaskList
{
    public partial class ThisAddIn
    {
        private MainPage mainPageUserControl;
        private CustomTaskPane myCustomTaskPane;

        /*
         TODO:
         1. Create a new contact address group
         2. Add case as address into the contact address group
         3. Deliver case ID + case Title in custom properties into main page for display in the listview.
         4. Click specific item in the list and navigate to details page
         5. etc.
         */

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            mainPageUserControl = new MainPage();
            myCustomTaskPane = this.CustomTaskPanes.Add(mainPageUserControl, "My Case List");
            myCustomTaskPane.Visible = true;
            myCustomTaskPane.Width = 500;
            // AddContact();
            //SetCurrentFolder();
            //CreateCustomFolder();
            // AddDefaultContact();
            FindContactEmailByName("Chris", "Berry");
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        private void SetCurrentFolder()
        {
            string folderName = "1234567890123456";
            Outlook.MAPIFolder inBox = (Outlook.MAPIFolder)
                this.Application.ActiveExplorer().Session.GetDefaultFolder
                (Outlook.OlDefaultFolders.olFolderInbox);
            try
            {
                this.Application.ActiveExplorer().CurrentFolder = inBox.
                    Folders[folderName];
                this.Application.ActiveExplorer().CurrentFolder.Display();
            }
            catch
            {
                MessageBox.Show("There is no folder named " + folderName +
                    ".", "Find Folder Name");
            }
        }

        private void FindContactEmailByName(string firstName, string lastName)
        {
            Outlook.NameSpace outlookNameSpace = this.Application.GetNamespace("MAPI");
            Outlook.MAPIFolder contactsFolder =
                outlookNameSpace.GetDefaultFolder(
                Microsoft.Office.Interop.Outlook.
                OlDefaultFolders.olFolderContacts);

            Outlook.Items contactItems = contactsFolder.Items;

            try
            {
                Outlook.ContactItem contact =
                    (Outlook.ContactItem)contactItems.
                    Find(String.Format("[FirstName]='{0}' and "
                    + "[LastName]='{1}'", firstName, lastName));
                if (contact != null)
                {
                    contact.Display(true);
                    var t = contact.UserProperties["CaseID"].Value;
                    MessageBox.Show(t);
                }
                else
                {
                    MessageBox.Show("The contact information was not found.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void AddDefaultContact()
        {
            Outlook.ContactItem newContact = (Outlook.ContactItem)
                this.Application.CreateItem(Outlook.OlItemType.olContactItem);
            try
            {
                newContact.FirstName = "Chris";
                newContact.LastName = "Berry";
                newContact.Email1Address = "somebody@example.com";
                newContact.CustomerID = "123456";
                newContact.PrimaryTelephoneNumber = "(425)555-0111";
                newContact.MailingAddressStreet = "123 Main St.";
                newContact.MailingAddressCity = "Redmond";
                var mailUserProperties = newContact.UserProperties;
                // Where 1 is OlFormatText (introduced in Outlook 2007)
                newContact.UserProperties.Add("CaseID",Outlook.OlUserPropertyType.olText, true, 1);
                newContact.UserProperties["CaseID"].Value = "1234567890123456";
                //newContact.UserProperties["Case Id"].Value = "1234567890123456";
                newContact.MailingAddressState = "WA";
                newContact.Save();
                newContact.Display(true);
            }
            catch
            {
                MessageBox.Show("The new contact was not saved.");
            }
        }


        private void AddContact()
        {
            Outlook.MAPIFolder inBox = this.Application.ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            var folder = inBox;
            Outlook.ContactItem contact = folder.Items.Add("1234567890123456") as Outlook.ContactItem;
            contact.FirstName = "Michael";
            contact.LastName = "Affronti";
            contact.UserProperties["Shoe Size"].Value = "9";
            contact.UserProperties["Case Id"].Value = "1234567890123456";
            contact.Save();
        }

        private void CreateCustomFolder()
        {
            Outlook.MAPIFolder inBox = this.Application.ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            // string userName = (string)this.Application.ActiveExplorer().Session.CurrentUser.Name;
            Outlook.MAPIFolder customFolder = null;
            try
            {
                customFolder = inBox.Folders.Add("1234567890123456",
                    Outlook.OlDefaultFolders.olFolderInbox);
                MessageBox.Show("You have created a new folder named " +
                    "1234567890123456" + ".");
                inBox.Folders["1234567890123456"].Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
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
