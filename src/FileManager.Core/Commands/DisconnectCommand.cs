using FileManager.Core.CommandsExecuting;
using FileManager.Core.CommandsExecuting.State;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands;

public class DisconnectCommand : ICommand
{
    public CommandResult Execute(Context context)
    {
        if (context.State is DisconnectedState)
        {
            return new CommandResult.Failure(new ExecutingError("Already disconnected"));
        }

        if (!context.TryDisconnect())
        {
            return new CommandResult.Failure(new ExecutingError("Disconnection failed"));
        }

        return new CommandResult.Success();
    }
}