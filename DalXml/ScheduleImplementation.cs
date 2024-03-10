namespace Dal;
using DalApi;
using System.Diagnostics;
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
            DateTime? scheduleDate = tasks.Min(task => task.ScheduledTime); // Find the minimum StartDate
            XElement config = XMLTools.LoadListFromXMLElement(s_data_config_xml); // load the configuration from the file 
            config.Element("ProjectStartDateTime")!.Value = scheduleDate.HasValue ? scheduleDate.Value.ToString() : ""; // update the start date
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

    public bool getTasks()
    {
        List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(tasks_xml);
        if(tasks.All(task => task.ScheduledTime != null))
        {
            SaveSchedule();
            return true;
        }
        return false;
    }

    public DateTime? GetNowDate()
    {
        XElement root = XMLTools.LoadListFromXMLElement("data-config");
        XElement loozElement = root.Element("NowDate")!;
        if (loozElement.Value == "")
            return null;

        return DateTime.Parse(loozElement.Value);
    }

    public void SetNowDate(DateTime? nowDate)
    {
        XElement root = XMLTools.LoadListFromXMLElement("data-config");
        root.Element("NowDate")!.Value = nowDate.ToString()!;
        XMLTools.SaveListToXMLElement(root, "data-config");
    }
}
