namespace FileManager.Core.Commands.CommandBuilders;

public class FileRenameCommandBuilder : ICommandBuilder
{
    private string _path = string.Empty;
    private string _name = string.Empty;

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
        return new FileRenameCommand(_path, _name);
    }
}