namespace WindowsFormsThreads
{
    partial class ThreadForm
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
            this.btnStarta = new System.Windows.Forms.Button();
            this.txtResultat = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStarta
            // 
            this.btnStarta.Location = new System.Drawing.Point(25, 13);
            this.btnStarta.Name = "btnStarta";
            this.btnStarta.Size = new System.Drawing.Size(232, 23);
            this.btnStarta.TabIndex = 0;
            this.btnStarta.Text = "Starta";
            this.btnStarta.UseVisualStyleBackColor = true;
            this.btnStarta.Click += new System.EventHandler(this.btnStarta_Click);
            // 
            // txtResultat
            // 
            this.txtResultat.Location = new System.Drawing.Point(25, 74);
            this.txtResultat.Multiline = true;
            this.txtResultat.Name = "txtResultat";
            this.txtResultat.Size = new System.Drawing.Size(232, 163);
            this.txtResultat.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(25, 43);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtResultat);
            this.Controls.Add(this.btnStarta);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStarta;
        private System.Windows.Forms.TextBox txtResultat;
        private System.Windows.Forms.Label lblInfo;
    }
}

