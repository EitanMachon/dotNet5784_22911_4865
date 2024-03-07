using PL.Engineer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Generic;
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
            set { SetValue(orech, value); } 
        }
        public static readonly DependencyProperty orech = DependencyProperty.Register("gapTime", typeof(DateTime), typeof(Gantt), new PropertyMetadata(null));

        public DateTime withGap // Create a new instance of the BO.Engineer class and store it in a property
        {
            get { return (DateTime)GetValue(withGapProperty); }
            set { SetValue(withGapProperty, value); }
        }
        
        public IEnumerable<BO.Task> data // Create a new instance of the BO.Engineer class and store it in a property
        {
            get { return (IEnumerable<BO.Task>)GetValue(dataProperty); }
            set { SetValue(dataProperty, value); }
        }
        public static readonly DependencyProperty dataProperty = DependencyProperty.Register("data", typeof(IEnumerable<BO.Task>), typeof(Gantt), new PropertyMetadata(null));

        public static readonly DependencyProperty withGapProperty = DependencyProperty.Register("withGap", typeof(DateTime), typeof(Gantt), new PropertyMetadata(null));
        public Gantt()  // when the Gantt window is opened we want to create a new instance of the BO.TaskInList class and store it in a property
        {
            data = s_bl.Task.ReadAll()!; // Create a new instance of the BO.TaskInList class and store it in a property 
            InitializeComponent();
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
