using System.Configuration;

namespace FileObserver
{
    public static class Settings
    {
        public static string ObservedFolder => ConfigurationManager.AppSettings["ObservedFolder"];
        public static string LogFile => ConfigurationManager.AppSettings["LogFile"];
    }
}
