using System;
using System.Windows.Forms;

namespace NumberGuessing
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int min = 1;
        int max = 100;
        int number;
        int guesses;

        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            number = random.Next(min, max + 1);
            guesses = 0;
            lblResult.Text = "";
            txtGuess.Text = "";
            lblMessage.Text = $"Enter a number between {min} - {max}:";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int guess;

            if (int.TryParse(txtGuess.Text, out guess))
            {
                guesses++;
                if (guess > number)
                {
                    lblResult.Text = $"{guess} is too high!!!";
                }
                else if (guess < number)
                {
                    lblResult.Text = $"{guess} is too low!!!";
                }
                else
                {
                    lblResult.Text = $"Number: {number}\nYOU WIN!!!...\nGuesses: {guesses}";
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
                txtGuess.Clear(); // Clear the textbox for a new entry
                txtGuess.Focus();  // Set focus back to the textbox
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
    }
}
