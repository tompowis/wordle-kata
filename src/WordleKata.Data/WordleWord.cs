namespace WordleKata.Data;

public sealed record WordleWord
{
    private readonly string _word;

    public WordleWord(string word)
    {
        _word = word;
    }

    public bool Equals(string? other)
    {
        return other != null && Equals(new WordleWord(other));
    }
    
}