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

namespace PL.Engineer;

/// <summary>
/// Interaction logic for EngineerListWindow.xaml
/// </summary>
public partial class EngineerListWindow : Window
{
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get(); // Create a new instance of the BlApi class and store it in a static readonly variable 
    /// <summary>
    ///  the function that gonna show the EngineerListWindow and the list of the engineers by using the DependencyProperty that is a static member of the EngineerListWindow class
    /// </summary>
    public IEnumerable<BO.Engineer> EngineerList
    {
        get { return (IEnumerable<BO.Engineer>)GetValue(EngineerListProperty); } // Using GetValue and SetValue to get and set the value of the EngineerList property
        set { SetValue(EngineerListProperty, value); } // Using GetValue and SetValue to get and set the value of the EngineerList property
    }
    /// <summary>
    ///  the list of the engineers that we gonna show in the window by using the DependencyProperty that is a static member of the EngineerListWindow class
    /// </summary>
    public static readonly DependencyProperty EngineerListProperty =
        DependencyProperty.Register("EngineerList", typeof(IEnumerable<BO.Engineer>), typeof(EngineerWindow), new PropertyMetadata(null)); // Using DependencyProperty as the backing store for EngineerList.  This enables animation, styling, binding, etc...

        public EngineerListWindow()
        {
            InitializeComponent();
            EngineerList = s_bl?.Engineer.ReadAll()!;
        }

        public BO.EngineerExperience Level { get; set; } = BO.EngineerExperience.All;

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(Level == BO.EngineerExperience.All) // if the Level is equal to BO.EngineerExperience.All
            EngineerList = s_bl?.Engineer.ReadAll()!; // Using the BlApi to get all the engineers and store them in the EngineerList
        else
        EngineerList = s_bl?.Engineer.ReadAll(x => x != null && x.Level == Level)!; // Using the BlApi to get all the engineers and store them in the EngineerList and filter them by the Level
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
