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
        /// <summary>
        /// this function is used to get the list of engineers
        /// </summary>
        public IEnumerable<BO.Engineer> EngineerList
        {
            get { return (IEnumerable<BO.Engineer>)GetValue(EngineerListProperty); }
            set { SetValue(EngineerListProperty, value); }
        }

        public static readonly DependencyProperty EngineerListProperty =
            DependencyProperty.Register("EngineerList", typeof(IEnumerable<BO.Engineer>), typeof(EngineerListWindow), new PropertyMetadata(null));
        /// <summary>
        /// this function is used to initialize the engineer list window
        /// </summary>
        public EngineerListWindow()
        {
            InitializeComponent();
            EngineerList = s_bl?.Engineer.ReadAll()!;
        }
        
        public BO.EngineerExperience Level { get; set; } = BO.EngineerExperience.All;
        /// <summary>
        /// this function is used to update the list of engineers in the window
        /// </summary>
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update(); // Call the Update function to update the list of engineers
        }
        /// <summary>
        /// this function is used to add a new engineer to the list when the add button is clicked
        /// </summary>
        private void Button_Add_click(object sender, RoutedEventArgs e)
        {
            EngineerWindow engineerWindow = new EngineerWindow();
            engineerWindow.ShowDialog();
            Update();
        }
        /// <summary>
        /// when we double click on an engineer in the list, we open the engineer window to edit the engineer details
        /// </summary>
        private void twoclicksbuttom(object sender, MouseButtonEventArgs e)
        {
            BO.Engineer? engineerFromList = (sender as ListView)?.SelectedItem as BO.Engineer; 
            if (engineerFromList != null)
            {
                new EngineerWindow(engineerFromList!.Id).ShowDialog();
                Update();
            }
        }
        /// <summary>
        /// this function is used to update the list of engineers in the window
        /// </summary>
        void Update()
        {
            if (Level == BO.EngineerExperience.All) // If the level is all, we get all the engineers
                EngineerList = s_bl?.Engineer.ReadAll()?.OrderBy(item => item?.Name); // Corrected orderBy usage
            else // If the level is not all, we get the engineers with the specified level
                EngineerList = s_bl?.Engineer.ReadAll(x => x != null && x.Level == Level)?.OrderBy(item => item?.Name);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Engineer? engineerFromList = (sender as ListView)?.SelectedItem as BO.Engineer;
            if (engineerFromList != null)
            {
                new EngineerWindow(engineerFromList!.Id).ShowDialog();
                Update();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
