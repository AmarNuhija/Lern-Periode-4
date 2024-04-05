using System;

namespace HangmanGame
{
    class Program
    {
        static string[] words = { "haus", "tisch", "stuhl", "auto", "schule", "hund", "katze", "ball", "baum", "blume", "sonne", "mond", "fluss", "see", "brücke", "fenster", "tür", "buch", "papier", "feder", "apfel", "birne", "banane", "orange", "erdbeere", "tomate", "kartoffel", "zwiebel", "käse", "brot", "milch", "butter", "ei", "fleisch", "fisch", "salat", "suppe", "kaffee", "tee", "wasser", "wein", "bier", "saft", "zucker", "salz", "pfeffer", "messer", "löffel", "gabel", "teller" };
        static Random random = new Random();
        static string wordToGuess = words[random.Next(words.Length)];
        static char[] guessedLetters = new char[wordToGuess.Length];
        static int attemptsLeft = 5;

        static void Main(string[] args)
        {
            InitializeGuessedLetters();
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Guess the word:");
            DisplayWord();

            while (attemptsLeft > 0 && !WordGuessed())
            {
                Console.WriteLine($"\nAttempts left: {attemptsLeft}");
                Console.Write("Enter a letter: ");
                char letter = Console.ReadLine().ToLower()[0];

                if (IsLetterInWord(letter))
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                    attemptsLeft--;
                }

                Console.WriteLine();
                DisplayWord();
            }

            if (WordGuessed())
            {
                Console.WriteLine("\nCongratulations! You guessed the word!");
            }
            else
            {
                Console.WriteLine("\nGame over! You ran out of attempts.");
                Console.WriteLine($"The word was: {wordToGuess}");
            }
        }

        static void InitializeGuessedLetters()
        {
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                guessedLetters[i] = '_';
            }
        }

        static void DisplayWord()
        {
            foreach (char letter in guessedLetters)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();
        }

        static bool WordGuessed()
        {
            return Array.IndexOf(guessedLetters, '_') == -1;
        }

        static bool IsLetterInWord(char letter)
        {
            bool foundLetter = false;
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == letter)
                {
                    guessedLetters[i] = letter;
                    foundLetter = true;
                }
            }
            return foundLetter;
        }
    }
}
