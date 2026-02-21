using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileRename;

public class FileRenamePathParserLink : CommandArgumentParserLinkBase<FileRenameCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsIterator iterator, FileRenameCommandBuilder commandBuilder)
    {
        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file rename path"));
        }

        commandBuilder.WithPath(iterator.MoveNext());

        return CallNext(iterator, commandBuilder);
    }
}