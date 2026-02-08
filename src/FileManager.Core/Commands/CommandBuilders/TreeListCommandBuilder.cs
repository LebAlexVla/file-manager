using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.TreeAssembler;
using FileManager.Core.Commands.CommandsAdditions.Writing;

namespace FileManager.Core.Commands.CommandBuilders;

public class TreeListCommandBuilder : ICommandBuilder
{
    private ITreeAssembler? _treeAssembler;
    private IWriter? _writer;
    private int? _depth;

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

    public TreeListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;

        return this;
    }

    public ICommand Build()
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

        if (_depth == null)
        {
            _depth = 1;
        }

        return new TreeListCommand(_treeAssembler, _writer, _depth.Value);
    }
}