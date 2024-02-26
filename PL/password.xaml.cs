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

namespace PL
{
    /// <summary>
    /// Interaction logic for password.xaml
    /// </summary>
    public partial class password : Window
    {
        public password()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox; // Cast the sender to TextBox
            if (textBox.Text == "123") // Check the text of the TextBox
            {
                new MainWindow().Show();
                Close(); // Close the password window
            }
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            Close(); // Close the password window
        }
    }
}
