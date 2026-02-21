using FileManager.Core.Commands.CommandsAdditions.Writing;

namespace FileManager.Core.Commands.CommandBuilders;

public class FileShowCommandBuilder : ICommandBuilder
{
    private IWriter? _writer;
    private string _path = string.Empty;

    public FileShowCommandBuilder WithPath(string path)
    {
        _path = path;

        return this;
    }

    public FileShowCommandBuilder WithFileWriter(IWriter writer)
    {
        _writer = writer;

        return this;
    }

    public ICommand Build()
    {
        _writer ??= new ConsoleWriter();

        return new FileShowCommand(_writer, _path);
    }
}