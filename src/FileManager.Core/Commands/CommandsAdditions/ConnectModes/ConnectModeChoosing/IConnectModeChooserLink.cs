namespace FileManager.Core.Commands.CommandsAdditions.ConnectModes.ConnectModeChoosing;

public interface IConnectModeChooserLink : IConnectModeChooserService
{
    IConnectModeChooserLink AddNext(IConnectModeChooserLink chooserLink);
}