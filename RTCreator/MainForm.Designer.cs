namespace RTCreator
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstTemplates = new System.Windows.Forms.ListBox();
            this.btnNoTemplate = new System.Windows.Forms.Button();
            this.btnUseTemplate = new System.Windows.Forms.Button();
            this.lblTemplates = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstTemplates
            // 
            this.lstTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTemplates.FormattingEnabled = true;
            this.lstTemplates.Location = new System.Drawing.Point(12, 31);
            this.lstTemplates.Name = "lstTemplates";
            this.lstTemplates.Size = new System.Drawing.Size(425, 368);
            this.lstTemplates.TabIndex = 0;
            this.lstTemplates.DoubleClick += new System.EventHandler(this.lstTemplates_DoubleClick);
            // 
            // btnNoTemplate
            // 
            this.btnNoTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoTemplate.Location = new System.Drawing.Point(327, 419);
            this.btnNoTemplate.Name = "btnNoTemplate";
            this.btnNoTemplate.Size = new System.Drawing.Size(110, 23);
            this.btnNoTemplate.TabIndex = 1;
            this.btnNoTemplate.Text = "No Template";
            this.btnNoTemplate.UseVisualStyleBackColor = true;
            this.btnNoTemplate.Click += new System.EventHandler(this.btnNoTemplate_Click);
            // 
            // btnUseTemplate
            // 
            this.btnUseTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUseTemplate.Location = new System.Drawing.Point(211, 419);
            this.btnUseTemplate.Name = "btnUseTemplate";
            this.btnUseTemplate.Size = new System.Drawing.Size(110, 23);
            this.btnUseTemplate.TabIndex = 2;
            this.btnUseTemplate.Text = "Use Template";
            this.btnUseTemplate.UseVisualStyleBackColor = true;
            this.btnUseTemplate.Click += new System.EventHandler(this.btnUseTemplate_Click);
            // 
            // lblTemplates
            // 
            this.lblTemplates.AutoSize = true;
            this.lblTemplates.Location = new System.Drawing.Point(13, 12);
            this.lblTemplates.Name = "lblTemplates";
            this.lblTemplates.Size = new System.Drawing.Size(84, 13);
            this.lblTemplates.TabIndex = 3;
            this.lblTemplates.Text = "Select Template";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 454);
            this.Controls.Add(this.lblTemplates);
            this.Controls.Add(this.btnUseTemplate);
            this.Controls.Add(this.btnNoTemplate);
            this.Controls.Add(this.lstTemplates);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Create RT Ticket - 12/19/2016";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstTemplates;
        private System.Windows.Forms.Button btnNoTemplate;
        private System.Windows.Forms.Button btnUseTemplate;
        private System.Windows.Forms.Label lblTemplates;
    }
}