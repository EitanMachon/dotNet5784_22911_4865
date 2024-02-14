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
using BlApi; // Import the namespace where BlApi is located

namespace PL.Engineer
{
    /// <summary>
    /// Interaction logic for EngineerListWindow.xaml
    /// </summary>
    public partial class EngineerListWindow : Window
    {
        static readonly IBl s_bl = Factory.Get(); // Use IBl interface instead of BlApi class

        public IEnumerable<BO.Engineer> EngineerList
        {
            get { return (IEnumerable<BO.Engineer>)GetValue(EngineerListProperty); }
            set { SetValue(EngineerListProperty, value); }
        }

        public static readonly DependencyProperty EngineerListProperty =
            DependencyProperty.Register("EngineerList", typeof(IEnumerable<BO.Engineer>), typeof(EngineerListWindow), new PropertyMetadata(null));

        public EngineerListWindow()
        {
            InitializeComponent();
            EngineerList = s_bl?.Engineer.ReadAll()!;
        }

        public BO.EngineerExperience Level { get; set; } = BO.EngineerExperience.All;

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Button_Add_click(object sender, RoutedEventArgs e)
        {
            EngineerWindow engineerWindow = new EngineerWindow();
            engineerWindow.ShowDialog();
            Update();
        }

        private void twoclicksbuttom(object sender, MouseButtonEventArgs e)
        {
            BO.Engineer? engineerFromList = (sender as ListView)?.SelectedItem as BO.Engineer;
            if (engineerFromList != null)
            {
                new EngineerWindow(engineerFromList!.Id).ShowDialog();
                Update();
            }
        }

        void Update()
        {
            if (Level == BO.EngineerExperience.All)
                EngineerList = s_bl?.Engineer.ReadAll()?.OrderBy(item => item?.Name); // Corrected orderBy usage
            else
                EngineerList = s_bl?.Engineer.ReadAll(x => x != null && x.Level == Level)?.OrderBy(item => item?.Name);
        }
    }
}
