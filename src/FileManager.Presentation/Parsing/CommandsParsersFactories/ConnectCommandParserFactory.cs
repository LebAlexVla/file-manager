using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.ConnectArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.ConnectModeParsing.ConnectModeParserLinks;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public class ConnectCommandParserFactory : ICommandParserFactory
{
    public ICommandParserLink Create()
    {
        ICommandArgumentParserLink<ConnectCommandBuilder> connectArgumentsChain =
            new ConnectAddressParserLink().AddNext(
                new ConnectModeFlagParserLink(
                    new LocalConnectModeParser()));

        return new ConnectParserLink(connectArgumentsChain);
    }
}