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
        public IEnumerable<BO.Engineer> EngineerList
        {
            get { return (IEnumerable<BO.Engineer>)GetValue(EngineerListProperty); }
            set { SetValue(EngineerListProperty, value); }
        }

        private void SetValue(object engineerListProperty, IEnumerable<BO.Engineer> value)
        {
            throw new NotImplementedException();
        }

        public EmployeWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
