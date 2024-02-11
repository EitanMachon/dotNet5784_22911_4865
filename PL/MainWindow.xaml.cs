using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// this func gonna show the EngineerListWindow
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Engineer.EngineerListWindow engineerListWindow = new Engineer.EngineerListWindow(); // Create a new instance of EngineerListWindow
            engineerListWindow.Show(); // Show the window of EngineerListWindow
        }
        /// <summary>
        /// this func gonna Initialize the database after the user confirm it
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
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

       
    }
}