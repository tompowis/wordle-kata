namespace WordleKata.Data;

public interface IWords
{
    WordleWord GetRandomWord();
}

public class Words : IWords
{
    public WordleWord GetRandomWord()
    {
        return new WordleWord("WORD");
    }
}