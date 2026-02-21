using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileCopy;

public class FileCopyDestinationPathParserLink : CommandArgumentParserLinkBase<FileCopyCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsIterator iterator, FileCopyCommandBuilder commandBuilder)
    {
        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file copy destination path"));
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