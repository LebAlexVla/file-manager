using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileRenameArgumentsParserLinks;

public class FileRenamePathParserLink : CommandArgumentParserLinkBase<FileRenameCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, FileRenameCommandBuilder commandBuilder)
    {
        if (!stream.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file rename path"));
        }

        commandBuilder.WithPath(stream.MoveNext());

        return CallNext(stream, commandBuilder);
    }
}