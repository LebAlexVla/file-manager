using FileManager.Presentation.Parsing.CommandsParsing.Disconnect;
using FileManager.Presentation.Parsing.ParsingAbstractions.Commands;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public class DisconnectCommandParserFactory : ICommandParserFactory
{
    public ICommandParserLink Create()
    {
        return new DisconnectParserLink();
    }
}