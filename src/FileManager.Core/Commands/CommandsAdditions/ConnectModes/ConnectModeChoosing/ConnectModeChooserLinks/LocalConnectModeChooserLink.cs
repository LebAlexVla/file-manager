namespace FileManager.Core.Commands.CommandsAdditions.ConnectModes.ConnectModeChoosing.ConnectModeChooserLinks;

public class LocalConnectModeChooserLink : ConnectModeChooserLinkBase
{
    public override ConnectModeChoiceResult Choose(string? rawConnectMode)
    {
        if (rawConnectMode is null or "local")
        {
            return new ConnectModeChoiceResult.Success(new LocalConnectMode());
        }

        return CallNext(rawConnectMode);
    }
}