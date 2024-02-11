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
            DateTime? startDate = tasks.First().StartDate; // read the first task start date
            DateTime? endDate = tasks.Last().DeadLinetime; // read the first task end date

            XElement config = XMLTools.LoadListFromXMLElement(s_data_config_xml); // load the configuration from the file 

            config.Element("ProjectStartDateTime").Value = startDate == null ? "" : startDate.ToString(); // update the start date
            config.Element("ProjectEndDateTime").Value = endDate == null ? "" : endDate.ToString(); // update the end date

            XMLTools.SaveListToXMLElement(config, s_data_config_xml); // save the configuration to the file
        }
    }
}
