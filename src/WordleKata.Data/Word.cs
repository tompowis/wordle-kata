namespace WordleKata.Data;

public sealed class Word
{
    private readonly string _word;

    public Word(string wordChars)
    {
        _word = wordChars.Length == 5 ? new string(wordChars) : 
            throw new ArgumentException("Word must be 5 characters long");
    }
    
    public bool Equals(Word? other)
    {
        return other is not null && string.Equals(_word, other, StringComparison.OrdinalIgnoreCase);
    }
    
    public static implicit operator Word(string word)
        => new(word);
    
    public static implicit operator string(Word word)
        => word._word;
}