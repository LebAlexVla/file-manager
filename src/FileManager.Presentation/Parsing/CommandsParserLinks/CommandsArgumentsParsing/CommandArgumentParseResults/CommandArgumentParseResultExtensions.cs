using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

public static class CommandArgumentParseResultExtensions
{
    private const string Context = "Error in command argument parser link: ";

    private const string UnknownError = "Unknown error";

    public static CommandParseResult Then(this CommandArgumentParseResult result)
    {
        if (result is CommandArgumentParseResult.Success(var commandBuilder))
        {
            return new CommandParseResult.Success(commandBuilder.Build());
        }

        if (result is CommandArgumentParseResult.Failure(var error))
        {
            return new CommandParseResult.Failure(new ParsingError(Context + error.Info));
        }

        return new CommandParseResult.Failure(new ParsingError(UnknownError));
    }
}