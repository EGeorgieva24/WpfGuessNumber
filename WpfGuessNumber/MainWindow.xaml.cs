using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfGuessNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GuessNumberGame game;
        public MainWindow()
        {
            InitializeComponent();
            game = new GuessNumberGame();
        }

        private void EasyClick(object sender, RoutedEventArgs e)
        {
            StartGame(GuessNumberGame.Difficulty.Easy);
        }

        private void MediumClick(object sender, RoutedEventArgs e)
        {
            StartGame(GuessNumberGame.Difficulty.Medium);
        }

        private void HardClick(object sender, RoutedEventArgs e)
        {
            StartGame(GuessNumberGame.Difficulty.Hard);
        }
        private void StartGame(GuessNumberGame.Difficulty difficulty)
        {
            game.StartNewGame(difficulty);
            DisplayMessage($"Guess a number between {GuessNumberGame.MinNumber} and {GuessNumberGame.MaxNumber}");

            
            CheckGuessButton.IsEnabled = true;
            UserInputTextBox.IsEnabled = true;
        }

        private void CheckGuessButton_Click(object sender, RoutedEventArgs e)
        {
            if (game.AttemptsLeft > 0)
            {
                if (int.TryParse(UserInputTextBox.Text, out int userGuess))
                {
                    GuessNumberGame.GameResult result = game.CheckGuess(userGuess);

                    if (result == GuessNumberGame.GameResult.Correct)
                    {
                        DisplayMessage($"Congratulations! You guessed the number {game.TargetNumber}! Play again?");
                        
                        CheckGuessButton.IsEnabled = false;
                        UserInputTextBox.IsEnabled = false;
                    }
                    else
                    {
                        DisplayMessage(result == GuessNumberGame.GameResult.High
                            ? "Too high. " + game.CheckGuessDirectionMessage()
                            : "Too low. " + game.CheckGuessDirectionMessage());
                    }
                }
                else
                {
                    DisplayMessage("Invalid input. Please enter a valid number.");
                }
            }
            else
            {
                DisplayMessage($"Sorry, you ran out of attempts. The correct number was {game.TargetNumber}. Play again?");
                
                CheckGuessButton.IsEnabled = false;
                UserInputTextBox.IsEnabled = false;
            }
        }

        private void DisplayMessage(string message)
        {
            MessageTextBlock.Text = message;
        }
    }
}

