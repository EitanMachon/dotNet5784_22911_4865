using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

[Serializable]
public class DalAlreadyExistsException : Exception
{
    public DalAlreadyExistsException(string? message) : base(message) { }
}

public class DalDeletionImpossible : Exception
{
    public DalDeletionImpossible(string? message) : base(message) { }
}

public class DalConfigException : Exception
{
    public DalConfigException(string? message) : base(message) { }
}

public class NotFoundId : Exception
{
    public NotFoundId(string? message) : base(message) { }
    
}




public class DalXMLFileLoadCreateException : Exception
    {
       public DalXMLFileLoadCreateException(string? message) : base(message) { }
    }

public class DalUpdateImpossible : Exception
{
       public DalUpdateImpossible(string? message) : base(message) { }
}