using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global;

namespace ZennoPosterProjectAccountRegister.AccountStore
{
    internal class SessionBuilder
    {
        public List<char> CharacterSet { get; } = new List<char>();

        public SessionBuilder(bool isUseLetters, bool isUseNumber)
        {
            if(isUseLetters)
            {
                CharacterSet.AddRange(GetLetters());
            }
            if(isUseNumber)
            {
                CharacterSet.AddRange(GetNumbers());
            }
        }

        public string CreateSessionName(int size)
        {
            int charSum = CharacterSet.Count;
            if (charSum != 0)
            {
                char[] letters = Enumerable.Range(0, size)
                    .Select(i => CharacterSet[Classes.rnd.Next(0, charSum)])
                    .ToArray();
                return new string(letters);
            }
            else
            {
                return string.Empty;
            }
        }

        private char[] GetNumbers()
        {
            char[] numbers = Enumerable.Range('0', 10)
                .Select(i => (char)i)
                .ToArray();
            return numbers;
        }

        private char[] GetLetters()
        {
            char[] letters = Enumerable.Range('a','z' - 'a' + 1)
                .Select(i => (char)i)
                .ToArray();
            return letters;
        }
    }
}
