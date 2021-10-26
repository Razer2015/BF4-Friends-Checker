namespace BF4_Friends_Checker
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gBox_setup = new System.Windows.Forms.GroupBox();
            this.btn_clear3 = new System.Windows.Forms.Button();
            this.btn_clear2 = new System.Windows.Forms.Button();
            this.btn_clear1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tBox_soldierName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBox_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBox_email = new System.Windows.Forms.TextBox();
            this.gBox_actions = new System.Windows.Forms.GroupBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.gBox_logs = new System.Windows.Forms.GroupBox();
            this.rTBox_logs = new System.Windows.Forms.RichTextBox();
            this.gBox_setup.SuspendLayout();
            this.gBox_actions.SuspendLayout();
            this.gBox_logs.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBox_setup
            // 
            this.gBox_setup.Controls.Add(this.btn_clear3);
            this.gBox_setup.Controls.Add(this.btn_clear2);
            this.gBox_setup.Controls.Add(this.btn_clear1);
            this.gBox_setup.Controls.Add(this.label3);
            this.gBox_setup.Controls.Add(this.tBox_soldierName);
            this.gBox_setup.Controls.Add(this.label2);
            this.gBox_setup.Controls.Add(this.tBox_password);
            this.gBox_setup.Controls.Add(this.label1);
            this.gBox_setup.Controls.Add(this.tBox_email);
            this.gBox_setup.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_setup.Location = new System.Drawing.Point(0, 0);
            this.gBox_setup.Name = "gBox_setup";
            this.gBox_setup.Size = new System.Drawing.Size(693, 102);
            this.gBox_setup.TabIndex = 0;
            this.gBox_setup.TabStop = false;
            this.gBox_setup.Text = "Information";
            // 
            // btn_clear3
            // 
            this.btn_clear3.Location = new System.Drawing.Point(638, 71);
            this.btn_clear3.Name = "btn_clear3";
            this.btn_clear3.Size = new System.Drawing.Size(52, 23);
            this.btn_clear3.TabIndex = 8;
            this.btn_clear3.Tag = "soldiername";
            this.btn_clear3.Text = "Clear";
            this.btn_clear3.UseVisualStyleBackColor = true;
            this.btn_clear3.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_clear2
            // 
            this.btn_clear2.Location = new System.Drawing.Point(638, 43);
            this.btn_clear2.Name = "btn_clear2";
            this.btn_clear2.Size = new System.Drawing.Size(52, 23);
            this.btn_clear2.TabIndex = 7;
            this.btn_clear2.Tag = "password";
            this.btn_clear2.Text = "Clear";
            this.btn_clear2.UseVisualStyleBackColor = true;
            this.btn_clear2.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_clear1
            // 
            this.btn_clear1.Location = new System.Drawing.Point(638, 17);
            this.btn_clear1.Name = "btn_clear1";
            this.btn_clear1.Size = new System.Drawing.Size(52, 23);
            this.btn_clear1.TabIndex = 6;
            this.btn_clear1.Tag = "email";
            this.btn_clear1.Text = "Clear";
            this.btn_clear1.UseVisualStyleBackColor = true;
            this.btn_clear1.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SoldierName (Optional)";
            // 
            // tBox_soldierName
            // 
            this.tBox_soldierName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBox_soldierName.Location = new System.Drawing.Point(147, 73);
            this.tBox_soldierName.Name = "tBox_soldierName";
            this.tBox_soldierName.Size = new System.Drawing.Size(485, 20);
            this.tBox_soldierName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // tBox_password
            // 
            this.tBox_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBox_password.Location = new System.Drawing.Point(147, 45);
            this.tBox_password.Name = "tBox_password";
            this.tBox_password.PasswordChar = '*';
            this.tBox_password.Size = new System.Drawing.Size(485, 20);
            this.tBox_password.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email";
            // 
            // tBox_email
            // 
            this.tBox_email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBox_email.Location = new System.Drawing.Point(147, 19);
            this.tBox_email.Name = "tBox_email";
            this.tBox_email.Size = new System.Drawing.Size(485, 20);
            this.tBox_email.TabIndex = 0;
            // 
            // gBox_actions
            // 
            this.gBox_actions.Controls.Add(this.btn_stop);
            this.gBox_actions.Controls.Add(this.btn_start);
            this.gBox_actions.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_actions.Location = new System.Drawing.Point(0, 102);
            this.gBox_actions.Name = "gBox_actions";
            this.gBox_actions.Size = new System.Drawing.Size(693, 59);
            this.gBox_actions.TabIndex = 1;
            this.gBox_actions.TabStop = false;
            this.gBox_actions.Text = "Actions";
            // 
            // btn_stop
            // 
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stop.Location = new System.Drawing.Point(556, 19);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(131, 23);
            this.btn_stop.TabIndex = 1;
            this.btn_stop.Text = "Stop Checking";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start.Location = new System.Drawing.Point(12, 19);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(131, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start Checking";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // gBox_logs
            // 
            this.gBox_logs.Controls.Add(this.rTBox_logs);
            this.gBox_logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBox_logs.Location = new System.Drawing.Point(0, 161);
            this.gBox_logs.Name = "gBox_logs";
            this.gBox_logs.Size = new System.Drawing.Size(693, 181);
            this.gBox_logs.TabIndex = 2;
            this.gBox_logs.TabStop = false;
            this.gBox_logs.Text = "Logs";
            // 
            // rTBox_logs
            // 
            this.rTBox_logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTBox_logs.Location = new System.Drawing.Point(3, 16);
            this.rTBox_logs.Name = "rTBox_logs";
            this.rTBox_logs.Size = new System.Drawing.Size(687, 162);
            this.rTBox_logs.TabIndex = 0;
            this.rTBox_logs.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 342);
            this.Controls.Add(this.gBox_logs);
            this.Controls.Add(this.gBox_actions);
            this.Controls.Add(this.gBox_setup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Main";
            this.Text = "BF4 Friends Checker by xfileFIN";
            this.gBox_setup.ResumeLayout(false);
            this.gBox_setup.PerformLayout();
            this.gBox_actions.ResumeLayout(false);
            this.gBox_logs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBox_setup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBox_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBox_email;
        private System.Windows.Forms.GroupBox gBox_actions;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.GroupBox gBox_logs;
        private System.Windows.Forms.RichTextBox rTBox_logs;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBox_soldierName;
        private System.Windows.Forms.Button btn_clear3;
        private System.Windows.Forms.Button btn_clear2;
        private System.Windows.Forms.Button btn_clear1;
    }
}

