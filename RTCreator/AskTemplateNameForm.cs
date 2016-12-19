using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RTUtilities;

namespace RTCreator
{
    public partial class AskTemplateNameForm : Form
    {
        public string TemplateName;

        public AskTemplateNameForm()
        {
            InitializeComponent();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Enter a template name.");
                return;
            }
            if (txtName.Text.Contains("\\")||txtName.Text.Contains(".")||txtName.Text.Contains("?")||txtName.Text.Contains("*")||txtName.Text.Contains("/"))
            {
                MessageBox.Show("Name contains invalid character.");
                return;
            }
            if (System.IO.File.Exists(System.IO.Path.Combine(RTSettings.GetTemplateDirectory(), txtName.Text + RTSettings.TemplateFileType)))
            {
                MessageBox.Show("There is already a template by that name.");
                return;
            }
            TemplateName = txtName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
