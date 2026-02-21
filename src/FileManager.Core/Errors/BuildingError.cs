namespace FileManager.Core.Errors;

public class BuildingError : IError
{
    public BuildingError(string info)
    {
        Info = info;
    }

    public string Info { get; }
}