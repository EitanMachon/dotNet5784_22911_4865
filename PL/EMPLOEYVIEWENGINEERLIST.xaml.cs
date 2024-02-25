using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for EMPLOEYVIEWENGINEERLIST.xaml
    /// </summary>
    public partial class EMPLOEYVIEWENGINEERLIST : Window
    {
        public EMPLOEYVIEWENGINEERLIST()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (EngineerId == BO.EngineerExperience.All) // If the level is all, we get all the engineers
        //        EngineerList = s_bl?.Engineer.ReadAll()?.OrderBy(item => item?.Name); // Corrected orderBy usage
        //    else // If the level is not all, we get the engineers with the specified level
        //        EngineerList = s_bl?.Engineer.ReadAll(x => x != null && x.Level == Level)?.OrderBy(item => item?.Name);
        //}
    }
}
