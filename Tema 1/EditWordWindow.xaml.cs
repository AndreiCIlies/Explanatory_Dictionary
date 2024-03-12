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
    /// Interaction logic for EditWordWindow.xaml
    /// </summary>
    public partial class EditWordWindow : Window
    {
        public EditWordWindow()
        {
            InitializeComponent();
        }

        private void editWordInDictionaryBtn(object sender, RoutedEventArgs e)
        {
            string inputWord = word.Text;
            Classes.Word wordToEdit = new Classes.Word(inputWord, "", "", "");

            string filePath = "C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//words.txt";
            string[] lines = File.ReadAllLines(filePath);
            List<string> newLines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == inputWord)
                {
                    wordToEdit.description = string.IsNullOrEmpty(description.Text) ? lines[i + 1] : description.Text;
                    wordToEdit.image = string.IsNullOrEmpty(image.Text) ? lines[i + 2] : image.Text;
                    wordToEdit.category = string.IsNullOrEmpty(category.Text) ? lines[i + 3] : category.Text;
                    break;
                }
            }

            Classes.Admin admin = new Classes.Admin();
            admin.EditWordInDictionary(wordToEdit);
        }
    }
}
