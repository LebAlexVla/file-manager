namespace FileManager.Core.Commands.CommandBuilders;

public class TreeGotoCommandBuilder : ICommandBuilder
{
    private string _path = string.Empty;

    public TreeGotoCommandBuilder WithPath(string path)
    {
        _path = path;

        return this;
    }

    public ICommand Build()
    {
        return new TreeGotoCommand(_path);
    }
}