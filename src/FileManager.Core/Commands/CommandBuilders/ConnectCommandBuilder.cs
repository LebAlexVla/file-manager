using FileManager.Core.Commands.ConnectModes;

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
            throw new Exception("Address is null");
        }

        if (_connectMode == null)
        {
            throw new Exception("Connect Mode is null");
        }

        return new ConnectCommand(_address, _connectMode);
    }
}