namespace WordleKata.Core.Models
{
    public class Letter
    {
        public char Character { get; set; }
        public LetterStatus Status { get; set; }

        public Letter(char character, LetterStatus status = LetterStatus.NoMatch)
        {
            Character = character;
            Status = status;
        }

        public override bool Equals(object? obj)
        {
            return obj switch
            {
                Letter letter => char.ToUpperInvariant(Character)
                    .Equals(char.ToUpperInvariant(letter.Character)),
                _ => base.Equals(obj)
            };
        }
        

        public override string ToString()
        {
            return Character.ToString();
        }

        public static implicit operator char(Letter @char)
            => @char.Character;
	    
        public static implicit operator Letter(char @char)
            => new(@char);
    }
}

