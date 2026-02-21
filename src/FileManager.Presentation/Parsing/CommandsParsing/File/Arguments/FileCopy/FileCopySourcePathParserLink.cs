using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileCopy;

public class FileCopySourcePathParserLink : CommandArgumentParserLinkBase<FileCopyCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsIterator iterator, FileCopyCommandBuilder commandBuilder)
    {
        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file copy source path"));
        }

        commandBuilder.WithSourcePath(iterator.MoveNext());

        return CallNext(iterator, commandBuilder);
    }
}