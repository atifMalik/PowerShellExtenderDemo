using System.Collections.Generic;
using PSExt.Shared.Data;

namespace PSExt.Shared.Contracts
{
    public interface IDevSetupCommandExecutor
    {
        List<DevSetupCommandResult> ExecuteCommands(List<IDevSetupCommand> commands);
    }
}
