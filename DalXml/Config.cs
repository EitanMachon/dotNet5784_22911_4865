using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class Config
    {
        static string s_data_config_xml = "data-config";
        internal static int DependencyId { get => XMLTools.GetAndIncreaseNextId(s_data_config_xml, "DependencyId"); }//START
        internal static int TaskId { get => XMLTools.GetAndIncreaseNextId(s_data_config_xml, "TaskId"); }
        
    }
}
