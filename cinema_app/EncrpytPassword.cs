using System;
using System.Collections.Generic;
using System.Text;

namespace cinema_app
{
    class EncrpytPassword
    {
        public static int Shifter(int a, int b)
        {
            for (int i = 0; i < b; i++)
            {
                if (a < 25)
                {
                    a++;
                }
                else
                {
                    a = 0;
                }
            }
            return a;
        }
        public static int FindIndex(char a, char[] b)
        {
            for (int i = 0; i < 26; i++)
            {
                if (a == b[i])
                {
                    return i;
                }
            }
            return 1;
        }
        public static Tuple<string, int> Encryptpassword(string a)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            a = a.ToLower();
            string b = "";
            Random rnd = new Random();
            int shift = rnd.Next(26);
            for (int i = 0; i < a.Length; i++)
            {
                int x = FindIndex(a[i], alphabet);
                int y = Shifter(x, shift);
                b += alphabet[y];
            }
            return new Tuple<string, int>(b, shift);
        }
    }
}
