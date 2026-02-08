namespace FileManager.Core.Commands.CommandBuilders;

public class FileDeleteCommandBuilder : ICommandBuilder
{
    private string? _path;

    public FileDeleteCommandBuilder WithPath(string path)
    {
        _path = path;

        return this;
    }

    public ICommand Build()
    {
        if (_path is null)
        {
            throw new ArgumentNullException();
        }

        return new FileDeleteCommand(_path);
    }
}