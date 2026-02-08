using FileManager.Core.Commands;
using FileManager.Presentation.Parsing;
using Xunit;

namespace FileManager.Tests;

public class CommandsParserTests
{
    [Fact]
    public void ParseConnectWithAddressSuccess()
    {
        CommandParseResult result = Parse(["connect", @"C:\Users\REDMI\Documents\ITMO\OOP"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<ConnectCommand>(success.Command);
    }

    [Fact]
    public void ParseConnectWithoutAddressFailure()
    {
        CommandParseResult result = Parse(["connect"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseConnectWithModeSuccess()
    {
        CommandParseResult result = Parse(["connect", @"C:\Users\REDMI\Documents\ITMO\OOP", "-m", "local"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<ConnectCommand>(success.Command);
    }

    [Fact]
    public void ParseConnectWithWasteFailure()
    {
        CommandParseResult result = Parse(["connect", @"C:\Users\REDMI\Documents\ITMO\OOP", "-m", "local", "zzz"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    private CommandParseResult Parse(string[] args)
    {
        var parserFactory = new ParserFactory();
        ICommandParserLink parser = parserFactory.Create();
        var stream = new StringsStream(args);

        return parser.Parse(stream);
    }
}