using FileManager.Presentation.Parsing.ParsingAbstractions.Commands;
using FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

namespace FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

public static class CommandArgumentParseResultExtensions
{
    private const string Context = "Error in command argument parser link: ";

    private const string UnknownError = "Unknown error";

    public static CommandParseResult ThenCommand(this CommandArgumentParseResult result)
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

    public static SubCommandParseResult ThenSubCommand(this CommandArgumentParseResult result)
    {
        if (result is CommandArgumentParseResult.Success(var commandBuilder))
        {
            return new SubCommandParseResult.Success(commandBuilder);
        }

        if (result is CommandArgumentParseResult.Failure(var error))
        {
            return new SubCommandParseResult.Failure(new ParsingError(Context + error.Info));
        }

        return new SubCommandParseResult.Failure(new ParsingError(UnknownError));
    }
}