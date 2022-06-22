namespace WordleKata.Core.Data
{
    using Models;

    public interface IWordsProvider
    {
        List<Word> GetWords();
    }
}
