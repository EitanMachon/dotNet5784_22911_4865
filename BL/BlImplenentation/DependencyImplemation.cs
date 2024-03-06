using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplenentation;

internal class DependencyImplemation : IDependency
{
    public int Create(BO.Dependcys Dependcys)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public BO.Dependcys? Read(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BO.Dependcys?> ReadAll(Func<BO.Dependcys, bool>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(BO.Dependcys Dependcys)
    {
        throw new NotImplementedException();
    }
}
