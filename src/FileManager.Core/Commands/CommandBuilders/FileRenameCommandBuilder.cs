namespace FileManager.Core.Commands.CommandBuilders;

public class FileRenameCommandBuilder : ICommandBuilder
{
    private string? _path;
    private string? _name;

    public FileRenameCommandBuilder WithPath(string path)
    {
        _path = path;

        return this;
    }

    public FileRenameCommandBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public ICommand Build()
    {
        if (_path is null || _name is null)
        {
            throw new ArgumentNullException();
        }

        return new FileRenameCommand(_path, _name);
    }
}