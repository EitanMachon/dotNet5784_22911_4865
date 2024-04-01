using BlApi;
using deleteXml;
using PL.Engineer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace PL
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window, INotifyPropertyChanged
    {

        private const int V = 24; // 24 hours in a day
        static readonly BlApi.IBl s_bl2 = BlApi.Factory.Get(); // Use IBl interface instead of BlApi class

        static readonly IBl s_bl = Factory.Get(); // Use IBl interface instead of BlApi class
        private DispatcherTimer timer; // Timer to update time

        // Constructor 
        public LoginScreen()
        {
            InitializeComponent();
            CurrentTime = DateTime.Now; // Set initial time
            s_bl.ResteClock(); // Reset clock
            DataContext = this; // Set DataContext to the instance of WatchWindow
            StartTimer(); // Start timer to update time

        }

        private DateTime currentTime; // Current time property

        public event PropertyChangedEventHandler PropertyChanged; // Event handler for property change


        // Current time property with OnPropertyChanged event
        public DateTime CurrentTime 
        {
            get { return currentTime; } // Get current time value
            set
            {
                if (currentTime != value) // If current time is not equal to new value
                {
                    currentTime = value; // Set current time to new value
                    OnPropertyChanged("CurrentTime"); // Call OnPropertyChanged event
                }
            }
        }

          // Start timer method that updates time every second
        private void StartTimer()
        {
            DispatcherTimer timer = new DispatcherTimer(); // Create a new instance of DispatcherTimer
            timer.Interval = TimeSpan.FromSeconds(1); // Set timer interval to 1 second
            // timer.Tick += Timer_Tick;
            timer.Start(); // Start timer
        }
        // Timer tick event that adds 1 hour to the current time
        private void Timer_Tick(object sender, EventArgs e)

        {
            CurrentTime = CurrentTime.AddHours(1); // Add 1 hour to the current time
        }

        // OnPropertyChanged event handler that updates the property
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // Invoke the PropertyChanged event with the property name
        }

        // Login button click event handler
        private void openManagerWindow_click(object sender, RoutedEventArgs e)
        {
            new password().Show(); // Create a new instance of password                           
        }

        // Reset button click event handler
        private void reset_click(object sender, RoutedEventArgs e)
        {
            // Ask the user for confirmation
            // its gonna show a message box with the question "Are you sure you want to reset the database?"
            MessageBoxResult result = MessageBox.Show("Are you sure you want to reset the database?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // If the user confirms, reset the database
            if (result == MessageBoxResult.Yes)
            {
                deleteXml.Initialization.Do();
                //          C.Initialization.Do();

                //BltTest.
                MessageBox.Show("Database reset successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Initialize button click event handler
        private void Initialization_Click(object sender, RoutedEventArgs e)
        {
            // Ask the user for confirmation
            // its gonna show a message box with the question "Are you sure you want to initialize the database?"
            MessageBoxResult result = MessageBox.Show("Are you sure you want to initialize the database?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // If the user confirms, initialize the database
            if (result == MessageBoxResult.Yes)
            {
                Initialization.Do(1);
                // Call the initialization method in DalTest
                MessageBox.Show("Database initialized successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Exit button click event handler
        private void EmployeeEntry_Click(object sender, RoutedEventArgs e)
        {
            new GetEngineerIdWindow().Show(); // Create a new instance of EmployeWindow
        }

        // OnPropertyChanged event handler that updates the property
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // if is the first time that the user click on the button
            if (s_bl.Schedule.getGantt())
                new Gantt().Show(); // Create a new instance of Gantt
            // if is not the first time that the user click on the button
            else
                MessageBox.Show("their is tasks without StartTime!");
        }

        // OnPropertyChanged event handler that updates the property
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CurrentTime = CurrentTime.AddDays(1); // Add 1 day to the current time
          //  s_bl.Clock.AddHour(1);
            s_bl.AddDay(1); // Add 1 day to the clock
           
        }

        // OnPropertyChanged event handler that updates the property
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CurrentTime = CurrentTime.AddHours(1); // Add 1 hour to the current time
            s_bl.AddHour(1); // Add 1 hour to the clock
        }
    }



}
 

