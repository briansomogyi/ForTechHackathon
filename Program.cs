namespace DecryptTheMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Pași de Decodificare:
                - Eliminați caracterele "^" și "~" din text.
                - Înlocuiți caracterele "{", "}", "(", ")" cu spații.
                - Înlocuiți cifrele cu literele corespunzătoare.
                - Inversați ordinea caracterelor rămase în text.
                - Înlocuiți caracterele cu literele corespunzătoare, utilizând cheia Constants.Key.
                  Cheia este folosita in cadrul unui algoritm de criptare cu substitutie, alfabetul suportat fiind specificat in Constants.Alphabet.
                - Afișați mesajul rezultat.
             */

            const string encryptedText = ">&%%S,^Kf*10zc3n5,4QQ1<6NRL^43^y91je62<L,OMP!l91PPWRwM;2S4Zy?*#XU!hS%;eKQf^^L%>MN3K";

            // TODO: implement decryption

            Console.WriteLine(encryptedText);
            string decryptedText = string.Empty;
            string s = encryptedText.Replace("~","");
            s = s.Replace("^", "");
            char[] chars = s.ToCharArray();
            Console.WriteLine(chars);
            for(int i=0;i<chars.Length;i++) 
            {
                if (chars[i] == '{' || chars[i] == '}' || chars[i] == '(' || chars[i] == ')')
                {
                    chars[i] = ' ';
                }
                bool ok = int.TryParse(Convert.ToString(chars[i]), out int result);
                if (ok)
                {
                    chars[i] = Constants.Alphabet[result];
                }
            }
            Console.WriteLine(chars);
            Array.Reverse(chars);
            Console.WriteLine(chars);
            for(int i=0;i< chars.Length; i++)
            {
                chars[i] = Decript(chars[i], Constants.Alphabet.IndexOf(Constants.Key[i % Constants.Key.Length]));
            }
            Console.WriteLine("Decrypted text=????");
            Console.WriteLine(chars);
            
        }

        static char Decript(char encryptedLetter, int shift)
        {
            int indexOfEncryptedLetter = Constants.Alphabet.IndexOf(encryptedLetter);
            indexOfEncryptedLetter -= shift;
            if(indexOfEncryptedLetter < 0)
            {
                indexOfEncryptedLetter += Constants.Alphabet.Length;
            }
            return Constants.Alphabet[indexOfEncryptedLetter];
        }
    }
}