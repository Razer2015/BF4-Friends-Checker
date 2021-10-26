using FriendsCheckerV2.Battlelog;
using FriendsCheckerV2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriendsCheckerV2
{
    public partial class Main : Form
    {
        private readonly bool _bold = false;
        private CancellationTokenSource _tokenSource;
        private CancellationToken _token;

        public Main()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tBox_soldierName.Text))
            {
                WriteWarning("SoldierName can't be empty.");
                return;
            }
            
            StartAsync();
        }

        private async void StartAsync()
        {
            try
            {
                WriteInfo("Starting info retrieving");
                await ExecuteAsync();
            }
            catch (Exception e)
            {
                WriteError(e.Message);
            }
        }

        private Task ExecuteAsync()
        {
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            return Task.Run(() => RetrieveFriends(), _token);
        }

        private void Stop()
        {
            try
            {
                if (_token != null && _token.CanBeCanceled)
                {
                    _tokenSource.Cancel();
                    _tokenSource.Dispose();
                }
            }
            catch (Exception e)
            {
                WriteError(e.Message);
            }
        }

        private void RetrieveFriends()
        {
            try
            {
                var soldierName = tBox_soldierName.Text;
                WriteInfo($"Attempting to fetch friends list of user {soldierName}");
                var result = BattlelogClient.GetFriends(soldierName);

                if (result?.Context?.Friends == null)
                {
                    WriteError("Couldn't fetch the friends list. The user needs to have friends visible to everyone.");
                    return;
                }

                WriteInfo($"{result.Context.Friends.Count()} to fetch.");

                var friendsResponse = BattlelogClient.GetUsersByUserIds(result.Context.Friends.Select(x => x.UserId).ToArray(), DashKind.Light);
                if (!friendsResponse.Type.Equals("success"))
                {
                    WriteError($"Fetch failed: {friendsResponse.Message}");
                    return;
                }
                WriteInfo($"Fetch success: {friendsResponse.Message}");
                WriteInfo($"{friendsResponse.Data.Count()}/{result.Context.Friends.Count()} fetched");

                var missing = result.Context.Friends.Where(x => !friendsResponse.Data.Any(y => y.Value.UserId == x.UserId));
                foreach (var user in missing)
                {
                    WriteError($"Missing user: {user.UserId} | {user.User.Username}");
                }

                new Friends_BF4(friendsResponse.Data.Select(x => x.Value).ToArray()).ShowDialog();
            }
            catch (ApplicationException appEx)
            {
                WriteError(appEx.Message);
                MessageBox.Show(appEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #region Logging
        private void WriteInfo(string info)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(WriteInfo), new object[] { info });
                return;
            }
            this.rTBox_logs.AppendWithTime($"{info}\r\n", logType: LogType.INFORMATION, bold: _bold);
        }

        private void WriteWarning(string warning)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(WriteWarning), new object[] { warning });
                return;
            }
            this.rTBox_logs.AppendWithTime($"{warning}\r\n", logType: LogType.WARNING, bold: _bold);
        }

        private void WriteError(string error)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(WriteError), new object[] { error });
                return;
            }
            this.rTBox_logs.AppendWithTime($"{error}\r\n", logType: LogType.ERROR, bold: _bold);
        }

        private void OneLineUp()
        {
            if (InvokeRequired)
            {
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
    }
}
