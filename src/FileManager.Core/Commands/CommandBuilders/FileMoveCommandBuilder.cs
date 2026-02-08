namespace FileManager.Core.Commands.CommandBuilders;

public class FileMoveCommandBuilder : ICommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public FileMoveCommandBuilder WithSourcePath(string path)
    {
        _sourcePath = path;

        return this;
    }

    public FileMoveCommandBuilder WithDestinationPath(string path)
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

        return new FileMoveCommand(_sourcePath, _destinationPath);
    }
}