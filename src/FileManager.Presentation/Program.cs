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
                CommandParseResult result = parser.Parse(stream);

                if (result is CommandParseResult.Success(var command))
                {
                    commander.Run(command);
                }

                if (result is CommandParseResult.Failure(var error))
                {
                    foreach (string rawString in rawStrings)
                    {
                        Console.WriteLine(rawString);
                    }

                    Console.WriteLine(error.Info);
                }
            }
        }
        while (!string.Equals(input, "q", StringComparison.Ordinal));
    }
}