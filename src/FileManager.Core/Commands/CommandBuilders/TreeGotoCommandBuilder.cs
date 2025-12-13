namespace FileManager.Core.Commands.CommandBuilders;

public class TreeGotoCommandBuilder : ICommandBuilder
{
    private string? _path;

    public TreeGotoCommandBuilder WithPath(string path)
    {
        _path = path;

        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(_path))
        {
            throw new Exception("Path cannot be null or empty");
        }

        return new TreeGotoCommand(_path);
    }
}