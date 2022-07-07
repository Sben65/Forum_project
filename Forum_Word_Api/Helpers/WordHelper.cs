namespace forum_api.Helpers
{
    public static class WordHelper
    {
        public static List<string> GetFilsAsList(string filePath)
        {
            var textList = new List<string>();

            if (File.Exists(filePath))
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    int counter = 0;
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        textList.Add(ln);
                        counter++;
                    }
                    file.Close();
                }
            }

            return textList;
        }
    }
}
