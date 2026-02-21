using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;
using FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.SubCommands;

public class FileRenameParserLink : SubCommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<FileRenameCommandBuilder> _argumentsParserLink;

    public FileRenameParserLink(ICommandArgumentParserLink<FileRenameCommandBuilder> argumentsParserLink)
    {
        _argumentsParserLink = argumentsParserLink;
    }

    public override SubCommandParseResult Parse(StringsIterator iterator)
    {
        if (iterator.Current == "rename")
        {
            var fileRenameCommandBuilder = new FileRenameCommandBuilder();
            CommandArgumentParseResult result = _argumentsParserLink.Parse(iterator, fileRenameCommandBuilder);

            return result.ThenSubCommand();
        }

        return CallNext(iterator);
    }
}