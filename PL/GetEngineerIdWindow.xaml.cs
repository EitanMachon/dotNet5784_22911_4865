using PL.Task;
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
    /// Interaction logic for GetEngineerIdWindow.xaml
    /// </summary>
    public partial class GetEngineerIdWindow : Window
    {

        public int Id // read iud from window
        {
            get { return (int)GetValue(TaskProperty); } // Using GetValue and SetValue to get and set the value of the Task property
            set { SetValue(TaskProperty, value); } // Using GetValue and SetValue to get and set the value of the Task property
        }
        public static readonly DependencyProperty TaskProperty = DependencyProperty.Register("Id", typeof(int), typeof(TaskWindow), new PropertyMetadata(null)); // Using DependencyProperty as the backing store for Task.  This enables animation, styling, binding, etc...


        public GetEngineerIdWindow()
        {
            InitializeComponent();
        }

        private void ClickOk(object sender, RoutedEventArgs e)
        {
            // var EngineerIdTask = TaskProperty.Where{}


            try
            {
                new EMPLOEYVIEWENGINEERLIST(Id).Show();
                this.Close();
            }
            catch {
                MessageBox.Show("Their is no id like that!"); // Show a message to the user
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //new LoginScreen().Show();
            this.Close();
        }
    }
}
