using FileManager.Core.Commands;
using FileManager.Presentation.Parsing;
using FileManager.Presentation.Parsing.ParsingAbstractions.Commands;
using Xunit;

namespace FileManager.Tests;

public class CommandsParserTests
{
    [Fact]
    public void ParseConnectWithAddressSuccess()
    {
        CommandParseResult result = Parse(["connect", @"C:\Users\User\Documents\University\OOP"]);

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
        CommandParseResult result = Parse(["connect", @"C:\Users\User\Documents\University\OOP", "-m", "local"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<ConnectCommand>(success.Command);
    }

    [Fact]
    public void ParseConnectWithWasteFailure()
    {
        CommandParseResult result = Parse(["connect", @"C:\Users\User\Documents\University\OOP", "-m", "local", "zzz"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseDisconnectSuccess()
    {
        CommandParseResult result = Parse(["disconnect"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<DisconnectCommand>(success.Command);
    }

    [Fact]
    public void ParseDisconnectWithWasteFailure()
    {
        CommandParseResult result = Parse(["disconnect", "zzz"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseTreeGotoWithPathSuccess()
    {
        CommandParseResult result = Parse(["tree", "goto", @"C:\Users\User\Documents\University\OOP"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<TreeGotoCommand>(success.Command);
    }

    [Fact]
    public void ParseTreeGotoWithoutPathFailure()
    {
        CommandParseResult result = Parse(["tree", "goto"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseTreeGotoWithWasteFailure()
    {
        CommandParseResult result = Parse(["tree", "goto", @"C:\Users\User\Documents\University\OOP", "zzz"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseTreeListSuccess()
    {
        CommandParseResult result = Parse(["tree", "list"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<TreeListCommand>(success.Command);
    }

    [Fact]
    public void ParseTreeListWithDepthSuccess()
    {
        CommandParseResult result = Parse(["tree", "list", "-d", "3"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<TreeListCommand>(success.Command);
    }

    [Fact]
    public void ParseTreeListWithoutDepthValueFailure()
    {
        CommandParseResult result = Parse(["tree", "list", "-d"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseTreeListWithWasteFailure()
    {
        CommandParseResult result = Parse(["tree", "list", "-d", "3", "zzz"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseFileShowSuccess()
    {
        CommandParseResult result = Parse([
            "file",
            "show",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<FileShowCommand>(success.Command);
    }

    [Fact]
    public void ParseFileShowWithoutPathFailure()
    {
        CommandParseResult result = Parse(["file", "show"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseFileShowWithModeSuccess()
    {
        CommandParseResult result = Parse([
            "file",
            "show",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf",
            "-m",
            "console"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<FileShowCommand>(success.Command);
    }

    [Fact]
    public void ParseTreeListWithoutModeValueFailure()
    {
        CommandParseResult result = Parse([
            "file",
            "show",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf",
            "-m"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseFileShowWithWasteFailure()
    {
        CommandParseResult result = Parse([
            "file",
            "show",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf",
            "-m",
            "console",
            "zzz"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseFileMoveSuccess()
    {
        CommandParseResult result = Parse([
            "file",
            "move",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf",
            @"C:\Users\User\Documents\University\OOP"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<FileMoveCommand>(success.Command);
    }

    [Fact]
    public void ParseFileMoveWithoutPathsFailure()
    {
        CommandParseResult result = Parse(["file", "move"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseFileMoveWithWasteFailure()
    {
        CommandParseResult result = Parse([
            "file",
            "move",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf",
            @"C:\Users\User\Documents\University\OOP",
            "zzz"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseFileCopySuccess()
    {
        CommandParseResult result = Parse([
            "file",
            "copy",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf",
            @"C:\Users\User\Documents\University\OOP"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<FileCopyCommand>(success.Command);
    }

    [Fact]
    public void ParseFileCopyWithoutPathsFailure()
    {
        CommandParseResult result = Parse(["file", "copy"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseFileCopyWithWasteFailure()
    {
        CommandParseResult result = Parse([
            "file",
            "copy",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf",
            @"C:\Users\User\Documents\University\OOP",
            "zzz"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseFileDeleteSuccess()
    {
        CommandParseResult result = Parse([
            "file",
            "delete",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<FileDeleteCommand>(success.Command);
    }

    [Fact]
    public void ParseFileDeleteWithoutPathFailure()
    {
        CommandParseResult result = Parse(["file", "delete"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseFileDeleteWithWasteFailure()
    {
        CommandParseResult result = Parse([
            "file",
            "delete",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf",
            "zzz"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseFileRenameSuccess()
    {
        CommandParseResult result = Parse([
            "file",
            "rename",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf",
            "Behavioural-patterns.pdf"]);

        CommandParseResult.Success success = Assert.IsType<CommandParseResult.Success>(result);
        Assert.IsType<FileRenameCommand>(success.Command);
    }

    [Fact]
    public void ParseFileRenameWithoutNameFailure()
    {
        CommandParseResult result = Parse([
            "file",
            "rename",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    [Fact]
    public void ParseFileRenameWithWasteFailure()
    {
        CommandParseResult result = Parse([
            "file",
            "rename",
            @"C:\Users\User\Documents\University\OOP\lectures\behavioural-patterns.pdf",
            "Behavioural-patterns.pdf",
            "zzz"]);

        Assert.IsType<CommandParseResult.Failure>(result);
    }

    private CommandParseResult Parse(string[] args)
    {
        var parserFactory = new ParserFactory();
        ICommandParserLink parser = parserFactory.Create();
        var stream = new StringsIterator(args);

        return parser.Parse(stream);
    }
}