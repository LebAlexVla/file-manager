using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponentVisitors;
using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.TreeAssembler;
using FileManager.Core.Commands.CommandsAdditions.Writing;
using FileManager.Core.CommandsExecuting;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands;

public class TreeListCommand : ICommand
{
    private readonly ITreeAssembler _treeAssembler;

    private readonly IWriter _writer;

    private readonly int _depth;

    public TreeListCommand(ITreeAssembler treeAssembler, IWriter writer, int depth)
    {
        _treeAssembler = treeAssembler;
        _writer = writer;
        _depth = depth;
    }

    public CommandResult Execute(IContext context)
    {
        if (context.FileSystem is null || context.CurrentDirectory is null)
        {
            return new CommandResult.Failure(new ExecutingError("Problems with file system or current directory"));
        }

        var treeVisitor = new FileSystemComponentVisitor(_depth, context.FileSystem, _treeAssembler);
        string text = _treeAssembler.GetResult();
        _writer.Write(text);

        return new CommandResult.Success();
    }
}