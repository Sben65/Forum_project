using forum_api.Services.Interfaces;

namespace forum_api.Services
{
    public class WordFilterService : IWordFilterService
    {
        private readonly string filePath = @"C:\Users\stevie.leveque\Desktop\C# tests\exo-forum-tests-unitaires\insults.txt";

        private readonly List<string> insultes = new List<string>();

        public WordFilterService()
        {
            this.insultes = File.ReadAllLines(filePath).ToList();
        }

        public string FilterWord(string textWord)
        {
            foreach (var word in insultes)
            {
                if (textWord.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                     string wordWithStars = "" + word[0];

                    for (int i = 1; i < word.Length - 1; i++)
                    {
                        wordWithStars += "*";
                    }
                    wordWithStars += word[word.Length - 1];

                    textWord = textWord.Replace(word, wordWithStars);
                }
            }

            return textWord;
        }
    }
}
