using BlApi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace PL;

class ConvertIdToContent : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)value == 0 ? "Add" : "Update"; // if the value is equal to 0 return "Add" else return "Update"
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

class ConverIdToContentKey : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)value == 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

class ConevrLastInListToInt : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var tempList = (List<BO.Task>)value; // cast the value to a list of tasks
        DateTime? latest = null; // create a nullable DateTime
        foreach (var item in tempList) // iterate through the list
        {
            var temp = item.StartDate + item.RequiredEffort;   // add the start date and the required effort of the task
            if (temp > latest) // if the temp is greater than the latest
            {
                latest = temp;
            }
        }

        // Convert latest DateTime to integer (assuming you want the number of ticks)
        int latestInt = ((int)(latest?.Ticks ?? 0)); // convert the latest DateTime to an integer

        return latestInt;

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }


}

class ConvertEffortTimeToWidth : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var temp = (TimeSpan)value; // store the required effort of the task in a variable
        return temp * 10; // return the required effort multiplied by 10
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

class ConvertStartDateToMargin : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var temp = (DateTime?)value; // store the start date of the task in a variable
        //FIX margin
        return new System.Windows.Thickness(100, 0, 0, 0); // return a new instance of the Thickness class

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

class ConvertTaskStatusToColor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var temp = (BO.Status)value; // cast the value to a status
        if (temp == 0) // if the status is equal to 0
        {
            return "Red"; // return "Red"
        }
        else if ((int)temp == 1) // if the status is equal to 1
        {
            return "Green"; // return "Green"
        }
        else if ((int)temp == 2) // if the status is equal to 2
        {
            return "Yellow"; // return "Yellow"
        }
        else if ((int)temp == 3) // if the status is equal to 3
        {
            return "Blue"; // return "Blue"
        }
        else
        {
            return "Black"; // return "Black"
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}