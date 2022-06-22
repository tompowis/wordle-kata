namespace WordleKata.Core.Models
{
    public class Word
    {
        public readonly Letter[] Letters;
	    
        public Word(string word) 
            : this(word.Select(c => new Letter(c)).ToArray()) 
        {}

        public Word(Letter[] letters)
        {
            if (letters.Length != 5)
                throw new ArgumentException("Word must be 5 characters long");

            if (!letters.Any(letter => char.IsLetter(letter)))
                throw new ArgumentException("Word must only contain letters A-Z");

            Letters = letters;
        }

        public override string ToString()
        {
            return this;
        }

        public static implicit operator Word(string word)
            => new(word);

        public static implicit operator string(Word word)
            => new (word.Letters.Select(c => c.Character).ToArray());
    }
}

