using System.Collections;
using System.Collections.Generic;

namespace PL;
/// <summary>
/// this class conect the PL and the Enums of the BL by using the IEnumerable by using the GetEnumerator function
/// </summary>
internal class LevelCollection : IEnumerable
{
    static readonly IEnumerable<BO.EngineerExperience> s_enums = (Enum.GetValues(typeof(BO.EngineerExperience)) as IEnumerable<BO.EngineerExperience>)!; // Create a new instance of the IEnumerable<BO.EngineerExperience> class and store it in a static readonly variable
    public IEnumerator GetEnumerator() => s_enums.GetEnumerator(); // the function that gonna return the IEnumerator of the s_enums
}
