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
using BO;
namespace PL
{
    /// <summary>
    /// Interaction logic for Gantt.xaml
    /// </summary>
    public partial class Gantt : Window
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get(); // Create a new instance of the BlApi class and store it in a static readonly variable
        public DateTime gapTime // Create a new instance of the BO.Engineer class and store it in a property
        {
            get { return (DateTime)GetValue(orech); }
            set { SetValue(orech, value); } }

        public static readonly DependencyProperty orech = DependencyProperty.Register("gapTime", typeof(DateTime), typeof(Gantt), new PropertyMetadata(null));

        public List<BO.Task> TaskList
        {
            get { return (List<BO.Task>)GetValue(TaskListProperty); }
            set { SetValue(TaskListProperty, value); }
        }

        public static readonly DependencyProperty TaskListProperty = DependencyProperty.Register("TaskList", typeof(List<BO.Task>), typeof(Gantt), new PropertyMetadata(null));

        public Gantt()
        {
            TaskList = s_bl.Task.ReadAll().ToList()!;
                

        }



    }
}
