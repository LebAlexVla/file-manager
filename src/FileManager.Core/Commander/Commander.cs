using FileManager.Core.Commands;
using FileManager.Core.FileSystems;

namespace FileManager.Core.Commander;

public class Commander
{
    private IFileSystem? FileSystem { get; set; }

    private string? CurrentDirectory { get; set; }

    public CommandResult Run(ICommand command)
    {
        return command.Execute(FileSystem, CurrentDirectory);
    }
}