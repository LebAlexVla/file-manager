namespace FileManager.Core.Commands.CommandBuilders;

public class FileCopyCommandBuilder : ICommandBuilder
{
    private string _sourcePath = string.Empty;
    private string _destinationPath = string.Empty;

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
        return new FileCopyCommand(_sourcePath, _destinationPath);
    }
}