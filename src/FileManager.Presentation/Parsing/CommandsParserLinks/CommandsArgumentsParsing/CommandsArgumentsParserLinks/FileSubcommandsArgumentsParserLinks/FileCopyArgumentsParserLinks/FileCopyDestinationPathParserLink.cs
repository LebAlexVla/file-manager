using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileCopyArgumentsParserLinks;

public class FileCopyDestinationPathParserLink : CommandArgumentParserLinkBase<FileCopyCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, FileCopyCommandBuilder commandBuilder)
    {
        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file copy destination path"));
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