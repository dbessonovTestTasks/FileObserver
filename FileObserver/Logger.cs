using System.IO;
using System.Text;
using System.Threading;

namespace FileObserver
{
    internal static class Logger
    {
        private static object _logFile = new object();
        public static void Log(string fileName, string operationName, string result)
        {
            //но нет никаких гарантий, что запись будет произведена, поскольку файл чем угодно может быть блокирован
            //в реальной задаче подключил бы nlog или log4net
            lock (_logFile)
            {
                bool success = false;
                var attemptCount = 0;

                while (!success && attemptCount < 120)
                {
                    try
                    {
                        using (var writer = new StreamWriter(Settings.LogFile, true, Encoding.UTF8))
                        {
                            writer.WriteLine($"{fileName}-{operationName}-{result}");
                            writer.Close();
                        }
                        success = true;
                    }
                    catch (IOException ex)
                    {
                        attemptCount++;
                        Thread.Sleep(500);
                    }
                }
            }
        }
    }
}
