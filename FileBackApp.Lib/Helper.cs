using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBackApp.Lib
{
    public class Helper
    {
        public static bool IsPathValid(string path)
        {
            return Path.IsPathRooted(path);
        }
        public static bool IsDriveExists(string name)
        {
            return Directory.Exists($"{name}:\\");
        }

        public static bool IsDirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public static bool IsNaturalNumber(string value)
        {
            var isNumber = int.TryParse(value, out int result);
            return result > 0;
        }

        public static bool IsUnit(string value)
        {
            value = value.ToLower();
            return value == "s" || value == "m" || value == "h";
        }

        public static bool IsBool(string value)
        {
            value = value.ToLower();
            return value.ToString() == "y" || value.ToString() == "n" ||
                value.ToString() == "yes" || value.ToString() == "no" ||
                value.ToString() == "t" || value.ToString() == "f" ||
                value.ToString() == "true" || value.ToString() == "false";
        }

        public static bool ConvertBool(string value)
        {
            value = value.ToLower();
            if (IsBool(value))
            {
                return value[0].ToString() == "y" || value[0].ToString() == "t";
            }
            throw new ArgumentException("Value is not acceptable");
        }
    }
}
