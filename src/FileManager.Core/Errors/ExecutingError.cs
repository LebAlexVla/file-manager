namespace FileManager.Core.Errors;

public class ExecutingError : IError
{
    public ExecutingError(string info)
    {
        Info = info;
    }

    public string Info { get; }
}