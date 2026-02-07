using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.FileSubCommandsParsing;

public class FileRenameParserLink : SubCommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<FileRenameCommandBuilder> _argumentsParserLink;

    public FileRenameParserLink(ICommandArgumentParserLink<FileRenameCommandBuilder> argumentsParserLink)
    {
        _argumentsParserLink = argumentsParserLink;
    }

    public override SubCommandParseResult Parse(StringsStream stream)
    {
        if (stream.Current == "rename")
        {
            var fileRenameCommandBuilder = new FileRenameCommandBuilder();
            CommandArgumentParseResult result = _argumentsParserLink.Parse(stream, fileRenameCommandBuilder);

            return result.ThenSubCommand();
        }

        return CallNext(stream);
    }
}