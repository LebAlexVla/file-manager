using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileShowArgumentsParserLinks;

public class FileShowPathParserLink : CommandArgumentParserLinkBase<FileShowCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, FileShowCommandBuilder commandBuilder)
    {
        if (!stream.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file show path"));
        }

        commandBuilder.WithPath(stream.MoveNext());

        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        stream.MoveNext();

        return CallNext(stream, commandBuilder);
    }
}