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


    /// <summary>
    /// this func gonna show the EngineerListWindow
    /// </summary>
    public EngineerListWindow() // the constructor of the EngineerListWindow class
    {
        InitializeComponent(); // Initialize the EngineerListWindow
        EngineerList = s_bl?.Engineer.ReadAll()!; // Using the BlApi to get all the engineers and store them in the EngineerList
    }
    public BO.EngineerExperience Level { get; set; } = BO.EngineerExperience.All; // Create a new instance of the BO.EngineerExperience class and store it in a property and give it a diffult value of BO.EngineerExperience.Beginner

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //if(Level == BO.EngineerExperience.All) // if the Level is equal to BO.EngineerExperience.All
        //    EngineerList = s_bl?.Engineer.ReadAll()!; // Using the BlApi to get all the engineers and store them in the EngineerList
        //else
        //    EngineerList = s_bl?.Engineer.ReadAll(x => x.Level == Level)!; // Using the BlApi to get all the engineers and store them in the EngineerList and filter them by the Level
        EngineerList = (Level == BO.EngineerExperience.All) ?
       s_bl?.Engineer.ReadAll()! : s_bl?.Engineer.ReadAll(item => item.Level == Level);

    }

}
