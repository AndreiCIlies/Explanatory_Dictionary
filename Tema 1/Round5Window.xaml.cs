using System;
using System.IO;
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
using System.Windows.Shapes;

namespace Tema_1
{
    /// <summary>
    /// Interaction logic for Round5Window.xaml
    /// </summary>
    public partial class Round5Window : Window
    {
        private string[] words;
        private string[] descriptions;
        private string[] images;

        private string selectedWord;
        private string selectedDescription;
        private string selectedImage;

        public Round5Window()
        {
            InitializeComponent();
            LoadWords();
            SelectRandomWord();
            DisplayWordInfo();
        }

        private void LoadWords()
        {
            string filePath = "C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//words.txt";
            string[] lines = File.ReadAllLines(filePath);
            int count = lines.Length / 4;

            words = new string[count];
            descriptions = new string[count];
            images = new string[count];

            for (int i = 0; i < count; i++)
            {
                words[i] = lines[i * 4];
                descriptions[i] = lines[i * 4 + 1];
                images[i] = lines[i * 4 + 2];
            }
        }

        private void SelectRandomWord()
        {
            Random rand = new Random();
            int index = rand.Next(words.Length);
            selectedWord = words[index];
            selectedDescription = descriptions[index];
            selectedImage = images[index];
        }

        private void DisplayWordInfo()
        {
            descriptionTextBlock.Text = selectedDescription;

            if (selectedImage != "unavailableImage.jpg")
            {
                imageTextBlock.Background = new ImageBrush(new BitmapImage(new Uri("C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//Images//" + selectedImage)));
                descriptionTextBlock.Visibility = Visibility.Collapsed;
                imageTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                imageTextBlock.Background = null;
                imageTextBlock.Visibility = Visibility.Collapsed;
                descriptionTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void checkAnswerBtn(object sender, RoutedEventArgs e)
        {
            string userAnswer = answer.Text.Trim();

            if (userAnswer.ToLower() == selectedWord.ToLower())
            {
                MessageBox.Show("Congratulations! You have finished the game.", "Game Finished", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect answer. Please try again.", "Incorrect", MessageBoxButton.OK, MessageBoxImage.Warning);
                answer.Clear();
            }
        }
    }
}
