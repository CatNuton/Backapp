using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBackApp.Lib;

namespace FileBackAppConsole
{
    internal class Program
    {
        private static Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private static BackupService backupService = new BackupService();

        static void Main(string[] args)
        {
            backupService.OnLog += (e) =>
            {
                ColorText(e.Message, e.Color);
            };
            var input = "";
            if (args.Length > 0)
            {
                foreach (var arg in args)
                {
                    var parts = arg.Split(new char[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        var key = parts[0].TrimStart('-', '/');
                        var value = parts[1].Trim('"');
                        dictionary[key] = value;
                    }
                }

                backupService.Source = dictionary.ContainsKey(
                    $"{nameof(backupService.Source)}") ? dictionary[$"{nameof(backupService.Source)}"] : "";
                if (string.IsNullOrWhiteSpace(backupService.Source))
                {
                    ColorText("Source folder is required!", ConsoleColor.Red);
                    return;
                }

                backupService.Dir = dictionary.ContainsKey(
                    $"{nameof(backupService.Dir)}") &&
                    !string.IsNullOrWhiteSpace(dictionary[$"{nameof(backupService.Dir)}"])
                    ? dictionary[$"{nameof(backupService.Dir)}"] : DefaultDirectory(dictionary[$"{nameof(backupService.Dir)}"]);

                backupService.Time = dictionary.ContainsKey(
                    $"{nameof(backupService.Time)}") &&
                    int.TryParse(dictionary[$"{nameof(backupService.Time)}"], out int t) ? t : int.Parse(DefaultTime(input));

                backupService.Units = dictionary.ContainsKey(
                    $"{nameof(backupService.Units)}") &&
                    !string.IsNullOrWhiteSpace(backupService.Units)
                    ? dictionary[$"{nameof(backupService.Units)}"] : DefaultUnits(input);

                backupService.Overwrite = dictionary.ContainsKey(
                    $"{nameof(backupService.Overwrite)}")
                    && bool.TryParse(dictionary[$"{nameof(backupService.Overwrite)}"], out bool b) ? b :
                    bool.Parse(DefaultOverwrite(backupService.Overwrite.ToString()));

                backupService.Archive = dictionary.ContainsKey(
                    $"{nameof(backupService.Archive)}")
                    && bool.TryParse(dictionary[$"{nameof(backupService.Archive)}"], out bool a) ? a : 
                    bool.Parse(DefaultArchive(backupService.Archive.ToString()));
            }
            else
            {
                System.Console.WriteLine($"Source folder. This field is required!");
                input = System.Console.ReadLine();
                backupService.Source = input;

                System.Console.WriteLine($"Target folder. Press ENTER to set default value Dir={AppDomain.CurrentDomain.BaseDirectory}");
                input = DefaultDirectory(System.Console.ReadLine());
                backupService.Dir = input;

                System.Console.Write("Time (numbers only). Press ENTER to set default value Time=30");
                input = DefaultTime(System.Console.ReadLine());
                backupService.Time = int.Parse(input);//

                System.Console.Write("Units (s, m, h). Press ENTER to set default value Units=s");
                input = DefaultUnits(System.Console.ReadLine());
                backupService.Units = input;

                System.Console.Write("Overwite (true, false). Press ENTER to set default value Overwrite=false");
                input = DefaultOverwrite(System.Console.ReadLine());
                backupService.Overwrite = bool.Parse(input);//

                System.Console.Write("Archive (true, false). Press ENTER to set default value Archive=true");
                input = DefaultArchive(System.Console.ReadLine());
                backupService.Archive = bool.Parse(input);//
            }

            System.Console.WriteLine();

            backupService.Start();
            ColorText("Write ENTER to stop the application.", ConsoleColor.DarkGray);
            while (System.Console.ReadLine() == null)
            {
            }
        }

        private static void ColorText(string message, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(message);
            System.Console.ResetColor();
        }

        public static string DefaultDirectory(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                input = AppDomain.CurrentDomain.BaseDirectory;
            }
            return input;
        }

        public static string DefaultTime(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                input = FileBackApp.Lib.Properties.Settings.Default.Time.ToString();
            }
            return input;
        }

        public static string DefaultUnits(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                input = FileBackApp.Lib.Properties.Settings.Default.Units;
            }
            return input;
        }

        public static string DefaultOverwrite(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                input = FileBackApp.Lib.Properties.Settings.Default.Overwrite.ToString();
            }
            return input;
        }

        public static string DefaultArchive(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                input = FileBackApp.Lib.Properties.Settings.Default.Archive.ToString();
            }
            return input;
        }
    }
}
