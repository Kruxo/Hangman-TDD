using HangmanGame.Core;
using System;

namespace HangmanGame.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] words = { "apple", "banana", "cherry" };
            string selectedWord = Core.HangmanGame.SelectRandomWord(words);
            var game = new Core.HangmanGame(selectedWord);

            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Try to guess the word, one letter at a time.");
            Console.WriteLine($"You have {game.RemainingAttempts} attempts.\n");

            while (!game.IsWin() && !game.IsLoss())
            {
                Console.WriteLine($"Word: {game.GetMaskedWord()}");
                Console.WriteLine($"Remaining attempts: {game.RemainingAttempts}");
                Console.Write("Enter a letter: ");

                char input;
                string userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput) && char.TryParse(userInput, out input))
                {
                    game.GuessLetter(input);

                    if (game.IsWin())
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Word: {game.GetMaskedWord()}");
                        Console.WriteLine($"\nCongratulations! You've guessed the word: {selectedWord}");
                    }
                    else if (game.IsLoss())
                    {
                        Console.WriteLine($"\nGame Over! The correct word was: {selectedWord}");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid single letter.");
                }

                Console.WriteLine();
            }
        }
    }
}
