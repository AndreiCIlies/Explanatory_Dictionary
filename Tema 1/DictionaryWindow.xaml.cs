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
    /// Interaction logic for DictionaryWindow.xaml
    /// </summary>
    public partial class DictionaryWindow : Window
    {
        private HashSet<string> allWords = new HashSet<string>();

        public DictionaryWindow()
        {
            InitializeComponent();
            LoadWordCategories();
            LoadAllWords();
            GetWord();
        }

        private string GetWordCategory(string word)
        {
            string filePath = "C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//words.txt";
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i += 4)
            {
                if (lines[i] == word)
                {
                    return lines[i + 3];
                }
            }
            return null;
        }

        private void LoadWordCategories()
        {
            string filePath = "C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//words.txt";
            string[] lines = File.ReadAllLines(filePath);
            HashSet<string> categories = new HashSet<string>();

            for (int i = 3; i < lines.Length; i += 4)
            {
                categories.Add(lines[i]);
            }

            List<string> sortedCategories = new List<string>(categories);
            sortedCategories.Sort();

            category.Items.Clear();

            foreach (var wordCategory in sortedCategories)
            {
                category.Items.Add(wordCategory);
            }
        }

        private void LoadAllWords()
        {
            string filePath = "C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//words.txt";
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i += 4)
            {
                allWords.Add(lines[i]);
            }
        }

        private void GetWord()
        {
            string inputWord = word.Text;
            var filteredWords = GetFilteredWords(inputWord);

            words.ItemsSource = filteredWords;
            words.Visibility = Visibility.Visible;
        }

        private void getWord(object sender, RoutedEventArgs e)
        {
            GetWord();
        }

        private List<string> GetFilteredWords(string inputWord)
        { 
            string selectedCategory = category.Text;

            if (string.IsNullOrEmpty(inputWord) && string.IsNullOrEmpty(selectedCategory))
            {
                return allWords.OrderBy(word => word).ToList();
            }

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                if(string.IsNullOrEmpty(inputWord))
                {
                    return allWords.Where(word => GetWordCategory(word) == selectedCategory).OrderBy(word => word).ToList();
                }
                else
                {
                    return allWords.Where(word => word.StartsWith(inputWord) && GetWordCategory(word) == selectedCategory).OrderBy(word => word).ToList();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(inputWord))
                {
                    return allWords.OrderBy(word => word).ToList();
                }
                else
                {
                    return allWords.Where(word => word.StartsWith(inputWord)).OrderBy(word => word).ToList();
                }
            }
        }

        private void selectWord(object sender, RoutedEventArgs e)
        {
            if (words.SelectedItem != null)
            {
                word.Text = words.SelectedItem.ToString();
                words.Visibility = Visibility.Collapsed;
            }
        }

        private void showWordInformationsBtn(object sender, RoutedEventArgs e)
        {
            string selectedWord = word.Text;

            if(string.IsNullOrEmpty(selectedWord))
            {
                MessageBox.Show($"No Word Selected", "No Word", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string filePath = "C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//words.txt";
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i += 4)
            {
                if (lines[i] == selectedWord)
                {
                    wordTextBlock.Text = lines[i];
                    descriptionTextBlock.Text = lines[i + 1];
                    string imagePath = "C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//Images//" + lines[i + 2];
                    BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                    image.Source = bitmap;
                    categoryTextBlock.Text = lines[i + 3];
                }
            }
        }
    }
}
