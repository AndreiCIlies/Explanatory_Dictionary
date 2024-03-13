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

            if(string.IsNullOrEmpty(inputWord))
            {
                MessageBox.Show($"Empty Word TextBox", "No Word", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Classes.Word wordToDelete = new Classes.Word(inputWord, "", "", "");
            Classes.Admin admin = new Classes.Admin();
            admin.DeleteWordFromDictionary(wordToDelete);
        }
    }
}
