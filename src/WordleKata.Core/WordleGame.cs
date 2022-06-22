namespace WordleKata.Core
{
    using Data;
    using Models;

    public delegate Guess GetGuessHandler();
    public delegate void GuessResultHandler(List<Guess> guesses);
    public delegate void GameFinishedHandler(WordleGameStatus exitStatus, int attempts, Word word);
    public delegate void GameExceptionHandler(Exception exception);
    
    public class WordleGame
    {
        private List<Word> Words { get; }
        private List<Guess> Guesses;
        private WordleGameStatus Status { get; set; }
        private int Attempts => Guesses.Count;
        
        
        public event GetGuessHandler GetGuess;
        public event GuessResultHandler HandleGuessResult;
        public event GameFinishedHandler HandleGameFinished;
        public event GameExceptionHandler HandleException;
        
        public WordleGame(IWordsProvider wordsProvider) 
            : this(wordsProvider.GetWords()) { }
        
        public WordleGame(List<Word> words) 
            => Words = words;

        public void Start()
        {
            Guesses = new List<Guess>();
            Status = WordleGameStatus.InProgress;
                
            try
            {
                var randomWord = GetRandomWord();
                
                MainGameLoop(randomWord);
                
                HandleGameFinished(Status, Attempts, randomWord);
            }
            catch (Exception e)
            {
                // Handle and exit
                HandleException(e);
            }
        }

        public void Stop()
        {
            Status = WordleGameStatus.Stopped;
        }

        private void MainGameLoop(Word word)
        {
            while (Status == WordleGameStatus.InProgress)
            {
                try
                {
                    var guessResult = GetGuess().Compare(word); 
                    
                    Guesses.Add(guessResult);
                        
                    HandleGuessResult(Guesses);

                    if (Guesses.Any(g => g.AllLettersMatch))
                        Status = WordleGameStatus.Won;
                        
                    if (Attempts >= 5)
                        Status = WordleGameStatus.Lost;
                }
                catch (Exception e)
                {
                    // Handle and continue
                    HandleException(e);
                }
            }
        }
        
        private Word GetRandomWord()
        {
            return Words[new Random().Next(Words.Count)];
        }
    }
}

