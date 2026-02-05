using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandsAdditions.ConnectModes.ConnectModeChoosing.ConnectModeChooserLinks;

public abstract class ConnectModeChooserLinkBase : IConnectModeChooserLink
{
    private IConnectModeChooserLink? _next;

    public abstract ConnectModeChoiceResult Choose(string? rawConnectMode);

    public IConnectModeChooserLink AddNext(IConnectModeChooserLink chooserLink)
    {
        if (_next == null)
        {
            _next = chooserLink;
        }
        else
        {
            _next = _next.AddNext(chooserLink);
        }

        return this;
    }

    protected ConnectModeChoiceResult CallNext(string rawMode)
    {
        return _next?.Choose(rawMode)
               ?? new ConnectModeChoiceResult.Failure(
                   new ParsingError("No connect mode parser link found"));
    }
}