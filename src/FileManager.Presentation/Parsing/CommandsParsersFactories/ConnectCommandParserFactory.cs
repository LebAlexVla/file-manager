using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing.ArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing.ArgumentsParserLinks.ConnectModeFlagParser;
using FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing.ArgumentsParserLinks.SyntaxCheckers;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public class ConnectCommandParserFactory : ICommandParserFactory
{
    public ICommandParserLink Create()
    {
        IArgumentParserLink<ConnectCommandBuilder> flagParametersChain =
            new ConnectModeLocalParserLink();

        IArgumentParserLink<ConnectCommandBuilder> argumentsChain =
            new ConnectAddressParserLink(new AbsolutePathSyntaxChecker())
                .AddNext(new ConnectModeFlagParserLink(flagParametersChain));

        return new ConnectParserLink(argumentsChain);
    }
}