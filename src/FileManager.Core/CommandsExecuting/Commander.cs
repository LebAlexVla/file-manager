using FileManager.Core.Commands;
using FileManager.Core.FileSystems;

namespace FileManager.Core.CommandsExecuting;

public class Commander : IContext
{
    public IFileSystem? FileSystem { get; set; }

    public string? CurrentDirectory { get; set; }

    public CommandResult Run(ICommand command)
    {
        return command.Execute(this);
    }
}