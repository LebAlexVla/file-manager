using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileMove;

public class FileMoveSourcePathParserLink : CommandArgumentParserLinkBase<FileMoveCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsIterator iterator, FileMoveCommandBuilder commandBuilder)
    {
        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file move source path"));
        }

        commandBuilder.WithSourcePath(iterator.MoveNext());

        return CallNext(iterator, commandBuilder);
    }
}