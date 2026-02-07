using FileManager.Core.Commands.CommandsAdditions.ConnectModes;
using FileManager.Core.Errors;

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

    public CommandBuildResult Build()
    {
        if (_address == null)
        {
            return new CommandBuildResult.Failure(new BuildingError("Connect address is null"));
        }

        if (_connectMode == null)
        {
            return new CommandBuildResult.Failure(new BuildingError("Connect mode is null"));
        }

        return new CommandBuildResult.Success(new ConnectCommand(_connectMode, _address));
    }
}