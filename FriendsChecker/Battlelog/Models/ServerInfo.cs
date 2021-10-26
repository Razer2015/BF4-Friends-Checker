namespace Battlelog.Models
{
    public class ServerInfo
    {
        public long lastUpdated { get; set; }
        public Snapshot snapshot { get; set; }

        public ServerInfo() {
            snapshot = new Snapshot();
        }

        public ServerInfo(ServerInfo info) {
            this.lastUpdated = info.lastUpdated;
            this.snapshot = new Snapshot(info.snapshot);
        }
    }
}