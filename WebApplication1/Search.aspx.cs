using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic.FileIO;
using WebApplication1;

namespace WebApplication1
{
    public partial class Search : System.Web.UI.Page
    {
        protected global::System.Web.UI.WebControls.DropDownList DropDownList1;
        protected global::System.Web.UI.WebControls.TextBox TextBox1;
        protected global::System.Web.UI.WebControls.CompareValidator CompareValidator1;
        protected global::System.Web.UI.WebControls.TextBox TextBox2;
        protected global::System.Web.UI.WebControls.Button Button1;
        protected global::System.Web.UI.WebControls.Button Button2;
        protected global::System.Web.UI.WebControls.Label Result;

        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        List<ModificationEntity> data = new List<ModificationEntity>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ReadData();
            }
            catch (Exception ex)
            {
                return;
            }

            if (TextBox1.Text == null || TextBox1.Text == "")
            {
                Result.ForeColor = System.Drawing.Color.Red;
                Result.Text = "Enter ID";
                return;
            }

            if (Request.Form[TextBox2.UniqueID] == null || Request.Form[TextBox2.UniqueID] == "")
            {
                Result.ForeColor = System.Drawing.Color.Red;
                Result.Text = "Enter valid date";
                return;
            }

            int id = Convert.ToInt16(TextBox1.Text);
            string type = DropDownList1.SelectedValue;
            DateTime date = DateTime.Parse(Request.Form[TextBox2.UniqueID]);

            IEnumerable<ModificationEntity> relevant = data.Where(item => item.objectId == id && item.objectType == type && item.timeStamp <= date);

            if (relevant.Count() == 0)
            {
                Result.ForeColor = System.Drawing.Color.Red;
                Result.Text = "No object found.";
                return;
            }

            relevant = relevant.OrderByDescending(o => o.timeStamp);

            ObjectEntity OEntity = new ObjectEntity();

            OEntity.objectId = id;
            OEntity.objectType = type;

            foreach (var a in relevant)
            {
                foreach (var b in a.changes)
                {
                    if (OEntity.properties.ContainsKey(b.Key))
                        continue;
                    else
                        OEntity.properties.Add(b.Key, b.Value);
                }
            }

            DisplayObject(OEntity);
            TextBox2.Text = date.ToString();
        }

        private void DisplayObject(ObjectEntity OEntity)
        {
            string text = "Object Type: " + OEntity.objectType + System.Environment.NewLine +
                "Object ID: " + OEntity.objectId + System.Environment.NewLine +
                "Properties: ";
            foreach (var a in OEntity.properties)
                text += System.Environment.NewLine + a.Key + ": " + a.Value;

            Result.ForeColor = System.Drawing.Color.Black;
            Result.Text = text.Replace(Environment.NewLine, "<br />");
        }

        private void ReadData()
        {
            string fn = "Dataset.csv";
            string SaveLocation = Server.MapPath("Data") + "\\" + fn;
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(SaveLocation))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        ModificationEntity MEntity = new ModificationEntity();

                        MEntity.objectId = Convert.ToInt32(fieldData[0]);
                        MEntity.objectType = fieldData[1];
                        MEntity.timeStamp = epoch.AddSeconds(Convert.ToInt32(fieldData[2]));

                        fieldData[3] = fieldData[3].Substring(1);
                        fieldData[fieldData.Count() - 1] = fieldData.Last().Remove(fieldData.Last().Count() - 1);

                        for (int i = 3; i < fieldData.Count(); i++)
                        {
                            string[] split = fieldData[i].Split(new char[] { ':' }, 2);
                            split[1] = split[1].TrimStart();
                            MEntity.changes.Add(split[0], split[1]);
                        }

                        data.Add(MEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                Result.ForeColor = System.Drawing.Color.Red;
                Result.Text = "No file uploaded.";
                throw new Exception();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        { }
    }
}