namespace WindowsFormsAsync
{
    partial class MoreAync
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
            this.btnAsync = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnSkriv = new System.Windows.Forms.Button();
            this.btnRensa = new System.Windows.Forms.Button();
            this.btnMedWhenAll = new System.Windows.Forms.Button();
            this.btnFilltext = new System.Windows.Forms.Button();
            this.btnFilltextParallel = new System.Windows.Forms.Button();
            this.btnAzureDb = new System.Windows.Forms.Button();
            this.btnAzureDbBatchvis = new System.Windows.Forms.Button();
            this.btnLoopTest = new System.Windows.Forms.Button();
            this.btnVisaKundlista = new System.Windows.Forms.Button();
            this.btnTaskRunTests = new System.Windows.Forms.Button();
            this.btnAntalFiler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(26, 10);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(75, 23);
            this.btnAsync.TabIndex = 0;
            this.btnAsync.Text = "Async";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(26, 120);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(871, 228);
            this.txtResult.TabIndex = 1;
            // 
            // btnSkriv
            // 
            this.btnSkriv.Location = new System.Drawing.Point(26, 39);
            this.btnSkriv.Name = "btnSkriv";
            this.btnSkriv.Size = new System.Drawing.Size(75, 23);
            this.btnSkriv.TabIndex = 2;
            this.btnSkriv.Text = "Skriv text";
            this.btnSkriv.UseVisualStyleBackColor = true;
            this.btnSkriv.Click += new System.EventHandler(this.btnSkriv_Click);
            // 
            // btnRensa
            // 
            this.btnRensa.Location = new System.Drawing.Point(111, 39);
            this.btnRensa.Name = "btnRensa";
            this.btnRensa.Size = new System.Drawing.Size(80, 23);
            this.btnRensa.TabIndex = 3;
            this.btnRensa.Text = "Rensa";
            this.btnRensa.UseVisualStyleBackColor = true;
            this.btnRensa.Click += new System.EventHandler(this.btnRensa_Click);
            // 
            // btnMedWhenAll
            // 
            this.btnMedWhenAll.Location = new System.Drawing.Point(111, 10);
            this.btnMedWhenAll.Name = "btnMedWhenAll";
            this.btnMedWhenAll.Size = new System.Drawing.Size(80, 23);
            this.btnMedWhenAll.TabIndex = 4;
            this.btnMedWhenAll.Text = "MedWhenAll";
            this.btnMedWhenAll.UseVisualStyleBackColor = true;
            this.btnMedWhenAll.Click += new System.EventHandler(this.btnMedWhenAll_Click);
            // 
            // btnFilltext
            // 
            this.btnFilltext.Location = new System.Drawing.Point(206, 10);
            this.btnFilltext.Name = "btnFilltext";
            this.btnFilltext.Size = new System.Drawing.Size(75, 23);
            this.btnFilltext.TabIndex = 5;
            this.btnFilltext.Text = "Filltext";
            this.btnFilltext.UseVisualStyleBackColor = true;
            this.btnFilltext.Click += new System.EventHandler(this.btnFilltext_Click);
            // 
            // btnFilltextParallel
            // 
            this.btnFilltextParallel.Location = new System.Drawing.Point(287, 10);
            this.btnFilltextParallel.Name = "btnFilltextParallel";
            this.btnFilltextParallel.Size = new System.Drawing.Size(93, 23);
            this.btnFilltextParallel.TabIndex = 6;
            this.btnFilltextParallel.Text = "Filltext parallell";
            this.btnFilltextParallel.UseVisualStyleBackColor = true;
            this.btnFilltextParallel.Click += new System.EventHandler(this.btnFilltextParallel_Click);
            // 
            // btnAzureDb
            // 
            this.btnAzureDb.Location = new System.Drawing.Point(396, 10);
            this.btnAzureDb.Name = "btnAzureDb";
            this.btnAzureDb.Size = new System.Drawing.Size(75, 23);
            this.btnAzureDb.TabIndex = 7;
            this.btnAzureDb.Text = "AzureDb";
            this.btnAzureDb.UseVisualStyleBackColor = true;
            this.btnAzureDb.Click += new System.EventHandler(this.btnAzureDb_Click);
            // 
            // btnAzureDbBatchvis
            // 
            this.btnAzureDbBatchvis.Location = new System.Drawing.Point(477, 10);
            this.btnAzureDbBatchvis.Name = "btnAzureDbBatchvis";
            this.btnAzureDbBatchvis.Size = new System.Drawing.Size(107, 23);
            this.btnAzureDbBatchvis.TabIndex = 8;
            this.btnAzureDbBatchvis.Text = "AzureDb batchvis";
            this.btnAzureDbBatchvis.UseVisualStyleBackColor = true;
            this.btnAzureDbBatchvis.Click += new System.EventHandler(this.btnAzureDbBatchvis_Click);
            // 
            // btnLoopTest
            // 
            this.btnLoopTest.Location = new System.Drawing.Point(26, 68);
            this.btnLoopTest.Name = "btnLoopTest";
            this.btnLoopTest.Size = new System.Drawing.Size(75, 23);
            this.btnLoopTest.TabIndex = 9;
            this.btnLoopTest.Text = "LoopTest";
            this.btnLoopTest.UseVisualStyleBackColor = true;
            this.btnLoopTest.Click += new System.EventHandler(this.btnLoopTest_Click);
            // 
            // btnVisaKundlista
            // 
            this.btnVisaKundlista.Location = new System.Drawing.Point(111, 68);
            this.btnVisaKundlista.Name = "btnVisaKundlista";
            this.btnVisaKundlista.Size = new System.Drawing.Size(75, 23);
            this.btnVisaKundlista.TabIndex = 10;
            this.btnVisaKundlista.Text = "Visa kundlista";
            this.btnVisaKundlista.UseVisualStyleBackColor = true;
            this.btnVisaKundlista.Click += new System.EventHandler(this.btnVisaKundlista_Click);
            // 
            // btnTaskRunTests
            // 
            this.btnTaskRunTests.Location = new System.Drawing.Point(206, 39);
            this.btnTaskRunTests.Name = "btnTaskRunTests";
            this.btnTaskRunTests.Size = new System.Drawing.Size(174, 23);
            this.btnTaskRunTests.TabIndex = 11;
            this.btnTaskRunTests.Text = "Task.Run-tester";
            this.btnTaskRunTests.UseVisualStyleBackColor = true;
            this.btnTaskRunTests.Click += new System.EventHandler(this.btnTaskRunTests_Click);
            // 
            // btnAntalFiler
            // 
            this.btnAntalFiler.Location = new System.Drawing.Point(396, 39);
            this.btnAntalFiler.Name = "btnAntalFiler";
            this.btnAntalFiler.Size = new System.Drawing.Size(75, 23);
            this.btnAntalFiler.TabIndex = 12;
            this.btnAntalFiler.Text = "Antal filer";
            this.btnAntalFiler.UseVisualStyleBackColor = true;
            this.btnAntalFiler.Click += new System.EventHandler(this.btnAntalFiler_Click);
            // 
            // MoreAync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 360);
            this.Controls.Add(this.btnAntalFiler);
            this.Controls.Add(this.btnTaskRunTests);
            this.Controls.Add(this.btnVisaKundlista);
            this.Controls.Add(this.btnLoopTest);
            this.Controls.Add(this.btnAzureDbBatchvis);
            this.Controls.Add(this.btnAzureDb);
            this.Controls.Add(this.btnFilltextParallel);
            this.Controls.Add(this.btnFilltext);
            this.Controls.Add(this.btnMedWhenAll);
            this.Controls.Add(this.btnRensa);
            this.Controls.Add(this.btnSkriv);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnAsync);
            this.Name = "MoreAync";
            this.Text = "MoreAync";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnSkriv;
        private System.Windows.Forms.Button btnRensa;
        private System.Windows.Forms.Button btnMedWhenAll;
        private System.Windows.Forms.Button btnFilltext;
        private System.Windows.Forms.Button btnFilltextParallel;
        private System.Windows.Forms.Button btnAzureDb;
        private System.Windows.Forms.Button btnAzureDbBatchvis;
        private System.Windows.Forms.Button btnLoopTest;
        private System.Windows.Forms.Button btnVisaKundlista;
        private System.Windows.Forms.Button btnTaskRunTests;
        private System.Windows.Forms.Button btnAntalFiler;
    }
}