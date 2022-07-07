namespace forum_api.Helpers
{
    public static class WordHelper
    {

        public static List<string> GetBannedWordsList()
        {
            string textFile = @"C:\Users\stevie.leveque\Desktop\C# tests\exo-forum-tests-unitaires\insults.txt";
            List<string> bannedWords = File.ReadAllLines(textFile).ToList();
            return bannedWords;
        }

        public static string BannewWordsWithStars(string word)
        {

            var wordWithStars = "";
            List<string> bannedWords = WordHelper.GetBannedWordsList();

            if (bannedWords.Contains(word))
            {
                wordWithStars += word[0];

                for (int i = 1; i < word.Length - 1; i++)
                {
                    wordWithStars += "*";
                }
                wordWithStars += word[^1];

            }
            return wordWithStars;
        }

    }
}
