using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandsAdditions.ConnectModes.ConnectModeChoosing;

public abstract record ConnectModeChoiceResult
{
    private ConnectModeChoiceResult() { }

    public sealed record Success(IConnectMode Mode) : ConnectModeChoiceResult;

    public sealed record Failure(IError Error) : ConnectModeChoiceResult;
}