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
                backupService.Target = dictionary.ContainsKey(
                    $"{nameof(backupService.Target)}") ? dictionary[$"{nameof(backupService.Target)}"] : "";
                backupService.Interval = dictionary.ContainsKey(
                    $"{nameof(backupService.Interval)}") &&
                    int.TryParse(dictionary[$"{nameof(backupService.Interval)}"], out int t) ? t : 0;
                backupService.Units = dictionary.ContainsKey(
                    $"{nameof(backupService.Units)}") ? dictionary[$"{nameof(backupService.Units)}"] : "";
                backupService.Overwrite = dictionary.ContainsKey(
                    $"{nameof(backupService.Overwrite)}")
                    && bool.TryParse(dictionary[$"{nameof(backupService.Overwrite)}"], out bool o) ? o : false;
                backupService.Archive = dictionary.ContainsKey(
                    $"{nameof(backupService.Archive)}")
                    && bool.TryParse(dictionary[$"{nameof(backupService.Archive)}"], out bool a) ? a : false;
            }
            else
            {
                Console.Write("Source folder: ");
                backupService.Source = Console.ReadLine();
                backupService.IsDirectoryExists();
                Console.Write("Target folder: ");
                backupService.Target = Console.ReadLine();
                backupService.IsPathValid();
                Console.Write("Time (numbers only): ");
                backupService.Interval = int.Parse(Console.ReadLine());
                Console.Write("Units (s, m, h): ");
                backupService.Units = Console.ReadLine();
                Console.Write("Overwite (true, false): ");
                backupService.Overwrite = bool.Parse(Console.ReadLine());
                Console.Write("Archive (true, false): ");
                backupService.Archive = bool.Parse(Console.ReadLine());
            }

            Console.WriteLine();

            backupService.Start();
            ColorText("Write s to stop the application.", ConsoleColor.DarkGray);
            while (Console.ReadLine() == "s")
            {
                return;
            }
        }

        private static void ColorText(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
