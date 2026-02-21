using FileManager.Core.Commands.CommandsAdditions.ConnectModes;
using FileManager.Core.CommandsExecuting;
using FileManager.Core.CommandsExecuting.State;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly IConnectMode _connectMode;
    private readonly string _address;

    public ConnectCommand(IConnectMode connectMode, string address)
    {
        _connectMode = connectMode;
        _address = address;
    }

    public CommandResult Execute(Context context)
    {
        if (context.State is ConnectedState)
        {
            return new CommandResult.Failure(new ExecutingError("Already connected"));
        }

        if (!context.TryConnect(_connectMode.Create(_address), _address))
        {
            return new CommandResult.Failure(new ExecutingError("Connection failed"));
        }

        return new CommandResult.Success();
    }
}