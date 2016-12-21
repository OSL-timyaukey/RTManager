﻿using System;
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
            string msg = email.Validate();
            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg);
                return;
            }
            string body = email.CreateMessage + "\n" + txtNotes.Text;
            //body = System.Web.HttpUtility.UrlEncode(body);
            body = body.Replace("%", "%25").Replace(" ", "%20").Replace(":", "%3a").Replace("{", "%7b").Replace("{", "%7d").
                Replace(Environment.NewLine, "%0a").Replace("\n", "%0a");
            string mailto = "mailto:lottery.servicemgmt@rt.lottery.state.or.us?subject=Create%20RT%20Ticket&body=" + body;
            System.Diagnostics.Process.Start(mailto);
            this.Close();
        }
    }
}