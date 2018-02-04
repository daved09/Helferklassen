using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul
{
    public static class Encryption
    {

        public static string encrypt(this string text, int basis)
        {
            char[] zeichen = text.ToCharArray();
            string entext = "";
            int wert;
            for(int i = 0; i < zeichen.Length; i++)
            {
                wert = (int)(zeichen[i] + basis);
                entext += (char) wert;
            }
            return entext;
        }

        public static string decrypt(this string text, int basis)
        {
            char[] zeichen = text.ToCharArray();
            string entext = "";
            int wert;
            for (int i = 0; i < zeichen.Length; i++)
            {
                wert = (int)(zeichen[i] - basis);
                entext += (char)wert;
            }
            return entext;
        }

        public static string polyEncrypt(this string input, string key)
        {
            Random random = new Random();
            int num = 0;
            char[] array = input.ToCharArray();
            char[] array2 = key.ToCharArray();
            char[] array3 = new char[input.Length + 1];
            int num2 = random.Next(100, 220);
            for (int i = 0; i < input.Length; i++)
            {
                if (num >= array2.Length)
                {
                    num = 0;
                }
                int num3 = (int)array[i];
                int num4 = (int)array2[num];
                int value = num3 + num4 + num2;
                array3[i] = Convert.ToChar(value);
                num++;
            }
            array3[input.Length] = (char)num2;
            return new string(array3);
        }

        public static string polyDecrypt(this string input, string key)
        {
            char[] array = input.ToCharArray();
            char[] array2 = key.ToCharArray();
            char[] array3 = new char[input.Length - 1];
            int num = (int)array[input.Length - 1];
            array[input.Length - 1] = '\0';
            int num2 = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (i < input.Length - 1)
                {
                    if (num2 >= array2.Length)
                    {
                        num2 = 0;
                    }
                    int num3 = (int)array[i];
                    int num4 = (int)array2[num2];
                    int value = num3 - num - num4;
                    array3[i] = Convert.ToChar(value);
                    num2++;
                }
            }
            return new string(array3);
        }

        public static string genText(int maxZeichen, int ober, int unter)
        {
            Random rand = new Random();
            string text = "";
            int zeichenwert;
            for (int i = 0; i < maxZeichen; i++)
            {
                zeichenwert = rand.Next(unter, ober);
                text += (char)(zeichenwert);
            }
            return text;
        }

    }
}
