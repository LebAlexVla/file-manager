using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileMoveArgumentsParserLinks;

public class FileMoveDestinationPathParserLink : CommandArgumentParserLinkBase<FileMoveCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, FileMoveCommandBuilder commandBuilder)
    {
        if (!stream.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file move destination path"));
        }

        commandBuilder.WithDestinationPath(stream.MoveNext());

        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        stream.MoveNext();

        return CallNext(stream, commandBuilder);
    }
}