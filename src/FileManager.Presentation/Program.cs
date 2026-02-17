using FileManager.Core.Commands;
using FileManager.Core.CommandsExecuting;
using FileManager.Presentation.Parsing;

namespace FileManager.Presentation;

internal class Program
{
    private static void Main()
    {
        var commander = new Commander();
        var parserFactory = new ParserFactory();
        ICommandParserLink parser = parserFactory.Create();

        string? input = " ";
        do
        {
            input = Console.ReadLine();
            if (input != null)
            {
                string[] rawStrings = input.Split(' ');
                var stream = new StringsStream(rawStrings);
                CommandParseResult parseResult = parser.Parse(stream);

                if (parseResult is CommandParseResult.Success(var command))
                {
                    CommandResult runResult = commander.Run(command);
                    if (runResult is CommandResult.Failure(var failure))
                    {
                        Console.WriteLine(failure.Info);
                    }
                }

                if (parseResult is CommandParseResult.Failure(var error))
                {
                    Console.WriteLine(error.Info);
                }
            }
        }
        while (!string.Equals(input, "q", StringComparison.Ordinal));
    }
}