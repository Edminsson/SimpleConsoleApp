namespace WindowsFormsAsync
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.textResultat = new System.Windows.Forms.TextBox();
            this.btnRensa = new System.Windows.Forms.Button();
            this.btnLoop = new System.Windows.Forms.Button();
            this.btnDeadLock = new System.Windows.Forms.Button();
            this.btnNoDeadlock = new System.Windows.Forms.Button();
            this.comboAction = new System.Windows.Forms.ComboBox();
            this.comboActionNoAsync = new System.Windows.Forms.ComboBox();
            this.btnOwnAwaitable = new System.Windows.Forms.Button();
            this.comboAntal = new System.Windows.Forms.ComboBox();
            this.btnSerie = new System.Windows.Forms.Button();
            this.btnTcsTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(25, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(213, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Starta";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textResultat
            // 
            this.textResultat.Location = new System.Drawing.Point(25, 191);
            this.textResultat.Multiline = true;
            this.textResultat.Name = "textResultat";
            this.textResultat.Size = new System.Drawing.Size(433, 250);
            this.textResultat.TabIndex = 1;
            // 
            // btnRensa
            // 
            this.btnRensa.Location = new System.Drawing.Point(245, 12);
            this.btnRensa.Name = "btnRensa";
            this.btnRensa.Size = new System.Drawing.Size(213, 23);
            this.btnRensa.TabIndex = 2;
            this.btnRensa.Text = "Rensa";
            this.btnRensa.UseVisualStyleBackColor = true;
            this.btnRensa.Click += new System.EventHandler(this.btnRensa_Click);
            // 
            // btnLoop
            // 
            this.btnLoop.Location = new System.Drawing.Point(25, 42);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(432, 23);
            this.btnLoop.TabIndex = 3;
            this.btnLoop.Text = "Loop";
            this.btnLoop.UseVisualStyleBackColor = true;
            this.btnLoop.Click += new System.EventHandler(this.btnLoop_Click);
            // 
            // btnDeadLock
            // 
            this.btnDeadLock.Location = new System.Drawing.Point(244, 113);
            this.btnDeadLock.Name = "btnDeadLock";
            this.btnDeadLock.Size = new System.Drawing.Size(213, 23);
            this.btnDeadLock.TabIndex = 4;
            this.btnDeadLock.Text = "No async click handler";
            this.btnDeadLock.UseVisualStyleBackColor = true;
            this.btnDeadLock.Click += new System.EventHandler(this.btnDeadLock_Click);
            // 
            // btnNoDeadlock
            // 
            this.btnNoDeadlock.Location = new System.Drawing.Point(245, 78);
            this.btnNoDeadlock.Name = "btnNoDeadlock";
            this.btnNoDeadlock.Size = new System.Drawing.Size(213, 23);
            this.btnNoDeadlock.TabIndex = 5;
            this.btnNoDeadlock.Text = "Async click handler";
            this.btnNoDeadlock.UseVisualStyleBackColor = true;
            this.btnNoDeadlock.Click += new System.EventHandler(this.btnNoDeadlock_Click);
            // 
            // comboAction
            // 
            this.comboAction.FormattingEnabled = true;
            this.comboAction.Items.AddRange(new object[] {
            "NoDeadlock",
            "NoDeadlockWithContinue",
            "Enkel await",
            "Anrop av konstig TaskCompletionSource",
            "Bättre TaskCompletionSource"});
            this.comboAction.Location = new System.Drawing.Point(25, 78);
            this.comboAction.Name = "comboAction";
            this.comboAction.Size = new System.Drawing.Size(213, 21);
            this.comboAction.TabIndex = 6;
            // 
            // comboActionNoAsync
            // 
            this.comboActionNoAsync.FormattingEnabled = true;
            this.comboActionNoAsync.Items.AddRange(new object[] {
            "Deadlock",
            "Lambda task",
            "ImplicitWait",
            "Simple TaskCompletionSource",
            "Anropa enkel Task-klass"});
            this.comboActionNoAsync.Location = new System.Drawing.Point(25, 115);
            this.comboActionNoAsync.Name = "comboActionNoAsync";
            this.comboActionNoAsync.Size = new System.Drawing.Size(213, 21);
            this.comboActionNoAsync.TabIndex = 7;
            // 
            // btnOwnAwaitable
            // 
            this.btnOwnAwaitable.Location = new System.Drawing.Point(117, 151);
            this.btnOwnAwaitable.Name = "btnOwnAwaitable";
            this.btnOwnAwaitable.Size = new System.Drawing.Size(134, 23);
            this.btnOwnAwaitable.TabIndex = 8;
            this.btnOwnAwaitable.Text = "Own Awaitable";
            this.btnOwnAwaitable.UseVisualStyleBackColor = true;
            this.btnOwnAwaitable.Click += new System.EventHandler(this.btnOwnAwaitable_Click);
            // 
            // comboAntal
            // 
            this.comboAntal.FormattingEnabled = true;
            this.comboAntal.Location = new System.Drawing.Point(25, 152);
            this.comboAntal.Name = "comboAntal";
            this.comboAntal.Size = new System.Drawing.Size(86, 21);
            this.comboAntal.TabIndex = 9;
            // 
            // btnSerie
            // 
            this.btnSerie.Location = new System.Drawing.Point(267, 150);
            this.btnSerie.Name = "btnSerie";
            this.btnSerie.Size = new System.Drawing.Size(75, 23);
            this.btnSerie.TabIndex = 10;
            this.btnSerie.Text = "Own i serie";
            this.btnSerie.UseVisualStyleBackColor = true;
            this.btnSerie.Click += new System.EventHandler(this.btnSerie_Click);
            // 
            // btnTcsTask
            // 
            this.btnTcsTask.Location = new System.Drawing.Point(349, 150);
            this.btnTcsTask.Name = "btnTcsTask";
            this.btnTcsTask.Size = new System.Drawing.Size(75, 23);
            this.btnTcsTask.TabIndex = 11;
            this.btnTcsTask.Text = "TCS_task";
            this.btnTcsTask.UseVisualStyleBackColor = true;
            this.btnTcsTask.Click += new System.EventHandler(this.btnTcsTask_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 463);
            this.Controls.Add(this.btnTcsTask);
            this.Controls.Add(this.btnSerie);
            this.Controls.Add(this.comboAntal);
            this.Controls.Add(this.btnOwnAwaitable);
            this.Controls.Add(this.comboActionNoAsync);
            this.Controls.Add(this.comboAction);
            this.Controls.Add(this.btnNoDeadlock);
            this.Controls.Add(this.btnDeadLock);
            this.Controls.Add(this.btnLoop);
            this.Controls.Add(this.btnRensa);
            this.Controls.Add(this.textResultat);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textResultat;
        private System.Windows.Forms.Button btnRensa;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.Button btnDeadLock;
        private System.Windows.Forms.Button btnNoDeadlock;
        private System.Windows.Forms.ComboBox comboAction;
        private System.Windows.Forms.ComboBox comboActionNoAsync;
        private System.Windows.Forms.Button btnOwnAwaitable;
        private System.Windows.Forms.ComboBox comboAntal;
        private System.Windows.Forms.Button btnSerie;
        private System.Windows.Forms.Button btnTcsTask;
    }
}

