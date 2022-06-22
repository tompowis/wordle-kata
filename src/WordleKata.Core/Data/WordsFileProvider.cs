namespace WordleKata.Core.Data
{
    using Models;

    public class WordsFileProvider: IWordsProvider
    {
        private readonly string _fileName;

        public WordsFileProvider(string fileName)
        {
            _fileName = fileName;
        }

        public List<Word> GetWords()
        {
            return File.ReadAllLines(_fileName).Select(x => (Word) x).ToList();
        }
    }
}