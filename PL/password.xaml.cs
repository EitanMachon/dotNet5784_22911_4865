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
        // Constructor for the password class
        public password()
        {
            InitializeComponent();
        }


        // Event handler for the text changed event that checks the text of the TextBox
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox; // Cast the sender to TextBox
            if (textBox.Text == "123") // Check the text of the TextBox
            {
                new MainWindow().Show();
                Close(); // Close the password window
            }
        }

        // Event handler for the button click event that closes the window
        private void Button_Back(object sender, RoutedEventArgs e)
        {
           
        }

        // Event handler for the button click event that closes the window

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // LoginScreen loginScreen = new LoginScreen();
          //  loginScreen.Show();
            Close(); // Close the password window
        }
    }
}
