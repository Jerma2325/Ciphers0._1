using System;
using System.Globalization;
using GameController;
using static ObjCRuntime.Dlfcn;

namespace Ciphers0._1
{
    public class Caeser
    {
        private int _move;
        private string _input;
        
         public char[] PolskiLow = new[]
        {
            'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 
            'g', 'h', 'i', 'j', 'k', 'l', 'ł','m','n','ń',
            'o','ó','p','q','r','s','ś','t','u','v','w','x',
            'y','z','ź','ż'
        };

        public  char[] PolskiHigh= new[]
        {
             'A', 'Ą', 'B', 'C', 'Ć', 'D', 'E', 'Ę', 'F',
            'G', 'H', 'I', 'J', 'K', 'L', 'Ł','M','N','Ń',
            'O','Ó','P','Q','R','S','Ś','T','U','V','W','X',
            'Y','Z','Ź','Ż'
        } ;

        public Caeser() { }

        public string Encrypt(int move,string input)
        {
            _move = move;
            _input = input;
            string encrypted= String.Empty;
            foreach (char liter in _input)
            {
                if (char.IsWhiteSpace(liter))
                {
                    encrypted += ' ';
                }
                else
                {
                    if (char.IsLower(liter))
                    {
                        int index = Array.IndexOf(PolskiLow, liter);
                        int i = (index + _move) % 35;
                        encrypted += PolskiLow[i];
                    }
                    else if (char.IsUpper(liter))
                    {
                        int index = Array.IndexOf(PolskiHigh, liter);
                        int i = (index + _move) % 35;
                        encrypted += PolskiHigh[i];
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            return encrypted;
        }
        public string Decrypt(int move, string input)
        {
            _move = move;
            _input = input;
            string decrypted = string.Empty;
            foreach (char liter in _input)
            {
                if (char.IsWhiteSpace(liter))
                {
                    decrypted += ' ';
                }
                else
                {
                    if (char.IsLower(liter))
                    {
                        int index = Array.IndexOf(PolskiLow, liter);
                        int i = (index - _move) % 35;
                        decrypted += PolskiLow[i];
                    }
                    else if (char.IsUpper(liter))
                    {
                        int index = Array.IndexOf(PolskiHigh, liter);
                        int i = (index - _move) % 35;
                        decrypted += PolskiHigh[i];
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            return decrypted;
        }
    }
}
