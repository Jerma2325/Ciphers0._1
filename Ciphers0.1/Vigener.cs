namespace Ciphers0._1
{
    
        public class Vigener
        {
            const string defaultAlphabet = "AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻżQqVvXx";
            readonly string letters;
            public Vigener(string alphabet = null)
            {
                letters = string.IsNullOrEmpty(alphabet) ? defaultAlphabet : alphabet;
            }
            private string GetRepeatKey(string s, int n)
            {
                var p = s;
                while (p.Length < n)
                {
                    p += p;
                }
                return p.Substring(0, n);
            }
            private string Vigenere(string text, string password, bool encrypting = true)
            {
                var gamma = GetRepeatKey(password, text.Length);
                var retValue = "";
                var q = letters.Length;
                for (int i = 0; i < text.Length; i++)
                {
                    var letterIndex = letters.IndexOf(text[i]);
                    var codeIndex = letters.IndexOf(gamma[i]);
                    if (letterIndex < 0)
                    {
                        retValue += text[i].ToString();
                    }
                    else
                    {
                        retValue += letters[(q + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString();
                    }
                }
                return retValue;
            }

            public string Encrypt(string plainMessage, string password)
            {
                return  Vigenere(plainMessage, password);
            }
            public string Decrypt(string encryptedMessage, string password)
            {
                return  Vigenere(encryptedMessage, password, false);
            }
        }
    
}