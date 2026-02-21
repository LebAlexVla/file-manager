using FileManager.Core.Commands.CommandsAdditions.ConnectModes;

namespace FileManager.Core.Commands.CommandBuilders;

public class ConnectCommandBuilder : ICommandBuilder
{
    private string _address = string.Empty;

    private IConnectMode? _connectMode;

    public ConnectCommandBuilder WithAddress(string address)
    {
        _address = address;

        return this;
    }

    public ConnectCommandBuilder WithMode(IConnectMode connectMode)
    {
        _connectMode = connectMode;

        return this;
    }

    public ICommand Build()
    {
        _connectMode ??= new LocalConnectMode();

        return new ConnectCommand(_connectMode, _address);
    }
}