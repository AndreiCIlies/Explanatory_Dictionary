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
using static System.Net.Mime.MediaTypeNames;

namespace Tema_1
{
    /// <summary>
    /// Interaction logic for DeleteWordWindow.xaml
    /// </summary>
    public partial class DeleteWordWindow : Window
    {
        public DeleteWordWindow()
        {
            InitializeComponent();
        }

        private void deleteWordInDictionaryBtn(object sender, RoutedEventArgs e)
        {
            string inputWord = word.Text;
            Classes.Word wordToDelete = new Classes.Word(inputWord, "", "", "");

            string filePath = "C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//words.txt";
            string[] lines = File.ReadAllLines(filePath);
            List<string> newLines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == inputWord)
                {
                    wordToDelete.description = lines[i + 1];
                    wordToDelete.image = lines[i + 2];
                    wordToDelete.category = lines[i + 3];
                    break;
                }
            }

            Classes.Admin admin = new Classes.Admin();
            admin.DeleteWordFromDictionary(wordToDelete);
        }
    }
}
