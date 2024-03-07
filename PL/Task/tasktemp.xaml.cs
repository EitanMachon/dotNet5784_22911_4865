using BlApi;
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
using BO;
using System.Collections.ObjectModel; // Import the namespace where BlApi is located

namespace PL.Task;

/// <summary>
/// Interaction logic for tasktemp.xaml
/// </summary>
public partial class tasktemp : Window
{
    static readonly IBl s_bl = Factory.Get(); // Use IBl interface instead of BlApi class
    public IEnumerable<BO.Task>? AllTasks = s_bl?.Task.ReadAll(); // Create a new instance of the IEnumerable<BO.Task> class and store it in a property
    public bool IsSelected { get; set; } = false; // Create a new instance of the bool class and store it in a property
    public BO.EngineerExperience Complexity { get; set; } = BO.EngineerExperience.All; // Create a new instance of the BO.EngineerExperience class and store it in a property
    public BO.Status Status { get; set; } = BO.Status.Unscheduled; // Create a new instance of the BO.Status class and store it in a property

    public BO.Task Task // Create a new instance of the BO.Task class and store it in a property
    {
        get { return (BO.Task)GetValue(TaskProperty); } // Using GetValue and SetValue to get and set the value of the Task property
        set { SetValue(TaskProperty, value); } // Using GetValue and SetValue to get and set the value of the Task property
    }
    public static readonly DependencyProperty TaskProperty = DependencyProperty.Register("Task", typeof(BO.Task), typeof(TaskWindow), new PropertyMetadata(null)); // Using DependencyProperty as the backing store for Task.  This enables animation, styling, binding, etc...


    public tasktemp(int i = 0)
    {
        try
        {
            InitializeComponent(); // Initialize the TaskWindow
            if (i == 0) // if the id of the task is equal to 0
            {
                Task = new BO.Task(); // Create a new instance of the BO.Task class and store it in a property and give it a diffult value of 0
            }
            else // if the id of the task is not equal to 0
            {
                Task = s_bl?.Task.Read(i)!; // Using the BlApi to get the task by the id and store it in the Task
            }
            var SelectedTasks = new ObservableCollection<BO.Task>();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        
    }

    private void CloseBttm(object sender, RoutedEventArgs e)
    {
        try // try to do the following
        {
            Close(); // Close the window
        }
        catch (Exception ex) // if there is an exception
        {
            MessageBox.Show(ex.Message); // Show a message to the user
        }
    }

    private void SaveBttm(object sender, RoutedEventArgs e) // The method that will be called when the user clicks the Save button
    { 
        TextBox TextBox_TextChanged;//= sender as TextBox; // Cast the sender to TextBox

        MessageBoxResult result = MessageBox.Show("Are you creat a new Task?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

        // If the user confirms, initialize the database
        if (result == MessageBoxResult.Yes)
        {
            // Call the initialization method in DalTest
            try
            {
                s_bl?.Task.Create(Task); // Using the BlApi to create the task

                MessageBox.Show("The task has been created successfully"); // Show a message to the user
            }
            catch
            {
                MessageBox.Show("Their is no engineer with Id like that!"); // Show a message to the user
            }
            
        }

        else
        {
            try
            {
                s_bl?.Task.Update(Task); // Using the BlApi to update the task
                MessageBox.Show("The task has been updated successfully"); // Show a message to the user
            }
            catch
            {
                MessageBox.Show("Their is no engineer wit id like that!"); // Show a message to the user
            }
        }
        Close();
    }
}
