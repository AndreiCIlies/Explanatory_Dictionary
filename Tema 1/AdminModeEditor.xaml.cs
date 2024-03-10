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
    /// Interaction logic for AdminModeEditor.xaml
    /// </summary>
    public partial class AdminModeEditor : Window
    {
        public AdminModeEditor()
        {
            InitializeComponent();
        }

        private void addWordBtn(object sender, RoutedEventArgs e)
        {
            AddWordWindow addWordWindow = new AddWordWindow();
            addWordWindow.Show();
        }

        private void editWordBtn(object sender, RoutedEventArgs e)
        {
            EditWordWindow editWordWindow = new EditWordWindow();
            editWordWindow.Show();
        }

        private void deleteWordBtn(object sender, RoutedEventArgs e)
        {
            DeleteWordWindow deleteWordWindow = new DeleteWordWindow();
            deleteWordWindow.Show();
        }
    }
}
