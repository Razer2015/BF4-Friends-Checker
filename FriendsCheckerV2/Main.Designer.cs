
namespace FriendsCheckerV2
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
            this.gBox_setup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBox_soldierName = new System.Windows.Forms.TextBox();
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
            this.gBox_setup.Controls.Add(this.label3);
            this.gBox_setup.Controls.Add(this.tBox_soldierName);
            this.gBox_setup.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_setup.Location = new System.Drawing.Point(0, 0);
            this.gBox_setup.Name = "gBox_setup";
            this.gBox_setup.Size = new System.Drawing.Size(800, 46);
            this.gBox_setup.TabIndex = 1;
            this.gBox_setup.TabStop = false;
            this.gBox_setup.Text = "Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SoldierName";
            // 
            // tBox_soldierName
            // 
            this.tBox_soldierName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBox_soldierName.Location = new System.Drawing.Point(82, 13);
            this.tBox_soldierName.Name = "tBox_soldierName";
            this.tBox_soldierName.Size = new System.Drawing.Size(712, 20);
            this.tBox_soldierName.TabIndex = 4;
            // 
            // gBox_actions
            // 
            this.gBox_actions.Controls.Add(this.btn_stop);
            this.gBox_actions.Controls.Add(this.btn_start);
            this.gBox_actions.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_actions.Location = new System.Drawing.Point(0, 46);
            this.gBox_actions.Name = "gBox_actions";
            this.gBox_actions.Size = new System.Drawing.Size(800, 59);
            this.gBox_actions.TabIndex = 2;
            this.gBox_actions.TabStop = false;
            this.gBox_actions.Text = "Actions";
            // 
            // btn_stop
            // 
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stop.Location = new System.Drawing.Point(657, 19);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(131, 23);
            this.btn_stop.TabIndex = 1;
            this.btn_stop.Text = "Stop Checking";
            this.btn_stop.UseVisualStyleBackColor = true;
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
            this.gBox_logs.Location = new System.Drawing.Point(0, 105);
            this.gBox_logs.Name = "gBox_logs";
            this.gBox_logs.Size = new System.Drawing.Size(800, 345);
            this.gBox_logs.TabIndex = 3;
            this.gBox_logs.TabStop = false;
            this.gBox_logs.Text = "Logs";
            // 
            // rTBox_logs
            // 
            this.rTBox_logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTBox_logs.Location = new System.Drawing.Point(3, 16);
            this.rTBox_logs.Name = "rTBox_logs";
            this.rTBox_logs.Size = new System.Drawing.Size(794, 326);
            this.rTBox_logs.TabIndex = 0;
            this.rTBox_logs.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gBox_logs);
            this.Controls.Add(this.gBox_actions);
            this.Controls.Add(this.gBox_setup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Main";
            this.Text = "BF4 Friends checker by xfileFIN";
            this.gBox_setup.ResumeLayout(false);
            this.gBox_setup.PerformLayout();
            this.gBox_actions.ResumeLayout(false);
            this.gBox_logs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBox_setup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBox_soldierName;
        private System.Windows.Forms.GroupBox gBox_actions;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.GroupBox gBox_logs;
        private System.Windows.Forms.RichTextBox rTBox_logs;
    }
}

