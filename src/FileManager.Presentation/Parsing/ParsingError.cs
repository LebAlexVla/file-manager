namespace FileManager.Presentation.Parsing;

public class ParsingError
{
    public ParsingError(string info)
    {
        Info = info;
    }

    public string Info { get; }
}