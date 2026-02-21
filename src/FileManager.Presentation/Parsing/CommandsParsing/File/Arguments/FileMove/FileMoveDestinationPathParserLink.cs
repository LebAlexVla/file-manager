using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileMove;

public class FileMoveDestinationPathParserLink : CommandArgumentParserLinkBase<FileMoveCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsIterator iterator, FileMoveCommandBuilder commandBuilder)
    {
        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file move destination path"));
        }

        commandBuilder.WithDestinationPath(iterator.MoveNext());

        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        iterator.MoveNext();

        return CallNext(iterator, commandBuilder);
    }
}