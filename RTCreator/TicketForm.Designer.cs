﻿namespace RTCreator
{
    partial class TicketForm
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
            this.grdValues = new System.Windows.Forms.PropertyGrid();
            this.btnMakeTemplate = new System.Windows.Forms.Button();
            this.btnMakeEmail = new System.Windows.Forms.Button();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.cboTimeChoices = new System.Windows.Forms.ComboBox();
            this.lblQuickTimes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grdValues
            // 
            this.grdValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdValues.LineColor = System.Drawing.SystemColors.ControlDark;
            this.grdValues.Location = new System.Drawing.Point(12, 12);
            this.grdValues.Name = "grdValues";
            this.grdValues.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.grdValues.Size = new System.Drawing.Size(496, 474);
            this.grdValues.TabIndex = 0;
            this.grdValues.ToolbarVisible = false;
            // 
            // btnMakeTemplate
            // 
            this.btnMakeTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeTemplate.Location = new System.Drawing.Point(252, 606);
            this.btnMakeTemplate.Name = "btnMakeTemplate";
            this.btnMakeTemplate.Size = new System.Drawing.Size(125, 23);
            this.btnMakeTemplate.TabIndex = 5;
            this.btnMakeTemplate.Text = "Save As Template";
            this.btnMakeTemplate.UseVisualStyleBackColor = true;
            this.btnMakeTemplate.Click += new System.EventHandler(this.btnMakeTemplate_Click);
            // 
            // btnMakeEmail
            // 
            this.btnMakeEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeEmail.Location = new System.Drawing.Point(383, 606);
            this.btnMakeEmail.Name = "btnMakeEmail";
            this.btnMakeEmail.Size = new System.Drawing.Size(125, 23);
            this.btnMakeEmail.TabIndex = 6;
            this.btnMakeEmail.Text = "Generate RT Email";
            this.btnMakeEmail.UseVisualStyleBackColor = true;
            this.btnMakeEmail.Click += new System.EventHandler(this.btnMakeEmail_Click);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(9, 489);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 1;
            this.lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(12, 505);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(496, 95);
            this.txtNotes.TabIndex = 2;
            // 
            // cboTimeChoices
            // 
            this.cboTimeChoices.FormattingEnabled = true;
            this.cboTimeChoices.Location = new System.Drawing.Point(87, 608);
            this.cboTimeChoices.Name = "cboTimeChoices";
            this.cboTimeChoices.Size = new System.Drawing.Size(128, 21);
            this.cboTimeChoices.TabIndex = 4;
            this.cboTimeChoices.SelectedIndexChanged += new System.EventHandler(this.cboTimeChoices_SelectedIndexChanged);
            // 
            // lblQuickTimes
            // 
            this.lblQuickTimes.AutoSize = true;
            this.lblQuickTimes.Location = new System.Drawing.Point(12, 611);
            this.lblQuickTimes.Name = "lblQuickTimes";
            this.lblQuickTimes.Size = new System.Drawing.Size(69, 13);
            this.lblQuickTimes.TabIndex = 3;
            this.lblQuickTimes.Text = "Quick Times:";
            // 
            // TicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 641);
            this.Controls.Add(this.lblQuickTimes);
            this.Controls.Add(this.cboTimeChoices);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.btnMakeEmail);
            this.Controls.Add(this.btnMakeTemplate);
            this.Controls.Add(this.grdValues);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TicketForm";
            this.ShowIcon = false;
            this.Text = "New Ticket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid grdValues;
        private System.Windows.Forms.Button btnMakeTemplate;
        private System.Windows.Forms.Button btnMakeEmail;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox cboTimeChoices;
        private System.Windows.Forms.Label lblQuickTimes;
    }
}

