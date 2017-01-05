namespace RTCreator
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
            this.btnUseToday = new System.Windows.Forms.Button();
            this.btnUseYesterday = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grdValues
            // 
            this.grdValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // btnUseToday
            // 
            this.btnUseToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUseToday.Location = new System.Drawing.Point(12, 606);
            this.btnUseToday.Name = "btnUseToday";
            this.btnUseToday.Size = new System.Drawing.Size(84, 23);
            this.btnUseToday.TabIndex = 3;
            this.btnUseToday.Text = "Use Today";
            this.btnUseToday.UseVisualStyleBackColor = true;
            this.btnUseToday.Click += new System.EventHandler(this.btnUseToday_Click);
            // 
            // btnUseYesterday
            // 
            this.btnUseYesterday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUseYesterday.Location = new System.Drawing.Point(102, 606);
            this.btnUseYesterday.Name = "btnUseYesterday";
            this.btnUseYesterday.Size = new System.Drawing.Size(84, 23);
            this.btnUseYesterday.TabIndex = 4;
            this.btnUseYesterday.Text = "Yesterday";
            this.btnUseYesterday.UseVisualStyleBackColor = true;
            this.btnUseYesterday.Click += new System.EventHandler(this.btnUseYesterday_Click);
            // 
            // TicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 641);
            this.Controls.Add(this.btnUseYesterday);
            this.Controls.Add(this.btnUseToday);
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
        private System.Windows.Forms.Button btnUseToday;
        private System.Windows.Forms.Button btnUseYesterday;
    }
}

