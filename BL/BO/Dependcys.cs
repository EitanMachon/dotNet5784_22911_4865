using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Dependcys
{
    public int Id { get; set; }
    public int DependentTask { get; set; }
    public int Depends { get; set; }
}
