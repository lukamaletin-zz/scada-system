namespace SCADACommon
{
    public static class ScadaConstants
    {
        private const string ServerIp = "192.168.0.15"; // Type ipconfig in command prompt and copy IPv4 address
        public const string DatabaseManagerUri = "net.tcp://" + ServerIp + ":8081/IDatabaseManager";
        public const string AlarmUri = "net.tcp://" + ServerIp + ":8082/IAlarm";
        public const string TrendingUri = "net.tcp://" + ServerIp + ":8083/ITrending";
        public const string AlarmsLogPath = "alarmsLog.txt";
        public const string ConfigPath = "scadaConfig.xml";
    }
}