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
    /// Interaction logic for AdminMode.xaml
    /// </summary>
    public partial class AdminMode : Window
    {
        public AdminMode()
        {
            InitializeComponent();
        }

        private void loginModeBtn(object sender, RoutedEventArgs e)
        {
            string[] users = File.ReadAllLines("C://Users//usER//Desktop//Anul_II//Semestrul_II//MAP//Teme//Tema 1//Tema 1//Tema 1//admin.txt");

            string enteredUsername = username.Text;
            string enteredPassword = password.Password;
            bool isAdmin = false;

            foreach(string user in users)
            {
                string[] usernameAndPassword = user.Split(' ');
                if (usernameAndPassword.Length == 2 && usernameAndPassword[0] == enteredUsername && usernameAndPassword[1] == enteredPassword)
                {
                    isAdmin = true;
                    break;
                }
            }

            if(isAdmin)
            {
                AdminModeEditor adminModeEditorWindow = new AdminModeEditor();
                adminModeEditorWindow.Show();
            }
            else
            {
                MessageBox.Show("Admin not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
