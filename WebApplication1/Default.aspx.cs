using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic.FileIO;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected global::System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected global::System.Web.UI.HtmlControls.HtmlInputSubmit Submit1;
        protected global::System.Web.UI.WebControls.Label Label1;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            // 
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            // 
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void Submit1_ServerClick(object sender, System.EventArgs e)
        {
            if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
            {
                if (System.IO.Path.GetExtension(File1.PostedFile.FileName) == ".csv")
                {
                    string fn = "Dataset.csv";
                    string SaveLocation = Server.MapPath("Data") + "\\" + fn;
                    try
                    {
                        File1.PostedFile.SaveAs(SaveLocation);
                        Label1.ForeColor = System.Drawing.Color.Green;
                        Label1.Text = "The file has been uploaded.";
                    }
                    catch (Exception ex)
                    {
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Text = "Error: " + ex.Message;
                    }
                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Select correct file type to upload (only .csv)";
                }
            }
            else
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Please select a file to upload.";
            }
        }
    }
}
