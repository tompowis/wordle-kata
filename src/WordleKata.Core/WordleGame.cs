namespace WordleKata.Core;

using Data;

public class WordleGame
{
    public WordleWord Word { get; set; }

    public WordleGame(IWords words)
    {
        Word = words.GetRandomWord();
    }

    public void GuessWord(string guess)
    {
        var result = Word.Equals(guess);
    }
}