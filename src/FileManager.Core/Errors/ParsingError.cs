namespace FileManager.Core.Errors;

public class ParsingError : IError
{
    public ParsingError(string info)
    {
        Info = info;
    }

    public string Info { get; }
}