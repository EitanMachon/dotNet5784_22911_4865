using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
/// Interaction logic for EngineerWindow.xaml
/// </summary>
public partial class EngineerWindow : Window
{
    int id { get; set; }
    public BO.Engineer Engineer // Create a new instance of the BO.Engineer class and store it in a property
    {
        get { return (BO.Engineer)GetValue(EngineerProperty); } // Using GetValue and SetValue to get and set the value of the Engineer property
        set { SetValue(EngineerProperty, value); } // Using GetValue and SetValue to get and set the value of the Engineer property
    }
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get(); // Create a new instance of the BlApi class and store it in a static readonly variable
    public static readonly DependencyProperty EngineerProperty = DependencyProperty.Register("Engineer", typeof(BO.Engineer), typeof(EngineerWindow), new PropertyMetadata(null)); // Using DependencyProperty as the backing store for Engineer.  This enables animation, styling, binding, etc...
    /// <summary>
    /// This func assign the value of the Engineer property to the value of the parameter
    /// </summary>
    public EngineerWindow(int i = 0) // the constructor of the EngineerWindow class that get a parameter with a default value of 0
    {
        id = i; // Assign the value of the parameter to the id property
        InitializeComponent(); // Initialize the EngineerWindow
        if (i == 0) // if the id of the engineer is equal to 0
        {
            Engineer = new BO.Engineer(); // Create a new instance of the BO.Engineer class and store it in a property and give it a diffult value of 0
        }
        else // if the id of the engineer is not equal to 0
        {
            Engineer = s_bl?.Engineer.Read(i)!; // Using the BlApi to get the engineer by the id and store it in the Engineer
        }
    }

    /// <summary>
    /// this func gonna close the EngineerWindow and update the engineer by using the BlApi
    /// </summary>
    private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
    {
        try // try to update the engineer by using the BlApi
        {
            if (id == 0)
            {
                s_bl?.Engineer.Create(Engineer); // Using the BlApi to create the engineer
                MessageBox.Show("The engineer has been created successfully"); // Show a message to the user              
            }
            else
            {

                s_bl?.Engineer.Update(Engineer); // Using the BlApi to update the engineer
                MessageBox.Show("The engineer has been updated successfully"); // Show a message to the user                
            }
            Close(); // Close the EngineerWindow
        }
        catch (Exception ex) // if there is an exception
        {
            MessageBox.Show(ex.Message); // Show a message to the user
        }
    }
}
