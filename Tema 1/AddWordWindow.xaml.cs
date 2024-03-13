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
using System.Windows.Shapes;

namespace Tema_1
{
    /// <summary>
    /// Interaction logic for AddWordWindow.xaml
    /// </summary>
    public partial class AddWordWindow : Window
    {
        public AddWordWindow()
        {
            InitializeComponent();
        }

        private void addWordInDictionaryBtn(object sender, RoutedEventArgs e)
        {
            string newWord = word.Text;
            string newDescription = description.Text;
            string newImage = image.Text;
            string newCategory = category.Text;

            if (string.IsNullOrEmpty(newWord) && string.IsNullOrEmpty(newDescription) && string.IsNullOrEmpty(newCategory))
            {
                MessageBox.Show($"No informations added for the new word", "No Informations", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(newWord) && string.IsNullOrEmpty(newDescription))
            {
                MessageBox.Show($"Empty Word and Description TextBoxes", "No Word and Description", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(newWord) && string.IsNullOrEmpty(newCategory))
            {
                MessageBox.Show($"Empty Word and Category TextBoxes", "No Word and Category", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(newDescription) && string.IsNullOrEmpty(newCategory))
            {
                MessageBox.Show($"Empty Description and Category TextBoxes", "No Description and Category", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(newWord))
            {
                MessageBox.Show($"Empty Word TextBox", "No Word", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if(string.IsNullOrEmpty(newDescription))
            {
                MessageBox.Show($"Empty Description TextBox", "No Description", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if(string.IsNullOrEmpty(newCategory))
            {
                MessageBox.Show($"Empty Category TextBox", "No Category", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(newImage))
            {
                newImage = "unavailableImage.jpg";
            }

            Classes.Word newWordToAdd = new Classes.Word(newWord, newDescription, newImage, newCategory);
            Classes.Admin admin = new Classes.Admin();
            admin.AddWordInDictionary(newWordToAdd);
        }
    }
}
