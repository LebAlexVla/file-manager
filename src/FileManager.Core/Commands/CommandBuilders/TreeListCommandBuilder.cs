using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.TreeAssembler;
using FileManager.Core.Commands.CommandsAdditions.Writing;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandBuilders;

public class TreeListCommandBuilder : ICommandBuilder
{
    private ITreeAssembler? _treeAssembler;
    private IWriter? _writer;
    private string? _rawDepth;

    public TreeListCommandBuilder WithTreeAssembler(ITreeAssembler treeAssembler)
    {
        _treeAssembler = treeAssembler;

        return this;
    }

    public TreeListCommandBuilder WithWriter(IWriter writer)
    {
        _writer = writer;

        return this;
    }

    public TreeListCommandBuilder WithDepth(string rawDepth)
    {
        _rawDepth = rawDepth;

        return this;
    }

    public CommandBuildResult Build()
    {
        if (_treeAssembler == null)
        {
            var bankFactory = new StandardDrawingSymbolsBankFactory();
            _treeAssembler = new StandardTreeAssembler(bankFactory.Create());
        }

        if (_writer == null)
        {
            _writer = new ConsoleWriter();
        }

        if (_rawDepth == null)
        {
            return new CommandBuildResult.Failure(
                new BuildingError("You must call WithDepth first"));
        }

        if (!int.TryParse(_rawDepth, out int depth))
        {
            return new CommandBuildResult.Failure(new BuildingError("Wrong depth"));
        }

        return new CommandBuildResult.Success(new TreeListCommand(_treeAssembler, _writer, depth));
    }
}