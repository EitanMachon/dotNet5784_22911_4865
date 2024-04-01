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
using BlApi;
namespace PL
{
    /// <summary>
    /// Interaction logic for EmployeWindow.xaml
    /// </summary>
    public partial class EmployeWindow : Window
    {

        static readonly IBl s_bl = Factory.Get(); // Use IBl interface instead of BlApi class
        /// <summary>
        /// this function is used to get the list of engineers
        /// </summary>
        ///  public BO.EngineerExperience Copmlexity { get; set; } = BO.EngineerExperience.All; // Create a new instance of the BO.EngineerExperience class and store it in a property
        public BO.Status Status { get; set; } = BO.Status.Unscheduled; // Create a new instance of the BO.Status class and store it in a property

        public BO.Task employeTask // Create a new instance of the BO.Task class and store it in a property
        {
            get { return (BO.Task)GetValue(EmployeProperty); }
            set { SetValue(EmployeProperty, value); } 
        }
        public static readonly DependencyProperty EmployeProperty = DependencyProperty.Register("employeTask", typeof(BO.Task), typeof(EmployeWindow), new PropertyMetadata(null)); // Using DependencyProperty as the backing store for Employe.  This enables animation, styling, binding, etc...
        
        public EmployeWindow(int i = 0) // the constructor of the EmployeWindow class that get a parameter with a default value of 0
        {
            InitializeComponent(); // Initialize the EmployeWindow
            if (i == 0) // if the id of the task is equal to 0
            {
                employeTask = new BO.Task(); // Create a new instance of the BO.Task class and store it in a property and give it a diffult value of 0
            }
            else // if the id of the task is not equal to 0
            {
                employeTask = s_bl?.Task.Read(i)!; // Using the BlApi to get the task by the id and store it in the employeTask
            }
        }

        // event handler for clicking the OK button
        private void Button_Click(object sender, RoutedEventArgs e)
        {

                s_bl?.Task.Update(employeTask); // Using the BlApi to update the task
                MessageBox.Show("The task has been updated successfully"); // Show a message to the user
            
            Close(); // Close the TaskWindow

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
