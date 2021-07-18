using System;
using System.Collections.Generic;

namespace Main.Patterns.Strings
{
    public class ValidIPAddress
    {
        public static void Execute()
        {
            //ValidIPAddressImpl("2001:0db8:85a3:0:0:8A2E:0370:7334");
            Console.WriteLine(ValidIPAddressImpl("2001:0db8:85a3:0:0:8A2E:0370:7334"));
        }

        public static string IsValidIPv4Address(string[] parts)
        {
            if (parts.Length != 4)
            {
                return "Neither";
            }

            foreach (var p in parts)
            {
                if (int.TryParse(p, out var num))
                {
                    if (!(num >= 0 && num <= 255 && num.ToString() == p))
                    {
                        return "Neither";
                    }
                }
                else
                {
                    return "Neither";
                }
            }

            return "IPv4";
        }

        private static ISet<char> validHexSet = new HashSet<char>(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' });

        public static string IsValidIPv6Address(string[] parts)
        {
            if (parts.Length != 8)
            {
                return "Neither";
            }

            bool IsAllHex(string hex)
            {
                foreach (var ch in hex)
                {
                    if (!validHexSet.Contains(char.ToLower(ch)))
                    {
                        return false;
                    }
                }

                return true;
            }

            foreach (var p in parts)
            {
                if (p.Length > 4 || p.Length < 1)
                {
                    return "Neither";
                }

                if (!IsAllHex(p))
                {
                    return "Neither";
                }
            }

            return "IPv6";
        }

        public static string ValidIPAddressImpl(string IP)
        {
            var isValid = "Neither";
            var parts = IP.Split('.');

            if (parts.Length == 0)
            {
                parts = IP.Split(':');
                if (parts.Length == 0)
                {
                    return isValid;
                }
                else
                {
                    isValid = IsValidIPv6Address(parts);
                }
            }
            else
            {
                isValid = IsValidIPv4Address(parts);
            }

            return isValid;
        }
    }
}
