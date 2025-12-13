using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

public static class SubCommandParseResultExtension
{
    private const string Context = "Error in subcommand parser link: ";

    private const string UnknownError = "Unknown error";

    public static CommandParseResult Then(this SubCommandParseResult result)
    {
        if (result is SubCommandParseResult.Success(var commandBuilder))
        {
            return new CommandParseResult.Success(commandBuilder.Build());
        }

        if (result is SubCommandParseResult.Failure(var error))
        {
            return new CommandParseResult.Failure(new ParsingError(Context + error.Info));
        }

        return new CommandParseResult.Failure(new ParsingError(UnknownError));
    }
}