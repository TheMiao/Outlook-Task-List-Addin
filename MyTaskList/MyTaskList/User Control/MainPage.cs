using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTaskList.User_Control
{
    public partial class MainPage : UserControl
    {

        public MainPage()
        {
            InitializeComponent();
            SetupCaseListUI();
            RetrieveCaseList();
        }

        /// <summary>
        /// Retrieve data for the case list
        /// </summary>
        private void RetrieveCaseList()
        {
            MockData();
        }

        private void MockData()
        {
            for (int i = 0; i < 10; i++)
            {
                caseList.Items.Add($"1234567890123456{i} | Delete the instance this is the long title test, I have to input as long as I can and test it out if it can auto cross to second line");
            }

            caseList.Items.Add("Delete the instance");
            caseList.Items.Add("Delete the instance");
        }

        /// <summary>
        /// Setup case list UI
        /// </summary>
        private void SetupCaseListUI()
        {
            // set up the dock to full width of custom panel
            caseList.Dock = DockStyle.Fill;

            // check full details of the item in the list and set the row can be selected
            caseList.View = View.Details;
            caseList.FullRowSelect = true;
        }

        private void caseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listview = sender as ListView;
            var text = listview.FocusedItem.Text;
        }
    }
}
