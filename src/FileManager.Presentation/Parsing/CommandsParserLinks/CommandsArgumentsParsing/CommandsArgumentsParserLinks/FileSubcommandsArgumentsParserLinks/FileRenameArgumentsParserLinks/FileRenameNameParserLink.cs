using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileRenameArgumentsParserLinks;

public class FileRenameNameParserLink : CommandArgumentParserLinkBase<FileRenameCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, FileRenameCommandBuilder commandBuilder)
    {
        if (!stream.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file rename name"));
        }

        commandBuilder.WithName(stream.MoveNext());

        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        stream.MoveNext();

        return CallNext(stream, commandBuilder);
    }
}