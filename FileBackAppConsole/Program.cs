using FileBackApp.Lib;
using FileBackApp.Lib.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                if (dictionary.ContainsKey(nameof(backupService.Source)))
                {
                    if (string.IsNullOrWhiteSpace(dictionary[nameof(backupService.Source)]))
                    {
                        ColorText("Source folder is required!", ConsoleColor.Red);
                        return;
                    }
                    else if (!Helper.IsDirectoryExists(dictionary[nameof(backupService.Source)]))
                    {
                        ColorText("The source directory does not exist " +
                            "or the path contains invalid characters. Please try again.", ConsoleColor.Red);
                        return;
                    }
                    backupService.Source = dictionary[nameof(backupService.Source)];
                }

                if (dictionary.ContainsKey($"{nameof(backupService.Dir)}"))
                {
                    if (string.IsNullOrWhiteSpace(dictionary[$"{nameof(backupService.Dir)}"]))
                    {
                        backupService.Dir = DefaultDirectory(dictionary[$"{nameof(backupService.Dir)}"]);
                    }
                    else if (!Helper.IsPathValid(dictionary[$"{nameof(backupService.Dir)}"]) ||
                        !Helper.IsDriveExists(dictionary[$"{nameof(backupService.Dir)}"][0].ToString()))
                    {
                        ColorText("The path contains invalid characters. Please try again.", ConsoleColor.Red);
                        return;
                    }
                    else
                    {
                        backupService.Dir = dictionary[$"{nameof(backupService.Dir)}"];
                    }
                }

                if (dictionary.ContainsKey($"{nameof(backupService.Time)}"))
                {
                    if (string.IsNullOrWhiteSpace(dictionary[$"{nameof(backupService.Time)}"]))
                    {
                        backupService.Time = int.Parse(DefaultTime(dictionary[$"{nameof(backupService.Time)}"]));
                    }
                    else if (!Helper.IsNaturalNumber(dictionary[$"{nameof(backupService.Time)}"]))
                    {
                        ColorText("The given time value is not a number" +
                            " or not natural. Please try again.", ConsoleColor.Red);
                        return;
                    }
                    else
                    {
                        backupService.Time = int.Parse(dictionary[$"{nameof(backupService.Time)}"]);
                    }
                }

                if (dictionary.ContainsKey($"{nameof(backupService.Units)}"))
                {
                    if (string.IsNullOrWhiteSpace(dictionary[$"{nameof(backupService.Units)}"]))
                    {
                        backupService.Units = DefaultUnits(dictionary[$"{nameof(backupService.Units)}"]);
                    }
                    else if (!Helper.IsUnit(dictionary[$"{nameof(backupService.Units)}"]))
                    {
                        ColorText("The given value is not valid. Please try again.", ConsoleColor.Red);
                        return;
                    }
                    else
                    {
                        backupService.Units = dictionary[$"{nameof(backupService.Units)}"];
                    }
                }

                if (dictionary.ContainsKey(nameof(backupService.Overwrite)))
                {
                    if (string.IsNullOrWhiteSpace(dictionary[nameof(backupService.Overwrite)]))
                    {
                        backupService.Overwrite = Helper.ConvertBool(DefaultOverwrite(dictionary[nameof(backupService.Overwrite)]));
                    }
                    else if (!Helper.IsBool(dictionary[nameof(backupService.Overwrite)]))
                    {
                        ColorText("The given value is not valid. Please try again.", ConsoleColor.Red);
                        return;
                    }
                    else
                    {
                        backupService.Overwrite = Helper.ConvertBool(dictionary[nameof(backupService.Overwrite)]);
                    }
                }

                if (dictionary.ContainsKey($"{nameof(backupService.Archive)}"))
                {
                    if (string.IsNullOrWhiteSpace(dictionary[$"{nameof(backupService.Archive)}"]))
                    {
                        backupService.Archive = bool.Parse(DefaultArchive(dictionary[$"{nameof(backupService.Archive)}"]));
                    }
                    else if (!Helper.IsBool(dictionary[$"{nameof(backupService.Archive)}"]))
                    {
                        ColorText("The given value is not valid. Please try again.", ConsoleColor.Red);
                        return;
                    }
                    else
                    {
                        backupService.Archive = Helper.ConvertBool(dictionary[$"{nameof(backupService.Archive)}"]);
                    }
                }
            }
            else
            {
                var input = string.Empty;
                while (true)
                {
                    Console.WriteLine($"Source folder. This field is required!");
                    input = Console.ReadLine();
                    input = input.Replace("\"", string.Empty);
                    if (Helper.IsDirectoryExists(input))
                    {
                        break;
                    }
                    else
                    {
                        ColorText("The source directory does not exist " +
                            "or the path contains invalid characters. Please try again.", ConsoleColor.Red);
                    }
                }
                backupService.Source = input;
                input = string.Empty;

                while (true)
                {
                    Console.WriteLine($"Target folder." +
                        $" Press ENTER to set default value Dir={AppDomain.CurrentDomain.BaseDirectory}");
                    input = DefaultDirectory(Console.ReadLine());
                    input = input.Replace("\"", string.Empty);
                    if (Helper.IsPathValid(input) && Helper.IsDriveExists(input[0].ToString()))
                    {
                        break;
                    }
                    else
                    {
                        ColorText("The path contains invalid characters. Please try again.", ConsoleColor.Red);
                    }
                }
                backupService.Dir = input;
                input = string.Empty;

                while (true)
                {
                    Console.WriteLine("Time (natural numbers only). Press ENTER to set default value Time=30");
                    input = DefaultTime(Console.ReadLine());
                    if (Helper.IsNaturalNumber(input))
                    {
                        break;
                    }
                    else
                    {
                        ColorText("The given time value is not a number or not natural. Please try again.", ConsoleColor.Red);
                    }
                }
                backupService.Time = int.Parse(input);
                input = string.Empty;

                while (true)
                {
                    Console.WriteLine("Units (s, m, h). Press ENTER to set default value Units=s");
                    input = DefaultUnits(Console.ReadLine());
                    if (Helper.IsUnit(input))
                    {
                        break;
                    }
                    else
                    {
                        ColorText("The given value is not valid. Please try again.", ConsoleColor.Red);
                    }
                }
                backupService.Units = input;
                input = string.Empty;

                while (true)
                {
                    Console.WriteLine("Overwite (true, false, yes, no). Press ENTER to set default value Overwrite=false");
                    input = DefaultOverwrite(Console.ReadLine());
                    if (Helper.IsBool(input))
                    {
                        break;
                    }
                    else
                    {
                        ColorText("The given value is not valid. Please try again.", ConsoleColor.Red);
                    }
                }
                backupService.Overwrite = Helper.ConvertBool(input);
                input = string.Empty;

                while (true)
                {
                    Console.WriteLine("Archive (true, false, yes, no). Press ENTER to set default value Archive=true");
                    input = DefaultArchive(Console.ReadLine());
                    if (Helper.IsBool(input))
                    {
                        break;
                    }
                    else
                    {
                        ColorText("The given value is not valid. Please try again.", ConsoleColor.Red);
                    }
                }
                backupService.Archive = Helper.ConvertBool(input);
            }

            Console.WriteLine();

            backupService.Start();
            ColorText("Write ENTER to stop the application.", ConsoleColor.DarkGray);
            while (Console.ReadLine() == null)
            {
            }
        }

        private static void ColorText(string message, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = previousColor;
        }

        public static string UseOrDefault(string input, Func<string> defaultValueProvider)
        {
            return string.IsNullOrWhiteSpace(input)
                ? defaultValueProvider()
                : input;
        }

        public static string DefaultDirectory(string input) =>
            UseOrDefault(input, () => AppDomain.CurrentDomain.BaseDirectory);

        public static string DefaultTime(string input) =>
            UseOrDefault(input, () => Settings.Default.Time.ToString());

        public static string DefaultUnits(string input) =>
            UseOrDefault(input, () => Settings.Default.Units);

        public static string DefaultOverwrite(string input) =>
            UseOrDefault(input, () => Settings.Default.Overwrite.ToString());

        public static string DefaultArchive(string input) =>
            UseOrDefault(input, () => Settings.Default.Archive.ToString());
    }
}
