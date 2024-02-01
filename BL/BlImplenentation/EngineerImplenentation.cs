namespace BlImplenentation;
using DalApi;
using DO;
internal class EngineerImplenentation : IEngineer
{
    private IDal dal = new DalApi.IDal();
    //DalApi.IDal dal = new DalApi.DalApi();
    public int Create(Engineer item)
    {
        throw new NotImplementedException();

    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Engineer? Read(int id)
    {
        throw new NotImplementedException();
    }

    public Engineer? Read(Func<Engineer, bool> filter)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(Engineer item)
    {
        throw new NotImplementedException();
    }
}
