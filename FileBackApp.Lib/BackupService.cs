using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Timers;
using System.IO.Compression;

namespace FileBackApp.Lib
{
    public class BackupService
    {
        private Timer timerFull;
        private int interval;

        public bool Enabled { get; private set; }
        public string Source { get; set; }
        public string Dir { get; set; }
        public int Time { get; set; }
        public string Units { get; set; }
        public bool Overwrite { get; set; }
        public bool Archive { get; set; }

        public event Action<LogEventArgs> OnLog;
        public event Action<EventArgs> OnStart;
        public event Action<EventArgs> OnStop;

        public BackupService()
        {
            timerFull = new Timer();
            timerFull.Elapsed += TimerFull_Elapsed;
        }

        private void TimerFull_Elapsed(object sender, ElapsedEventArgs e)
        {
            DoBackup();
        }

        private void DoBackup()
        {
            try
            {
                var path = string.Empty;
                var directoryInfo = new DirectoryInfo(Source);
                if (!Overwrite)
                {
                    path = $"{Dir}\\{directoryInfo.Name}-" +
                        $"{DateTime.Now:yyyy.MM.dd.HH.mm.ss}";
                }
                else
                {
                    path = $"{Dir}\\{directoryInfo.Name}";
                    if (Archive)
                    {
                        File.Delete($"{path}.zip");
                    }
                }
                if (Archive)
                {
                    ZipFile.CreateFromDirectory(Source, $"{path}.zip", CompressionLevel.Optimal, false);
                }
                else
                {
                    if (!Directory.Exists(path))
                    {
                        FileSystem.CreateDirectory(path);
                    }
                    FileSystem.CopyDirectory(Source, path, true);
                }
                Log($"Copied {Source} to {path} at {DateTime.Now:HH:mm:ss}", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                Stop();
                Log(ex.Message, ConsoleColor.Red);
            }
        }

        public void Stop()
        {
            timerFull.Stop();
            Enabled = false;
            Log("Backup service stopped.\n", ConsoleColor.DarkGray);
            OnStop?.Invoke(new EventArgs());
        }

        public void Start()
        {
            interval = ConvertTime(Time, Units);
            timerFull.Interval = interval;
            timerFull.Start();
            Enabled = true;
            Log($"Backup service started. Next copy every {Time} {Units.ToLower()}.", ConsoleColor.DarkGray);
            OnStart?.Invoke(new EventArgs());
        }

        private void Log(string message, ConsoleColor color)
        {
            OnLog?.Invoke(new LogEventArgs(message, color));
        }

        public int ConvertTime(int time, string unit)
        {
            var result = 0;
            unit = unit.ToLower();
            switch (unit)
            {
                case "s":
                    result = time * 1000;
                    break;
                case "m":
                    result = time * 60000;
                    break;
                case "h":
                    result = time * 360000;
                    break;
                default:
                    throw new ArgumentException("The time unit is incorrect.");
            }
            return result;
        }
    }
}
