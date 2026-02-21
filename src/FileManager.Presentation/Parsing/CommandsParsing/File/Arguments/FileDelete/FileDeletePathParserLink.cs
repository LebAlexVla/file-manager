using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileDelete;

public class FileDeletePathParserLink : CommandArgumentParserLinkBase<FileDeleteCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsIterator iterator, FileDeleteCommandBuilder commandBuilder)
    {
        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file delete path"));
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