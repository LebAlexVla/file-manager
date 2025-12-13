using FileManager.Presentation.Parsing.CommandsParserLinks;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public class DisconnectCommandParserFactory : ICommandParserFactory
{
    public ICommandParserLink Create()
    {
        return new DisconnectParserLink();
    }
}