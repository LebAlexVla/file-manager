using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponents;
using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponentVisitors;
using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.TreeAssembler;
using FileManager.Core.Commands.CommandsAdditions.Writing;
using FileManager.Core.CommandsExecuting;
using FileManager.Core.CommandsExecuting.State;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands;

public class TreeListCommand : ICommand
{
    private readonly ITreeDrawAssembler _treeAssembler;

    private readonly IWriter _writer;

    private readonly int _depth;

    public TreeListCommand(ITreeDrawAssembler treeAssembler, IWriter writer, int depth)
    {
        _treeAssembler = treeAssembler;
        _writer = writer;
        _depth = depth;
    }

    public CommandResult Execute(Context context)
    {
        if (context.State is not ConnectedState connectedState)
        {
            return new CommandResult.Failure(new ExecutingError("Not connected"));
        }

        var treeVisitor = new FileSystemComponentVisitor(_depth, _treeAssembler);
        string? currentDirectoryName = connectedState.FileSystem.GetFileName(
            connectedState.CurrentDirectory);
        if (currentDirectoryName is null)
        {
            return new CommandResult.Failure(new ExecutingError("Directory not found"));
        }

        treeVisitor.Visit(
            new DirectoryFileSystemComponent(
                currentDirectoryName, connectedState.CurrentDirectory, connectedState.FileSystem));

        string text = _treeAssembler.GetResult();
        _writer.Write(text);

        return new CommandResult.Success();
    }
}