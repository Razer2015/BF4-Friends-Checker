using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FriendsCheckerV2.Models;

namespace FriendsCheckerV2
{
    public partial class Friends_BF4 : Form
    {
        private ListViewColumnSorter sorter;
        bool sorted = false;

        public Friends_BF4(DashUser[] friends) {
            InitializeComponent();

            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            sorter = new ListViewColumnSorter();
            this.lView_friends.ListViewItemSorter = sorter;

            AddHeaders(ref this.lView_friends);

            //sorter.Order = SortOrder.Descending;
            //sorter.SortColumn = 10;

            GenerateLView(this.lView_friends, friends);
        }

        void AddHeaders(ref ListView lView) {
            // Set the view to show details.
            lView.View = View.Details;
            // Allow the user to edit item text.
            lView.LabelEdit = true;
            // Show item tooltips.
            lView.ShowItemToolTips = true;
            // Allow the user to rearrange columns.
            //lView.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            lView.FullRowSelect = true;
            // Display grid lines.
            lView.GridLines = true;

            lView.Columns.Add("Index");
            lView.Columns.Add("Username");
            lView.Columns.Add("Account Created");
            lView.Columns.Add("Last Update");
            lView.Columns.Add("Last Login");
            lView.Columns.Add("Timespan");

            lView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        void GenerateLView(ListView lView, DashUser[] data) {
            if (InvokeRequired) {
                Invoke((MethodInvoker)delegate { this.GenerateLView(lView, data); });
                return;
            }

            lView.BeginUpdate();
            lView.Items.Clear();
            List<ListViewItem> items = new List<ListViewItem>();
            int playerIndex = 1;
            var dateNow = DateTime.Now;
            for (int i = 0; i < data.Length; i++) {
                var item = new ListViewItem(playerIndex.ToString());
                item.SubItems.Add(data[i].User.Username);

                var _createdAt = FromUnixTime(data[i]?.User?.CreatedAt ?? 0);
                var _updatedAt = FromUnixTime(data[i]?.Presence?.UpdatedAt ?? 0);
                var _lastLogin = FromUnixTime(data[i]?.Info?.LastLogin ?? 0);
                var _since = FromUnixTime(DateTimeOffset.UtcNow.ToUnixTimeSeconds() - (data[i]?.Info?.LastLogin ?? 0));

                var createdAt = (_createdAt.Ticks <= 621355968000000000) ? "Couldn't fetch" : $"{(_createdAt.Day):00}.{(_createdAt.Month):00}.{(_createdAt.Year)} {(_createdAt.Hour):00}:{(_createdAt.Minute):00}:{(_createdAt.Second):00}";
                var updatedAt = (_updatedAt.Ticks <= 621355968000000000) ? "Couldn't fetch" : $"{(_updatedAt.Day):00}.{(_updatedAt.Month):00}.{(_updatedAt.Year)} {(_updatedAt.Hour):00}:{(_updatedAt.Minute):00}:{(_updatedAt.Second):00}";
                var lastLogin = (_lastLogin.Ticks <= 621355968000000000) ? "Couldn't fetch" : $"{(_lastLogin.Day):00}.{(_lastLogin.Month):00}.{(_lastLogin.Year)} {(_lastLogin.Hour):00}:{(_lastLogin.Minute):00}:{(_lastLogin.Second):00}";
                var since = (_lastLogin.Ticks <= 621355968000000000) ? "Couldn't calculate" : new Rf.Sites.Frame.PeriodOfTimeOutput(_lastLogin).ToString();

                item.SubItems.Add(new ListViewItem.ListViewSubItem() 
                {
                    Text = createdAt,
                    Tag = _createdAt
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() 
                {
                    Text = updatedAt,
                    Tag = _updatedAt
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() 
                {
                    Text = lastLogin,
                    Tag = _lastLogin
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() {
                    Text = since,
                    Tag = _since
                });
                items.Add(item);
                playerIndex++;
            }
            lView.Items.AddRange(items.ToArray());

            lView.EndUpdate();

            lView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private int GetEpochSeconds(DateTime date) {
            TimeSpan t = date - new DateTime(1970, 1, 1);
            return (int)t.TotalSeconds;
        }

        private DateTime FromUnixTime(long unixTime) {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        private string PeriodOfTimeOutput(TimeSpan tspan, int level = 0) {
            string how_long_ago = "ago";
            if (level >= 2) return how_long_ago;
            if (tspan.Days > 1)
                how_long_ago = string.Format("{0} Days ago", tspan.Days);
            else if (tspan.Days == 1)
                how_long_ago = string.Format("1 Day {0}", PeriodOfTimeOutput(new TimeSpan(tspan.Hours, tspan.Minutes, tspan.Seconds), level + 1));
            else if (tspan.Hours >= 1)
                how_long_ago = string.Format("{0} {1} {2}", tspan.Hours, (tspan.Hours > 1) ? "Hours" : "Hour", PeriodOfTimeOutput(new TimeSpan(0, tspan.Minutes, tspan.Seconds), level + 1));
            else if (tspan.Minutes >= 1)
                how_long_ago = string.Format("{0} {1} {2}", tspan.Minutes, (tspan.Minutes > 1) ? "Minutes" : "Minute", PeriodOfTimeOutput(new TimeSpan(0, 0, tspan.Seconds), level + 1));
            else if (tspan.Seconds >= 1)
                how_long_ago = string.Format("{0} {1} ago", tspan.Seconds, (tspan.Seconds > 1) ? "Seconds" : "Second");
            return how_long_ago;
        }

        private void lView_friends_ColumnClick(object sender, ColumnClickEventArgs e) {
            lView_friends.BeginUpdate();
            // If columns are already sorted atleast once
            if (sorted) {
                lView_friends.Columns[sorter.SortColumn].Text = lView_friends.Columns[sorter.SortColumn].Text.Remove(lView_friends.Columns[sorter.SortColumn].Text.Length - 2);
            }
            else
                sorted = true;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == sorter.SortColumn) {
                // Reverse the current sort direction for this column.
                if (sorter.Order == SortOrder.Ascending) {
                    sorter.Order = SortOrder.Descending;
                    lView_friends.Columns[sorter.SortColumn].Text += " ▼";
                }
                else {
                    sorter.Order = SortOrder.Ascending;
                    lView_friends.Columns[sorter.SortColumn].Text += " ▲";
                }
            }
            else {
                // Set the column number that is to be sorted; default to ascending.
                sorter.SortColumn = e.Column;
                sorter.Order = SortOrder.Ascending;
                lView_friends.Columns[sorter.SortColumn].Text += " ▲";
            }

            // Perform the sort with these new sort options.
            this.lView_friends.Sort();
            lView_friends.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lView_friends.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lView_friends.EndUpdate();
        }
    }
}
