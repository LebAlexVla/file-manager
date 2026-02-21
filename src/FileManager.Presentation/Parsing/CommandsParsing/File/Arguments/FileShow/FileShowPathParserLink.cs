using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileShow;

public class FileShowPathParserLink : CommandArgumentParserLinkBase<FileShowCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsIterator iterator, FileShowCommandBuilder commandBuilder)
    {
        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file show path"));
        }

        commandBuilder.WithPath(iterator.MoveNext());

        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        iterator.MoveNext();

        return CallNext(iterator, commandBuilder);
    }
}