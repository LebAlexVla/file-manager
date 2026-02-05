using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing;

public abstract record CommandParseResult
{
    private CommandParseResult() { }

    public sealed record Success(CommandBuildResult Command) : CommandParseResult;

    public sealed record Failure(IError Error) : CommandParseResult;
}