

namespace BlApi;

public interface IDependency
{
    public int Create(BO.Dependcys Dependcys);

    public BO.Dependcys? Read(int id);

    public IEnumerable<BO.Dependcys?> ReadAll(Func<BO.Dependcys, bool>? filter = null);

    public void Update(BO.Dependcys Dependcys);

    public void Delete(int id);

    
}
