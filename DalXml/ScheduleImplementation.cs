namespace Dal;
using DalApi;
using System.Xml.Linq;

public class ScheduleImplementation : ISchedule
{
    public DateTime? GetEndDate()
    {
        XElement root = XMLTools.LoadListFromXMLElement("data-config");

        return (DateTime)root.Element("ProjectEndDate")!;

    }

    public DateTime? GetStartDate()
    {
        XElement root = XMLTools.LoadListFromXMLElement("data-config");

        if (root.Element("ProjectStartDate") == null)
            return null;

        return (DateTime)root.Element("ProjectStartDate")!;
    }


    public void SetEndDate(DateTime? endDate)
    {
        XElement root = XMLTools.LoadListFromXMLElement("data-config");

        root.Element("ProjectEndDate")!.Value = endDate.ToString();

        XMLTools.SaveListToXMLElement(root, "data-config");
    }

    public void SetStartDate(DateTime? endDate)
    {
        XElement root = XMLTools.LoadListFromXMLElement("data-config");

        root.Element("ProjectStartDate")!.Value = endDate.ToString();

        XMLTools.SaveListToXMLElement(root, "data-config");
    }

}

