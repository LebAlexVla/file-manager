using FileManager.Presentation.Parsing.CommandsParsersFactories;
using FileManager.Presentation.Parsing.ParsingAbstractions.Commands;

namespace FileManager.Presentation.Parsing;

public class ParserFactory : IParserFactory
{
    public ICommandParserLink Create()
    {
        var connectParserFactory = new ConnectCommandParserFactory();
        var disconnectParserFactory = new DisconnectCommandParserFactory();
        var treeParserFactory = new TreeCommandParserFactory();
        var fileParserFactory = new FileCommandParserFactory();

        ICommandParserLink connectParser = connectParserFactory.Create();
        ICommandParserLink disconnectParser = disconnectParserFactory.Create();
        ICommandParserLink treeParser = treeParserFactory.Create();
        ICommandParserLink fileParser = fileParserFactory.Create();

        return connectParser
            .AddNext(disconnectParser)
            .AddNext(treeParser)
            .AddNext(fileParser);
    }
}