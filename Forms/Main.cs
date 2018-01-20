using Authentication;
using BF4_Friends_Checker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BF4_Friends_Checker
{
    public partial class Main : Form
    {
        bool Bold = false;
        Auth authentication = new Auth();
        CancellationTokenSource tokenSource;
        CancellationToken token;

        public Main() {
            InitializeComponent();

            // Load settings from memory (if previously used)
            tBox_email.Text = Properties.Settings.Default.Email;
            tBox_password.Text = Properties.Settings.Default.Password;
            tBox_soldierName.Text = Properties.Settings.Default.SoldierName;
        }

        #region Actions
        public async void StartAsync() {
            try {
                WriteInfo("Starting info retrieving");
                await ExecuteAsync();
            }
            catch (Exception e) {
                WriteError(e.Message);
            }
        }

        private Task ExecuteAsync() {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            return Task.Run(() => RetrieveFriends(), token);
        }

        public void Stop() {
            try {
                if (token != null && token.CanBeCanceled) {
                    tokenSource.Cancel();
                    tokenSource.Dispose();
                }
            }
            catch (Exception e) {
                WriteError(e.Message);
            }
        }

        private void RetrieveFriends() {
            List<Friend> friends = new List<Friend>();
            try {
                var soldierName = (!string.IsNullOrEmpty(tBox_soldierName.Text) ? tBox_soldierName.Text : authentication.SoldierName);
                WriteInfo($"Attempting to fetch friends list of user {soldierName}");
                var result = authentication.GetFriends(soldierName);

                if (result?.context?.friends == null) {
                    WriteError("Couldn't fetch the friends list. The user needs to either have friends visible to everyone or you need to login.");
                    return;
                }

                WriteInfo($"{result.context.friends.Count()} to fetch.");
                WriteInfo($"0/{result.context.friends.Count()} fetched");
                int index = 1;
                foreach (var user in result.context.friends) {
                    var friendInfo = authentication.GetFriend(user.user.username);
                    if (friendInfo == null) {
                        WriteError($"Unable to fetch user {user.user.username}");
                        continue;
                    }
                    friends.Add(new Friend() {
                        user = friendInfo?.context?.profileCommon?.user ?? null,
                        friendCount = friendInfo?.context?.profileCommon?.friendCount ?? 0,
                        userinfo = friendInfo?.context?.profileCommon?.userinfo ?? null,
                    });
                    OneLineUp();
                    WriteInfo($"{index}/{result.context.friends.Count()} fetched");
                    index++;

                    if (token == null || (token != null && token.IsCancellationRequested)) {
                        WriteInfo($"Friends retrieving stopped.");
                        break;
                    }
                }

                new Friends_BF4(friends.ToArray()).ShowDialog();
            }
            catch (ApplicationException appEx) {
                WriteError(appEx.Message);
                MessageBox.Show(appEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region Logging
        private void WriteInfo(string info) {
            if (InvokeRequired) {
                this.Invoke(new Action<string>(WriteInfo), new object[] { info });
                return;
            }
            this.rTBox_logs.AppendWithTime($"{info}\r\n", logType: LogType.INFORMATION, bold: Bold);
        }

        private void WriteWarning(string warning) {
            if (InvokeRequired) {
                this.Invoke(new Action<string>(WriteWarning), new object[] { warning });
                return;
            }
            this.rTBox_logs.AppendWithTime($"{warning}\r\n", logType: LogType.WARNING, bold: Bold);
        }

        private void WriteError(string error) {
            if (InvokeRequired) {
                this.Invoke(new Action<string>(WriteError), new object[] { error });
                return;
            }
            this.rTBox_logs.AppendWithTime($"{error}\r\n", logType: LogType.ERROR, bold: Bold);
        }

        private void OneLineUp() {
            if (InvokeRequired) {
                this.Invoke(new Action(OneLineUp), null);
                return;
            }
            //this.rTBox_logs.Lines = this.rTBox_logs.Lines.Take(this.rTBox_logs.Lines.Count() - 2).ToArray();

            rTBox_logs.SelectionStart = rTBox_logs.GetFirstCharIndexFromLine(this.rTBox_logs.Lines.Length - 2);
            rTBox_logs.SelectionLength = this.rTBox_logs.Lines[this.rTBox_logs.Lines.Length - 2].Length + 1;
            this.rTBox_logs.SelectedText = String.Empty;

            //this.rTBox_logs.AppendText("\r\n");
        }
        #endregion

        #region Events
        private void btn_start_Click(object sender, EventArgs e) {
            try {
                authentication = new Auth();
                if (!string.IsNullOrEmpty(tBox_email.Text) && !string.IsNullOrEmpty(tBox_password.Text)) {
                    authentication.Login(tBox_email.Text, tBox_password.Text, Properties.Settings.Default._nx_mpcid);
                    authentication.RetrieveInfo();
                    Properties.Settings.Default._nx_mpcid = (!string.IsNullOrEmpty(authentication.SecondFactoryAuthToken) ? authentication.SecondFactoryAuthToken : Properties.Settings.Default._nx_mpcid);
                    Properties.Settings.Default.Save();
                    WriteInfo($"Logged in succesfully as {authentication.SoldierName} ({authentication.PersonaId})");
                }
                else {
                    WriteInfo("No login info provided, skipping login.");
                }
            }
            catch (Exception ex) {
                WriteError(ex.Message);
                MessageBox.Show(ex.Message, "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save settings for next time
            if (!string.IsNullOrEmpty(tBox_email.Text)) {
                Properties.Settings.Default.Email = tBox_email.Text;
            }
            if (!string.IsNullOrEmpty(tBox_password.Text)) {
                Properties.Settings.Default.Password = tBox_password.Text;
            }
            if (!string.IsNullOrEmpty(tBox_soldierName.Text)) {
                Properties.Settings.Default.SoldierName = tBox_soldierName.Text;
            }
            Properties.Settings.Default.Save();

            if ((!string.IsNullOrEmpty(tBox_email.Text) &&
                !string.IsNullOrEmpty(tBox_password.Text)) ||
                !string.IsNullOrEmpty(tBox_soldierName.Text)) { // If either login info or soldiername is provided (or both)
                StartAsync();
            }
        }

        private void btn_stop_Click(object sender, EventArgs e) {
            Stop();
        }

        private void btn_clear_Click(object sender, EventArgs e) {
            var btn = sender as Button;
            switch ((string)btn.Tag) {
                case "email":
                    tBox_email.Text = string.Empty;
                    Properties.Settings.Default.Email = tBox_email.Text;
                    break;
                case "password":
                    tBox_password.Text = string.Empty;
                    Properties.Settings.Default.Password = tBox_password.Text;
                    break;
                case "soldiername":
                    tBox_soldierName.Text = string.Empty;
                    Properties.Settings.Default.SoldierName = tBox_soldierName.Text;
                    break;
            }
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
