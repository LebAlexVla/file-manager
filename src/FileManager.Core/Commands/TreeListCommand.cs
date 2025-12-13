using FileManager.Core.Commands.CommandsAdditions.TreeDrawing;
using FileManager.Core.Errors;
using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands;

public class TreeListCommand : ICommand
{
    private readonly IDrawer _drawer;

    private readonly int _depth;

    public TreeListCommand(IDrawer drawer, int depth)
    {
        _drawer = drawer;
        _depth = depth;
    }

    public CommandResult Execute(IFileSystem? fileSystem, string? currentDirectory)
    {
        if (fileSystem is null || currentDirectory is null)
        {
            return new CommandResult.Failure(new ExecutingError("Problems with file system or current directory"));
        }

        for (int i = 0; i < _depth; i++)
        {
            _drawer.DrawIndent();
        }

        return new CommandResult.Failure(new ExecutingError("Not implemented yet"));
    }
}