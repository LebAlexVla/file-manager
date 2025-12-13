using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing;

public static class ArgumentParseResultExtensions
{
    private const string Context = "Error in argument parser link: ";

    private const string UnknownError = "Unknown error";

    public static CommandParseResult Then(this ArgumentParseResult result)
    {
        if (result is ArgumentParseResult.Success(var commandBuilder))
        {
            return new CommandParseResult.Success(commandBuilder.Build());
        }

        if (result is ArgumentParseResult.Failure(var error))
        {
            return new CommandParseResult.Failure(new ParsingError(Context + error.Info));
        }

        return new CommandParseResult.Failure(new ParsingError(UnknownError));
    }
}