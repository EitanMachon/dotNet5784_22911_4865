namespace Dal;
using DalApi;
using System.Linq;
using System.Xml.Linq;

public class ScheduleImplementation : ISchedule
{
    static readonly string tasks_xml = "tasks"; // the file name to save the tasks
    static readonly string s_data_config_xml = "data-config"; // the file name to save the configuration

    public void SaveSchedule()
    {
        List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(tasks_xml);

        if (tasks.Count > 0) // save only if there are tasks
        {
            DateTime? startDate = tasks.Min(task => task.StartDate); // Find the minimum StartDate
            XElement config = XMLTools.LoadListFromXMLElement(s_data_config_xml); // load the configuration from the file 
            config.Element("ProjectStartDateTime")!.Value = startDate.HasValue ? startDate.Value.ToString() : ""; // update the start date
            XMLTools.SaveListToXMLElement(config, s_data_config_xml); // save the configuration to the file
        }
    }
    public DateTime? GetProjectStartDateTime()
    {
        XElement config = XMLTools.LoadListFromXMLElement(s_data_config_xml); // load the configuration from the file 
        string projectStartDateTimeString = config.Element("ProjectStartDateTime")?.Value;

        if (DateTime.TryParse(projectStartDateTimeString, out DateTime projectStartDateTime))
        {
            return projectStartDateTime;
        }
        else
        {
            return null; // Return null if the parsing fails
        }
    }
}
