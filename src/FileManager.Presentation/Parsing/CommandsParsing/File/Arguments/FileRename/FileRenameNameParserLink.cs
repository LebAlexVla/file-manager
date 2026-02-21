using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileRename;

public class FileRenameNameParserLink : CommandArgumentParserLinkBase<FileRenameCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsIterator iterator, FileRenameCommandBuilder commandBuilder)
    {
        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file rename name"));
        }

        commandBuilder.WithName(iterator.MoveNext());

        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        iterator.MoveNext();

        return CallNext(iterator, commandBuilder);
    }
}