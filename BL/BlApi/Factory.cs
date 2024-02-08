
namespace BlApi;
/// <summary>
/// this class is used to get the instance of the BL layer
/// </summary>
public static class Factory
{
    /// <summary>
    ///  this function is used to get the instance of the BL layer by creating a new instance of the BL layer
    /// </summary>
    public static IBl Get() => new BlImplementation.Bl(); // it's call the constructor of the Bl class and return the instance of the Bl class

}
