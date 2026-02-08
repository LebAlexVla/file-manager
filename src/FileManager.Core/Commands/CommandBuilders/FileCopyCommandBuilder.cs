namespace FileManager.Core.Commands.CommandBuilders;

public class FileCopyCommandBuilder : ICommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public FileCopyCommandBuilder WithSourcePath(string path)
    {
        _sourcePath = path;

        return this;
    }

    public FileCopyCommandBuilder WithDestinationPath(string path)
    {
        _destinationPath = path;

        return this;
    }

    public ICommand Build()
    {
        if (_sourcePath is null || _destinationPath is null)
        {
            throw new ArgumentNullException();
        }

        return new FileCopyCommand(_sourcePath, _destinationPath);
    }
}