using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing.FlagArgumentParseResults;

public static class FlagArgumentParseResultExtension
{
    private const string Context = "Error in flag argument parser link: ";

    private const string UnknownError = "Unknown error";

    public static CommandArgumentParseResult Then(this FlagArgumentParseResult result)
    {
        if (result is FlagArgumentParseResult.Success(var commandBuilder))
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        if (result is FlagArgumentParseResult.Failure(var error))
        {
            return new CommandArgumentParseResult.Failure(new ParsingError(Context + error.Info));
        }

        return new CommandArgumentParseResult.Failure(new ParsingError(UnknownError));
    }
}