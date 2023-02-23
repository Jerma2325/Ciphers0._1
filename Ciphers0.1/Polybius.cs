using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Ciphers0._1
{
    public class Polybius
    {
        private string output;
        public char[] PolskiLow = new[]
        {
            'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f',
            'g', 'h', 'i', 'j', 'k', 'l', 'ł','m','n','ń',
            'o','ó','p','q','r','s','ś','t','u','v','w','x',
            'y','z','ź','ż'
        };
        public Polybius() { }
        public string Encrypt(string input, string[,] emptyS)
        {
            var result = Regex.Replace(input, @"[^AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻżQqVvXx]+", "");
            foreach (var item in result)
            {
                Tuple<int, int> coordinate = emptyS.CoordinatesOf(item.ToString().ToLower());
                output += coordinate.Item1+1;
                output += coordinate.Item2+1;
            }
            return output;
        }
        public string Decrypt(string input, string[,] emptyS)
        {
            var result = Regex.Replace(input, @"[^0-9]+", "");
            var everytwo= result.TakeEvery(2);
           foreach (var item in everytwo)
           {
               var i = 0;
               var k = 0;
               foreach (var it in item)
               {
                   if (i == 0)
                   {
                       i = it- '0';
                   }
                   else
                   {
                       k = it - '0';
                   }
               }
               i = i - 1;
               k = k - 1;
               output += emptyS[i, k];
           }
            return output;
        }
    }
}

