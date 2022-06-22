namespace WordleKata.Console
{
	using Core;
	using Core.Data;
	using Core.Models;
	using Spectre.Console;

	public static class Program
	{
		private static WordleGame? _game;
		
		public static void Main()
		{
			var wordsProvider = new WordsFileProvider("Static/WordList.txt");
			
			_game = new WordleGame(wordsProvider);

			_game.GetGuess += GetGuessHandler;
			_game.HandleGuessResult += GuessResultHandler;
			_game.HandleGameFinished += GameOnGameFinished;
			
			_game.HandleException += exception 
				=> AnsiConsole.WriteLine(exception.Message);
			
			_game.Start();
		}
		
		private static Guess GetGuessHandler()
		{
			return AnsiConsole.Ask<string>("Enter guess:");
		}
	
		private static void GuessResultHandler(List<Guess> guesses)
		{
			// Clears console and redraws guesses
			
			AnsiConsole.Clear();

			foreach (var guess in guesses)
			{
				foreach (var letter in guess.Letters)
				{
					switch (letter.Status)
					{
						case LetterStatus.InPlaceMatch:
							AnsiConsole.Markup($"[bold white on green]{letter}[/]");
							break;
						case LetterStatus.OutOfPlaceMatch:
							AnsiConsole.Markup($"[bold black on yellow]{letter}[/]");
							break;
						case LetterStatus.NoMatch:
							AnsiConsole.Write(letter);
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				AnsiConsole.WriteLine();
			}
		}
		
		private static void GameOnGameFinished(WordleGameStatus exitStatus, int attempts, Word word)
		{
			if (exitStatus == WordleGameStatus.Won)
				AnsiConsole.WriteLine($"Game won in {attempts} attempts");
			
			if (exitStatus == WordleGameStatus.Lost)
				AnsiConsole.WriteLine($"Game lost. Word was '{word}'");

			if (exitStatus == WordleGameStatus.Stopped)
				AnsiConsole.WriteLine("Game stopped");

			if (AnsiConsole.Confirm("Start a new Game?")) 
				_game?.Start();
		}

	}
}