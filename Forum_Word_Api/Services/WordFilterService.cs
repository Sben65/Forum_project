using forum_api.Services.Interfaces;
using System.Linq;

namespace forum_api.Services
{
    public class WordFilterService : IWordFilterService
    {
        //private readonly string filePath = @"\Dico\insults.txt";
        //private string filename = @"C:\dev\.Net\Forum\Forum_Word_Api\Services\Dico\insults.txt";
        private string filename = @"C:\Users\stevie.leveque\Desktop\C# tests\exo-forum-tests-unitaires\insults.txt";
        //string filePath = AppDomain.CurrentDomain.BaseDirectory + filename;

        private readonly List<string> insultes = new List<string>();

        public WordFilterService()
        {
            this.insultes = File.ReadAllLines(filename).ToList();
        }

        public string FilterWord(string textWord)
        {
            var listMot = textWord.Split(new char[] { ' ', '.', '?', '!', ','});

            foreach (var mot in listMot)
            {
                if (this.insultes.Contains(mot))
                {
                    var wordWithStars = "" + mot[0];

                    for (int i = 1; i < mot.Length - 1; i++)
                    {
                        wordWithStars += "*";
                    }

                    wordWithStars += mot[^1];

                    textWord = textWord.Replace(mot, wordWithStars);
                }
            }

            return textWord;
        }
    }
}
