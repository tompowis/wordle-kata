namespace WordleKata.UnitTests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using Core;
    using Core.Models;
    using Core.Data;
    using Xunit;
    using FluentAssertions;
    using FluentAssertions.Events;

    public class WordleGameTests
    {
        private readonly WordleGame _game;
        private readonly IMonitor<WordleGame> _gameMonitor;

        public WordleGameTests()
        {
            var wordsProviderMock = new Mock<IWordsProvider>();
        
            wordsProviderMock.Setup(mock => mock.GetWords())
                .Returns(new List<Word> { new("Pizza") });
            
            _game = new WordleGame(wordsProviderMock.Object);

            _gameMonitor = _game.Monitor();
        }
        
        [Fact]
        public void CanSetupWordleGame()
        {
            // _game.Word.Should().Be((Word) "Pizza");
            // using (_game.Start());

            _gameMonitor.Should().Raise("GetGuess");
            
        }

        ~WordleGameTests()
        {
            _gameMonitor.Dispose();
        }
        
    }
}