using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public static class Tools
{
    /// <summary>
    /// this function gets any object and returns a string with all its properties and values
    /// </summary>
    public static string ToStringProperty<T>(this T obj) // this func gets any object and returns a string with all its properties and values
    {
        if (obj != null) // check if the object is not null
        {
            if (obj is IEnumerable)
            {
                IEnumerable objects = (IEnumerable)obj;
                string res = "";
                foreach (var item in objects)
                {
                    res += item.ToStringProperty() + ", ";
                }
                return $"[ {res} ]";
            }
            else
            {
                Type objType = obj.GetType(); // get the type of the object
                PropertyInfo[] properties = objType.GetProperties(); // get all the properties of the object

                string result = $"\nDetails for {objType.Name}:"; // start the result string with the name of the object

                foreach (PropertyInfo property in properties) // run all over the properties of the object
                {
                    object value = property.GetValue(obj); // get the value of the property

                    if (value != null) // check if the value is not null
                    {
                        if (property.PropertyType != typeof(string) && property.PropertyType.GetInterface(nameof(IEnumerable)) != null) // check if the property is not a string and is a collection
                        {
                            int count = 0; // start the count of the collection
                            foreach (var item in (IEnumerable<object>)value) // run all over the collection
                            {
                                result += "\n {"; // start the collection
                                result += $"{++count}:"; // add the count to the result
                                result += ToStringProperty(item); // add the item to the result
                                result += " }\n"; // end the collection
                            }
                        }
                        else if (property.PropertyType.Namespace == "BO" && property.PropertyType.IsClass) // check if the property is a BO object
                        {
                            result += "\n {\n"; // start the nested object
                            result += $"\nDetails for nested property {property.Name}:\n"; // add the name of the nested object

                            // Call ToStringProperty recursively for nested BO objects
                            result += ToStringProperty(value); // add the nested object to the result

                            result += " }\n"; // end the nested object
                        }
                        else
                        {
                            // Append property name and its value to the result
                            result += $"{property.Name} = {value}\n"; // add the property and its value to the result
                        }
                    }
                }
                return result; // return the result    
            }
        }
        else
        {
            // Handle case where object is null
            return $"{typeof(T).Name} object is null.\n";
        }
    }
}
