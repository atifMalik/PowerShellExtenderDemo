using System.Collections.Generic;
using AtifMalik.Dev.PSExt.Shared.Data;

namespace AtifMalik.Dev.PSExt.Shared.Contracts
{
    public interface IDevSetupCommandExecutor
    {
        List<DevSetupCommandResult> ExecuteCommands(List<IDevSetupCommand> commands);
    }
}
