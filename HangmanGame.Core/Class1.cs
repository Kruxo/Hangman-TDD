namespace HangmanGame.Core;


public class HangmanGame(string word)
{
    private List<char> guessedLetters = [];
    public int RemainingAttempts { get; set; } = 6;

    public static string SelectRandomWord(string[] words)
    {
        Random random = new();
        string randomWord = words[random.Next(0, 3)];
        return randomWord;
    }

    public void GuessLetter(char letter)
    {
        if (!guessedLetters.Contains(letter) && char.IsLetter(letter)) //Checking if the letter isnt already guessed, if it's already guessed we will exit the loop early so we dont decrease remaining attempts when a user guess the same letter more than once
        {
            guessedLetters.Add(char.ToLower(letter));

            if (!word.Contains(letter)) //If word also does not contain guessed letter, decrease remaining attempts
            {
                RemainingAttempts--;
            }
        } // Basically add a newly unguessed letter to the list regardless of it is a part of the "word" and if it does not exist in word then decrease remainig attempts, but if we guess the same letter again then we skip the whole code all together

    }

    public string GetMaskedWord()
    {
        List<string> maskedWord = new List<string>();

        foreach (char letter in word)
        {
            if (guessedLetters.Contains(letter))
            {
                maskedWord.Add(letter.ToString());
            }
            else
            {
                maskedWord.Add("_");
            }
        }
        return string.Join(" ", maskedWord);
    }

    public bool IsWin()
    {

        foreach (char letter in word)
        {
            if (!guessedLetters.Contains(letter))
            {
                return false;
            }
        }
        return true;

        //return GetMaskedWord().Replace(" ", "") == word; //Removes all white space in masked word and check if its equals to parameter word

        //return word.All(x => guessedLetters.Contains(x)); //checking witn linq if the letters in word exists in guessletters
    }

    public bool IsLoss()
    {
        return RemainingAttempts <= 0; //Simplified way to write return true if that condition is true otherwise false
    }

    public string UserInput()
    {
        return word.ToLower();
    }

    public static string CorrectWord()
    {
        return "ilovepizza";
    }

    public string DoubleWord()
    {
        if (string.IsNullOrEmpty(word))
        {
            return "";
        }
        return $"*{word.ToUpper()}*{word.ToUpper()}*";
    }


}
