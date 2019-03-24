namespace MyTaskList.User_Control
{
    partial class MainPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.caseList = new System.Windows.Forms.ListView();
            this.caseDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // caseList
            // 
            this.caseList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.caseDescription});
            this.caseList.Location = new System.Drawing.Point(0, 0);
            this.caseList.Name = "caseList";
            this.caseList.Size = new System.Drawing.Size(121, 97);
            this.caseList.TabIndex = 0;
            this.caseList.UseCompatibleStateImageBehavior = false;
            this.caseList.SelectedIndexChanged += new System.EventHandler(this.caseList_SelectedIndexChanged);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.caseList);
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(677, 432);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView caseList;
        private System.Windows.Forms.ColumnHeader caseDescription;
    }
}
