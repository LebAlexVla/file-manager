using FileManager.Core.Commands.CommandsAdditions.ConnectModes.ConnectModeChoosing;
using FileManager.Core.Commands.CommandsAdditions.ConnectModes.ConnectModeChoosing.ConnectModeChooserLinks;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandBuilders;

public class ConnectCommandBuilder : ICommandBuilder
{
    private readonly IConnectModeChooserLink _connectModeChooser;

    private string? _address;

    private string? _rawConnectMode;

    public ConnectCommandBuilder(IConnectModeChooserLink connectModeChooser)
    {
        _connectModeChooser = connectModeChooser;
    }

    public ConnectCommandBuilder()
    {
        _connectModeChooser = new LocalConnectModeChooserLink();
    }

    public ConnectCommandBuilder WithAddress(string address)
    {
        _address = address;

        return this;
    }

    public ConnectCommandBuilder WithMode(string rawConnectMode)
    {
        _rawConnectMode = rawConnectMode;

        return this;
    }

    public CommandBuildResult Build()
    {
        if (_address == null)
        {
            return new CommandBuildResult.Failure(new BuildingError("Connect address is null"));
        }

        ConnectModeChoiceResult modeChoiceResult = _connectModeChooser.Choose(_rawConnectMode);

        if (modeChoiceResult is ConnectModeChoiceResult.Failure(var error))
        {
            return new CommandBuildResult.Failure(new BuildingError(error.Info));
        }

        if (modeChoiceResult is ConnectModeChoiceResult.Success(var connectMode))
        {
            return new CommandBuildResult.Success(new ConnectCommand(connectMode, _address));
        }

        return new CommandBuildResult.Failure(new BuildingError("Unknown connect command building error"));
    }
}