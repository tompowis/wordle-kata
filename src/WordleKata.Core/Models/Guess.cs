namespace WordleKata.Core.Models
{
    public class Guess: Word
    {
        public bool AllLettersMatch
            => Letters.All(l => l.Status == LetterStatus.InPlaceMatch);
    
        public Guess(string guess)
            : base(guess) { }

        public Guess Compare(Word word)
        {
            var guess = this;
        
            for (var i = 0; i < word.Letters.Length; i++)
            {
                var letter = word.Letters[i];

                if (Equals(guess.Letters[i], letter))
                {
                    guess.Letters[i].Status = LetterStatus.InPlaceMatch;
                    continue;
                }

                if (!guess.Letters.Contains(letter)) 
                    continue;
            
                foreach (var t in guess.Letters)
                {
                    if (t.Equals(letter))
                    {
                        t.Status = LetterStatus.OutOfPlaceMatch;
                    }
                }
            }

            return guess;
        }
    
        public static implicit operator Guess(string word)
            => new(word);
    }
}