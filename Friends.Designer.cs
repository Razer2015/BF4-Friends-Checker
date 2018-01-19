namespace BF4_Friends_Checker
{
    partial class Friends
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lView_friends = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lView_friends
            // 
            this.lView_friends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lView_friends.Location = new System.Drawing.Point(0, 24);
            this.lView_friends.Name = "lView_friends";
            this.lView_friends.Size = new System.Drawing.Size(802, 645);
            this.lView_friends.TabIndex = 1;
            this.lView_friends.UseCompatibleStateImageBehavior = false;
            this.lView_friends.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lView_friends_ColumnClick);
            // 
            // Friends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 669);
            this.Controls.Add(this.lView_friends);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Friends";
            this.Text = "Battlelog Friends";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListView lView_friends;
    }
}