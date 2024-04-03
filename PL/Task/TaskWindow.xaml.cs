using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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
using BlApi; // Import the namespace where BlApi is located

namespace PL.Task
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window, INotifyPropertyChanged
    {


        private DateTime currentTime;


        public DateTime CurrentTime
        {
            get { return currentTime; }
            set
            {
                if (currentTime != value)
                {
                    currentTime = value;
                    OnPropertyChanged("CurrentTime");
                }
            }
        }


        private void StartTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            // timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)

        {
            CurrentTime = CurrentTime.AddHours(1);
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        static readonly IBl s_bl = Factory.Get(); // Use IBl interface instead of BlApi class
        public BO.EngineerExperience Complexity { get; set; } = BO.EngineerExperience.All; // Create a new instance of the BO.EngineerExperience class and store it in a property
        public BO.Status Status { get; set; } = BO.Status.Unscheduled; // Create a new instance of the BO.Status class and store it in a property

        public static List<BO.TaskInList> SelectedDep = new List<BO.TaskInList>(); // Create a new instance of the List<BO.TaskInList> class and store it in a property
        private int num;

        public TaskWindow(int i = 0) // the constructor of the TaskWindow class that get a parameter with a default value of 0
        {
            num= i;
            InitializeComponent(); // Initialize the TaskWindow
            TaskListIdAlias = s_bl?.Task.ReadAll().Select(t => new BO.TaskInList { Id = t.Id, Description = t.Description, Alias = t.Alias, status = t.status });  // Using the BlApi to get all the tasks and store them in the TaskListIdAlias


            if (i == 0) // if the id of the task is equal to 0
            {
                Task = new BO.Task(); // Create a new instance of the BO.Task class and store it in a property and give it a diffult value of 0
            }
            else // if the id of the task is not equal to 0
            {
                Task = s_bl?.Task.Read(i)!; // Using the BlApi to get the task by the id and store it in the Task
                SelectedDep = Task.Dependencys; // Store the dependencies of the task in the SelectedDep
            }
            DataContext = this; // Set DataContext to this window instance
            CurrentTime = DateTime.Now; // Set initial time
        }



        public BO.Task Task // Create a new instance of the BO.Task class and store it in a property
        {
            get { return (BO.Task)GetValue(TaskProperty); } // Using GetValue and SetValue to get and set the value of the Task property
            set { SetValue(TaskProperty, value); } // Using GetValue and SetValue to get and set the value of the Task property
        }
        public static readonly DependencyProperty TaskProperty = DependencyProperty.Register("Task", typeof(BO.Task), typeof(TaskWindow), new PropertyMetadata(null)); // Using DependencyProperty as the backing store for Task.  This enables animation, styling, binding, etc...

        public event PropertyChangedEventHandler? PropertyChanged;

        private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Ask the user for confirmation
            // its gonna show a message box with the question "Are you sure you want to initialize the database?"
            //TextBox TextBox_TextChanged;//= sender as TextBox; // Cast the sender to TextBox

            // MessageBoxResult result = MessageBox.Show("Are you creat a new Task?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // If the user confirms, initialize the database
            // if (result == MessageBoxResult.Yes)
            
            // Call the initialization method in DalTest
           
        }
        public IEnumerable<BO.TaskInList> TaskListIdAlias
        {
            get { return (IEnumerable<BO.TaskInList>)GetValue(TaskListIdAliasProperty); }
            set { SetValue(TaskListIdAliasProperty, value); }
        }

        public static readonly DependencyProperty TaskListIdAliasProperty =
            DependencyProperty.Register("TaskListIdAlias", typeof(IEnumerable<BO.TaskInList>), typeof(TaskWindow), new PropertyMetadata(null));
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Close the password window        
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (num == 0)
            {
                try
                {
                    Task.Dependencys = SelectedDep; // Store the dependencies of the task in the SelectedDep
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
                    Task.Dependencys = SelectedDep; // Store the dependencies of the task in the SelectedDep

                    s_bl?.Task.Update(Task); // Using the BlApi to update the task
          
                    MessageBox.Show("The task has been updated successfully"); // Show a message to the user
                }
                catch
                {
                    MessageBox.Show("Their is no engineer with id like that!"); // Show a message to the user
                }
            }

            Close(); // Close the TaskWindow

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void ResetDependencysExpander_Expanded(object sender, RoutedEventArgs e)
        {
            SelectedDep.Clear();

        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
        }
        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (num == 0)
            {
                MessageBox.Show("You need to create the task before the Scheduled select!!"); // Show a message to the user
            }
            else
            {
                new Scheduled(Task).Show();
            }
        }
        private void TaskListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedDep.Clear();
            foreach (BO.TaskInList task in TaskListBox.SelectedItems)
            {
                var temp = s_bl.Task.Read(task.Id);
                SelectedDep.Add(new BO.TaskInList
                {
                    Id = temp.Id,
                    Alias = temp.Alias,
                    Description = temp.Description,
                    status = temp.status
                }
                    );
            }
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox; // Cast the sender to TextBox
           
        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {

        }
    }
}
