using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using RTUtilities;

namespace RTCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadTemplateList();
            lblTemplates.Text = "Select Template (from " + RTSettings.GetTemplateDirectory() + ")";
        }

        private void LoadTemplateList()
        {
            lstTemplates.Items.Clear();
            if (!Directory.Exists(RTSettings.GetTemplateDirectory()))
            {
                Directory.CreateDirectory(RTSettings.GetTemplateDirectory());
            }
            else
            {
                foreach (string file in Directory.EnumerateFiles(RTSettings.GetTemplateDirectory(), "*" + RTSettings.TemplateFileType))
                {
                    lstTemplates.Items.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
        }

        private void btnUseTemplate_Click(object sender, EventArgs e)
        {
            string file = (string)lstTemplates.SelectedItem;
            if (string.IsNullOrEmpty(file))
            {
                MessageBox.Show("Please choose a template.");
                return;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(RTEmail));
            RTEmail email;
            using (TextReader textReader = new StreamReader(Path.Combine(RTSettings.GetTemplateDirectory(), file + RTSettings.TemplateFileType)))
            {
                using (XmlReader xmlReader = XmlReader.Create(textReader))
                {
                    email = (RTEmail)serializer.Deserialize(xmlReader);
                }
            }
            if (email.StartsDate == new DateTime(1900, 1, 1))
                email.StartsDate = DateTime.Today;
            if (email.StartedDate == new DateTime(1900, 1, 1))
                email.StartedDate = DateTime.Today;
            if (email.DueDate == new DateTime(1900, 1, 1))
                email.DueDate = DateTime.Today;
            using (TicketForm frm = new TicketForm())
            {
                frm.LoadTicket(email);
                if (frm.CreatedTemplates)
                    LoadTemplateList();
            }
        }

        private void btnNoTemplate_Click(object sender, EventArgs e)
        {
            using (TicketForm frm = new TicketForm())
            {
                RTEmail email = new RTEmail();
                frm.LoadTicket(email);
                if (frm.CreatedTemplates)
                    LoadTemplateList();
            }
        }

        private void lstTemplates_DoubleClick(object sender, EventArgs e)
        {
            btnUseTemplate_Click(sender, e);
        }
    }
}
