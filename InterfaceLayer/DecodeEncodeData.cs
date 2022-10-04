using System;

namespace InterfaceLayer
{
    internal class DecodeEncodeData
    {
        string SuffixIndex = "%2Space2%";
        Random rnd = new Random();
        int RandomLoop, RandomNumber, RandomSymbol;

        public string EncodedLoginData { get; set; }
        
        public string EncodeLoginData(string UserName, string Passcode)
        {
            EncodedLoginData = ProcessLoginData(UserName) + SuffixIndex;
            EncodedLoginData += ProcessLoginData(Passcode);

            return EncodedLoginData;
        }
        public string EncodeLoginData(string UserName, string Passcode, string SecurityLevel)
        {
            EncodedLoginData = ProcessLoginData(UserName) + SuffixIndex;
            EncodedLoginData += ProcessLoginData(Passcode) + SuffixIndex;
            EncodedLoginData += ProcessLoginData(SecurityLevel);

            return EncodedLoginData;
        }
        
        private string ProcessLoginData(string sentence)
        {
            char[] charArr = sentence.ToCharArray();
            string GeneratedString = string.Empty;

            foreach (char ch in charArr)
            {
                GeneratedString += RandomStringGenerator(ch);
            }

            return GeneratedString;
        }

        private string RandomStringGenerator(char ch)
        {
            string GeneratedString = string.Empty;
            RandomLoop = rnd.Next(13, 15);
            RandomSymbol = rnd.Next(6, 12);

            for (int i = 0; i < RandomLoop; i++)
            {
                if (i % RandomSymbol == 0)
                {
                    GeneratedString += Symbol();
                }
                else
                    GeneratedString += SmallAlpha();
            }
            GeneratedString += Convert.ToInt32(ch) + SymbolNumSymbol();

            return GeneratedString;
        }

        private string SymbolNumSymbol()
        {
            string GeneratedSymbolNumSymbol = string.Empty;
            RandomNumber = rnd.Next(9);

            GeneratedSymbolNumSymbol += Symbol();
            GeneratedSymbolNumSymbol += RandomNumber;
            GeneratedSymbolNumSymbol += Symbol();

            return GeneratedSymbolNumSymbol;
        }

        private string Symbol()
        {
            string GeneratedSymbol = string.Empty;

            GeneratedSymbol += Convert.ToChar(rnd.Next(35, 38));

            return GeneratedSymbol;
        }

        private string SmallAlpha()
        {
            string GeneratedAlpha = string.Empty;

            GeneratedAlpha += Convert.ToChar(rnd.Next(97, 122));

            return GeneratedAlpha;
        }
    }
}
