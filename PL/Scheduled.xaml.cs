﻿using BlApi;
using PL.Task;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for Scheduled.xaml
    /// </summary>
    public partial class Scheduled : Window
    {
        static readonly IBl s_bl = Factory.Get(); // Use IBl interface instead of BlApi class

        public BO.Task Task // Create a new instance of the BO.Task class and store it in a property
        {
            get { return (BO.Task)GetValue(TaskProperty); } // Using GetValue and SetValue to get and set the value of the Task property
            set { SetValue(TaskProperty, value); } // Using GetValue and SetValue to get and set the value of the Task property
        }
        public static readonly DependencyProperty TaskProperty = DependencyProperty.Register("Task", typeof(BO.Task), typeof(Scheduled), new PropertyMetadata(null)); // Using DependencyProperty as the backing store for Task.  This enables animation, styling, binding, etc...
        
        public Scheduled(BO.Task task)
        {
            Task = task;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            s_bl.Task.Update(Task);
        }
    }
}
