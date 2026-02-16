using FileManager.Core.CommandsExecuting;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;

    public FileRenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public CommandResult Execute(IContext context)
    {
        if (context.FileSystem is null || context.CurrentDirectory is null)
        {
            return new CommandResult.Failure(new ExecutingError("Problems with file system or current directory"));
        }

        context.FileSystem.RenameFile(_path, _name);

        return new CommandResult.Success();
    }
}