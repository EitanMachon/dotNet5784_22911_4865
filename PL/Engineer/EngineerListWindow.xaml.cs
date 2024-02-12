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

    public IEnumerable<BO.Engineer> EngineerList
    {
        get { return (IEnumerable<BO.>)GetValue(CourseListProperty); }
        set { SetValue(CourseListProperty, value); }
    }

    public static readonly DependencyProperty CourseListProperty =
        DependencyProperty.Register("CourseList", typeof(IEnumerable<BO.CourseInList>), typeof(CourseListWindow), new PropertyMetadata(null));


    /// <summary>
    /// this func gonna show the EngineerListWindow
    /// </summary>
    public EngineerListWindow()
    {
        InitializeComponent();
    }
    
  
}
