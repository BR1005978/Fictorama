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
        public static Tuple<string, int> Encryptpassword(string a, int decrypt = -1)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] alphabet2 = new char[] { 'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','Q','Y','Z'};
            string b = "";
            Random rnd = new Random();
            int shift = rnd.Next(26);
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsLetter(a[i]) && Char.IsLower(a[i]))
                {
                    int y = 0;
                    int x = FindIndex(a[i], alphabet);
                    if (decrypt < 0)
                    {
                        y = Shifter(x, shift);
                    }
                    else
                    {
                        y = Shifter(x, decrypt);
                    }

                    b += alphabet[y];
                }
                else if(Char.IsLetter(a[i]) && Char.IsUpper(a[i]))
                {
                    int y = 0;
                    int x = FindIndex(a[i], alphabet2);
                    if (decrypt < 0)
                    {
                        y = Shifter(x, shift);
                    }
                    else
                    {
                        y = Shifter(x, decrypt);
                    }

                    b += alphabet2[y];
                }
                else
                {
                    b += a[i];
                }
            }
            return new Tuple<string, int>(b, shift);
        }
    }
}
