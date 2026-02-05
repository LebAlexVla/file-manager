using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.ConnectArgumentsParserLinks;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public class ConnectCommandParserFactory : ICommandParserFactory
{
    public ICommandParserLink Create()
    {
        ICommandArgumentParserLink<ConnectCommandBuilder> connectArgumentsChain =
            new ConnectAddressParserLink().AddNext(
                new ConnectModeFlagParserLink());

        return new ConnectParserLink(connectArgumentsChain);
    }
}