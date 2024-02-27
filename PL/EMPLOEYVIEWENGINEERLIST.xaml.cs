using BlApi;
using PL.Task;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for EMPLOEYVIEWENGINEERLIST.xaml
    /// </summary>
    public partial class EMPLOEYVIEWENGINEERLIST : Window
    {
        static readonly IBl s_bl = Factory.Get(); // Use IBl interface instead of BlApi class


        public IEnumerable<BO.Task> TasksList
        {
            get { return (IEnumerable<BO.Task>)GetValue(TasksListProperty); } // Using GetValue and SetValue to get and set the value of the Task property
            set { SetValue(TasksListProperty, value); } // Using GetValue and SetValue to get and set the value of the Task property
        }
        public static readonly DependencyProperty TasksListProperty = DependencyProperty.Register("TasksList", typeof(IEnumerable<BO.Task>), typeof(EMPLOEYVIEWENGINEERLIST), new PropertyMetadata(null)); // Using DependencyProperty as the backing store for Task.  This enables animation, styling, binding, etc...

        public EMPLOEYVIEWENGINEERLIST(int engId) // get id of engineer
        {
            InitializeComponent();

            // read all engineer's tasks
            TasksList = s_bl.Task.ReadAll(t => t.Engineer.Id == engId);
        }

        private void twoclicksbuttom(object sender, MouseButtonEventArgs e)
        {
            BO.Task? task = (sender as ListView).SelectedItem as BO.Task;
            if (task != null)
            {
                new EmployeWindow(task.Id).Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            Close(); // Close the password window        
        
    }
    }
}
