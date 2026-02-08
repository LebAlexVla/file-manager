using FileManager.Core.Commands.CommandsAdditions.ConnectModes;

namespace FileManager.Core.Commands.CommandBuilders;

public class ConnectCommandBuilder : ICommandBuilder
{
    private string? _address;

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
        if (_address == null)
        {
            throw new ArgumentNullException($"address is null");
        }

        if (_connectMode == null)
        {
            _connectMode = new LocalConnectMode();
        }

        return new ConnectCommand(_connectMode, _address);
    }
}