using BlApi;
using PL.Engineer;
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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        static readonly IBl s_bl = Factory.Get(); // Use IBl interface instead of BlApi class
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void openManagerWindow_click(object sender, RoutedEventArgs e)
        {
            new password().Show(); // Create a new instance of password
            Close(); // Close the login window
        }
        private void reset_click(object sender, RoutedEventArgs e)
        {
            // Ask the user for confirmation
            // its gonna show a message box with the question "Are you sure you want to reset the database?"
            MessageBoxResult result = MessageBox.Show("Are you sure you want to reset the database?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // If the user confirms, reset the database
            if (result == MessageBoxResult.Yes)
            {
                //BltTest.
                MessageBox.Show("Database reset successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void Initialization_Click(object sender, RoutedEventArgs e)
        {
            // Ask the user for confirmation
            // its gonna show a message box with the question "Are you sure you want to initialize the database?"
            MessageBoxResult result = MessageBox.Show("Are you sure you want to initialize the database?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // If the user confirms, initialize the database
            if (result == MessageBoxResult.Yes)
            {
                // Call the initialization method in DalTest
                DalTest.Initialization.Do();
                MessageBox.Show("Database initialized successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EmployeeEntry_Click(object sender, RoutedEventArgs e)
        {
            new EMPLOEYVIEWENGINEERLIST().Show(); // Create a new instance of EmployeWindow
            Close();
        }
    }
}
