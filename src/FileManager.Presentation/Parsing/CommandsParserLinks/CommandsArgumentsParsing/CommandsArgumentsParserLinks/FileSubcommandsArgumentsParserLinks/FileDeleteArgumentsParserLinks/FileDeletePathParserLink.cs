using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileDeleteArgumentsParserLinks;

public class FileDeletePathParserLink : CommandArgumentParserLinkBase<FileDeleteCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, FileDeleteCommandBuilder commandBuilder)
    {
        if (!stream.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file delete path"));
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