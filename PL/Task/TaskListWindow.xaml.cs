using BlApi;
using PL.Engineer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace PL.Task
{
    /// <summary>
    /// Interaction logic for TaskListWindow.xaml
    /// </summary>
    public partial class TaskListWindow : Window
    {
        static readonly IBl s_bl = Factory.Get(); // Use IBl interface instead of BlApi class
        public BO.EngineerExperience Copmlexity { get; set; } = BO.EngineerExperience.All; // Create a new instance of the BO.EngineerExperience class and store it in a property
        public BO.Status status { get; set; } = BO.Status.Unscheduled; // Create a new instance of the BO.Status class and store it in a property
        public TaskListWindow()
        {
            InitializeComponent();
            TaskList = s_bl?.Task.ReadAll()!; // Using the BlApi to get all the tasks and store them in the TaskList
        }

        private void Button_Add_click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.ShowDialog();
            Update();
        }

        public IEnumerable<BO.Task> TaskList
        {
            get { return (IEnumerable<BO.Task>)GetValue(TaskListProperty); }
            set { SetValue(TaskListProperty, value); }
        }
        
        public static readonly DependencyProperty TaskListProperty =
            DependencyProperty.Register("TaskList", typeof(IEnumerable<BO.Task>), typeof(TaskListWindow), new PropertyMetadata(null));


        void Update()
        {
            if (Copmlexity == BO.EngineerExperience.All) // If the level is all, we get all the engineers
                TaskList = s_bl?.Task.ReadAll()?.OrderBy(item => item?.Alias); // Corrected orderBy usage
            else // If the level is not all, we get the engineers with the specified level
                TaskList = s_bl?.Task.ReadAll(x => x != null && x.Copmlexity == Copmlexity)?.OrderBy(item => item?.Alias);
       //     if (status == BO.Status.Unscheduled) // If the status is unscheduled, we get all the engineers
       //         TaskList = s_bl?.Task.ReadAll()?.OrderBy(item => item?.Alias); // Corrected orderBy usage
       //     else // If the status is not unscheduled, we get the engineers with the specified status
       //         TaskList = s_bl?.Task.ReadAll(x => x != null && x.status == status)?.OrderBy(item => item?.Alias);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update(); // Call the Update function to update the list of engineers
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Task? taskFromList = (sender as ListView)?.SelectedItem as BO.Task;
            if (taskFromList != null)
            {
                new TaskWindow(taskFromList!.Id).ShowDialog();
                Update();
            }

        }

        private void twoclicksbuttom(object sender, MouseButtonEventArgs e)
        {////
            
            BO.Task? taskFromList = (sender as ListView)?.SelectedItem as BO.Task;
            if (taskFromList != null)
            {

                new TaskWindow(taskFromList!.Id).ShowDialog();
                Update();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginScreen = new MainWindow();
            loginScreen.Show();
            Close(); // Close the password window                    
        }

        private void MouseDoubleClick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Task? taskFromList = (sender as ListView)?.SelectedItem as BO.Task;
            if (taskFromList != null)
            {
                new TaskWindow(taskFromList!.Id).ShowDialog();
                Update();
            }

        }

        private void MouseDoubleClick_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
