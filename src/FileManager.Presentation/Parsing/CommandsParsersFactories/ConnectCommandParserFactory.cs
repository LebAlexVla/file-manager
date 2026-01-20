using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing.FlagsArgumentsParserLinks;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public class ConnectCommandParserFactory : ICommandParserFactory
{
    public ICommandParserLink Create()
    {
        IFlagArgumentParserLink<ConnectCommandBuilder> flagParametersChain =
            new ConnectModeLocalParserLink();

        ICommandArgumentParserLink<ConnectCommandBuilder> commandArgumentsChain =
            new ConnectAddressParserLink()
                .AddNext(new ConnectModeFlagParserLink(flagParametersChain));

        return new ConnectParserLink(commandArgumentsChain);
    }
}