using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Decripter
{
    class Md5Decripter
    {
        //volgorde volgens nederlands meest voorkomend woordenboek
        string[] DutchLetterUse = { "e", "n", "a", "t", "i", "r", "o", "d", "s", "l", "g", "v", "h", "k", "m", "u", "b", "p", "w", "j", "z", "c", "f", "x", "y", "q", "E", "N", "A", "T", "I", "R", "O", "D", "S", "L", "G", "V", "H", "K", "M", "U", "B", "P", "W", "J", "Z", "C", "F", "X", "Y", "Q", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public Md5Decripter()
        {
        }

        public string decript(string md5hash)
        {
            return decriptL3(md5hash, "", 4);
        }

        private string decriptL3(string md5hash, string first, int total)
        {
            MD5 md5 = MD5.Create();
            foreach (string item in DutchLetterUse)
            {
                string buffer = first + item;
                if (total == 1)
                {
                    string cash = GetMd5Hash(md5, buffer);

                    if (md5hash.Equals(cash))
                    {
                        return buffer;
                    }
                }
                else if (total > 1)
                {
                    string result = decriptL3(md5hash, buffer, total - 1);

                    if (!result.Equals(""))
                    {
                        return result;
                    }
                }
            }
            return "";
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
    }
}
