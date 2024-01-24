using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DalApi;
using DalXml;
//using Do;
namespace Dal;




//stage 3
sealed public class DalXml : IDal
{
    public ITask itask => new TaskImplementation();

    public IDependency idependancy => new DepandencyImplemantion();

    public IEngineer iengineer => new EngineerImplementation();

}
