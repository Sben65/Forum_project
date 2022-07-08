using forum_api.Services.Interfaces;

namespace forum_api.Services
{
    public class WordFilterService : IWordFilterService
    {
        //private readonly string filePath = @"\Dico\insults.txt";
        private string filename = @"C:\dev\.Net\Forum\Forum_Word_Api\Services\Dico\insults.txt";
        //string filePath = AppDomain.CurrentDomain.BaseDirectory + filename;

        private readonly List<string> insultes = new List<string>();

        public WordFilterService()
        {
            this.insultes = File.ReadAllLines(filename).ToList();
        }

        public string FilterWord(string textWord)
        {
            var listMot = textWord.Split(new char[] { ' ' });
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
