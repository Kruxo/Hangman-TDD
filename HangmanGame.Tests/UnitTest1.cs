using Shouldly;

namespace HangmanGame.Tests;

public class HangmanGameTests
{
    [Fact]
    public void TestWordSelection()
    {
        // Arrange
        string[] words = ["apple", "banana", "cherry"];

        // Act
        var selectedWord = Core.HangmanGame.SelectRandomWord(words);

        // Assert
        words.ShouldContain(selectedWord);
    }

    [Fact]
    public void TestCorrectGuess()
    {
        // Arrange
        var game = new Core.HangmanGame("apple");
        game.GuessLetter('a');

        // Act & Assert
        game.GetMaskedWord().ShouldBe("a _ _ _ _");
    }

    [Fact]
    public void TestIncorrectGuess()
    {
        // Arrange
        var game = new Core.HangmanGame("banana");
        var initialAttempts = game.RemainingAttempts;
        game.GuessLetter('z');

        // Act & Assert
        game.RemainingAttempts.ShouldBe(initialAttempts - 1);
    }

    [Fact]
    public void TestWinCondition()
    {
        var game = new Core.HangmanGame("dog");
        game.GuessLetter('d');
        game.GuessLetter('g');
        game.GuessLetter('o');

        game.IsWin().ShouldBeTrue();
    }

    [Fact]
    public void TestLossCondition()
    {
        //Arrange
        var game = new Core.HangmanGame("cat");

        //Act: Incorrect guesses until remaining attempts are 0
        game.GuessLetter('z');
        game.GuessLetter('y');
        game.GuessLetter('x');
        game.GuessLetter('w');
        game.GuessLetter('v');
        game.GuessLetter('u');

        //Assert: Player has lost after 6 incorrect guesses
        game.IsLoss().ShouldBeTrue();
    }

    [Fact]
    public void TestRepeatedGuess()
    {
        var game = new Core.HangmanGame("apple");
        var initialAttempts = game.RemainingAttempts;
        game.GuessLetter('x');
        game.GuessLetter('x');
        game.RemainingAttempts.ShouldBe(initialAttempts - 1);
    }

    [Fact]
    public void TestInvalidInput()
    {
        var game = new Core.HangmanGame("orange");
        var initialAttempts = game.RemainingAttempts;
        game.GuessLetter('1');
        game.RemainingAttempts.ShouldBe(initialAttempts);
    }

    [Fact]
    public void TestAllowCapitalizedLetters()
    {
        var game = new Core.HangmanGame("apple");
        game.GuessLetter('A');

        // Act & Assert
        game.GetMaskedWord().ShouldBe("a _ _ _ _");
    }


    [Fact]
    public void TestWord()
    {
        var game = new Core.HangmanGame("banana");
        game.DoubleWord().ShouldBe("*BANANA*BANANA*");
    }

    [Fact]
    public void GuessedCorrectWord()
    {
        // Arrange
        string word = "ilovepizza";
        string expectedWord = Core.HangmanGame.CorrectWord();

        // Act & Assert
        Assert.Equal(word, expectedWord);
    }

}


