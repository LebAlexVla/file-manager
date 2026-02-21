namespace FileManager.Core.Commands.CommandBuilders;

public class FileMoveCommandBuilder : ICommandBuilder
{
    private string _sourcePath = string.Empty;
    private string _destinationPath = string.Empty;

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
        return new FileMoveCommand(_sourcePath, _destinationPath);
    }
}