using Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BlApi;
public static class Factory
{
    public static IBl Get() => new BlImplementation.Bl();

}
