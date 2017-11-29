using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using RTUtilities;

namespace RTCreator
{
    public partial class TicketForm : Form
    {
        public bool CreatedTemplates;

        public TicketForm()
        {
            InitializeComponent();
            CreatedTemplates = false;
            AddTimeChoices();
        }

        private void AddTimeChoices()
        {
            cboTimeChoices.Items.Clear();
            AddTimeChoice(0, "15", "15 minutes today");
            AddTimeChoice(0, "30", "30 minutes today");
            AddTimeChoice(0, "45", "45 minutes today");
            AddTimeChoice(0, "1h", "1 hour today");
            AddTimeChoice(0, "90", "90 minutes today");
            AddTimeChoice(0, "2h", "2 hours today");
            AddTimeChoice(1, "15", "15 minutes yesterday");
            AddTimeChoice(1, "30", "30 minutes yesterday");
            AddTimeChoice(1, "45", "45 minutes yesterday");
            AddTimeChoice(1, "1h", "1 hour yesterday");
            AddTimeChoice(1, "90", "90 minutes yesterday");
            AddTimeChoice(1, "2h", "2 hours yesterday");
        }

        private void AddTimeChoice(int daysAgo, string time, string label)
        {
            TimeChoice choice = new TimeChoice();
            choice.DaysAgo = daysAgo;
            choice.Time = time;
            choice.Label = label;
            cboTimeChoices.Items.Add(choice);
        }

        private class TimeChoice
        {
            public int DaysAgo;
            public string Time;
            public string Label;

            public override string ToString()
            {
                return Label;
            }
        }

        public void LoadTicket(RTEmail initialContent)
        {
            grdValues.SelectedObject = initialContent;
            this.ShowDialog();
        }

        private void btnMakeTemplate_Click(object sender, EventArgs e)
        {
            using (AskTemplateNameForm frm = new AskTemplateNameForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string fullPath = Path.Combine(RTSettings.GetTemplateDirectory(), frm.TemplateName + RTSettings.TemplateFileType);
                    XmlSerializer serializer = new XmlSerializer(typeof(RTEmail));
                    StringBuilder sb = new StringBuilder();
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlWriterSettings xmlSettings = new XmlWriterSettings();
                    xmlSettings.Indent = true;
                    xmlSettings.OmitXmlDeclaration = true;
                    using (XmlWriter xmlWriter = XmlWriter.Create(fullPath, xmlSettings))
                    {
                        serializer.Serialize(xmlWriter, grdValues.SelectedObject, ns);
                    }
                    MessageBox.Show("Saved as template.");
                    CreatedTemplates = true;
                }
            }
        }

        private void btnMakeEmail_Click(object sender, EventArgs e)
        {
            RTEmail email = (RTEmail)(grdValues.SelectedObject);
            if (email.StartsDate == new DateTime(1900, 1, 1))
                email.StartsDate = DateTime.Today;
            if (email.StartedDate == new DateTime(1900, 1, 1))
                email.StartedDate = DateTime.Today;
            if (email.DueDate == new DateTime(1900, 1, 1))
                email.DueDate = DateTime.Today;
            string msg = email.Validate();
            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg);
                return;
            }
            string body = email.CreateMessage + "\n" + txtNotes.Text;
            body = body
                .Replace("%", "%25")
                .Replace(" ", "%20")
                .Replace(":", "%3a")
                .Replace("{", "%7b")
                .Replace("}", "%7d")
                .Replace("&", "%26")
                .Replace(Environment.NewLine, "%0a")
                .Replace("\n", "%0a")
                .Replace("\"", "%22");
            string address = System.Configuration.ConfigurationManager.AppSettings["CreateEmailAddress"];
            string mailto = "mailto:" + address + "?subject=Create%20RT%20Ticket&body=" + body;
            System.Diagnostics.Process.Start(mailto);
            this.Close();
        }

        private void cboTimeChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeChoice choice = (TimeChoice)cboTimeChoices.SelectedItem;
            DateTime date = DateTime.Today.Subtract(new TimeSpan(choice.DaysAgo, 0, 0, 0));
            RTEmail email = (RTEmail)grdValues.SelectedObject;
            email.DueDate = date;
            email.StartsDate = date;
            email.StartedDate = date;
            email.TimeEstimated = choice.Time;
            email.TimeWorked = choice.Time;
            grdValues.Refresh();
        }
    }
}
