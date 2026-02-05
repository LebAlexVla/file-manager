namespace FileManager.Core.Commands.CommandsAdditions.ConnectModes.ConnectModeChoosing;

public interface IConnectModeChooserService
{
    ConnectModeChoiceResult Choose(string? rawConnectMode);
}