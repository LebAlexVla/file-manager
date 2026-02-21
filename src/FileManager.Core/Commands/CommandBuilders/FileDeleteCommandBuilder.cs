namespace FileManager.Core.Commands.CommandBuilders;

public class FileDeleteCommandBuilder : ICommandBuilder
{
    private string _path = string.Empty;

    public FileDeleteCommandBuilder WithPath(string path)
    {
        _path = path;

        return this;
    }

    public ICommand Build()
    {
        return new FileDeleteCommand(_path);
    }
}