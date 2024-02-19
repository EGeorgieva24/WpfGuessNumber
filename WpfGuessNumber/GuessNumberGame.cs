using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGuessNumber
{
    internal class GuessNumberGame
    {
        public enum Difficulty
        {
            Easy,
            Medium,
            Hard
        }

        public const int MinNumber = 1;
        public const int MaxNumber = 100;

        private int targetNumber;
        private int attemptsLeft;
        private int lastGuess;

        public int TargetNumber => targetNumber;
        public int AttemptsLeft => attemptsLeft;

        public void StartNewGame(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    attemptsLeft = 7;
                    break;
                case Difficulty.Medium:
                    attemptsLeft = 4;
                    break;
                case Difficulty.Hard:
                    attemptsLeft = 2;
                    break;
            }

            Random random = new Random();
            targetNumber = random.Next(MinNumber, MaxNumber+1);
            lastGuess = -1; 
        }

        public enum GameResult
        {
            Correct,
            High,
            Low
        }

        public GameResult CheckGuess(int userGuess)
        {
            if (attemptsLeft > 0)
            {
                if (userGuess == targetNumber)
                {
                    return GameResult.Correct;
                }
                else if (userGuess > targetNumber)
                {
                    attemptsLeft--; 
                    lastGuess = userGuess;
                    return GameResult.High;
                }
                else
                {
                    attemptsLeft--; 
                    lastGuess = userGuess;
                    return GameResult.Low;
                }
            }
            else
            {
                return GameResult.Correct; 
            }
        }

        public string CheckGuessDirectionMessage()
        {
            if (attemptsLeft > 0 && lastGuess != -1)
            {
                if (lastGuess < targetNumber)
                {
                    return "Go higher!";
                }
                else
                {
                    return "Go lower!";
                }
            }

            return string.Empty; 
        }
    }
}