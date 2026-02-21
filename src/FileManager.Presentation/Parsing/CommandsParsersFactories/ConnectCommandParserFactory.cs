using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParsing.Connect;
using FileManager.Presentation.Parsing.CommandsParsing.Connect.Arguments;
using FileManager.Presentation.Parsing.CommandsParsing.Connect.ConnectMode.ModeParsers;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;
using FileManager.Presentation.Parsing.ParsingAbstractions.Commands;

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