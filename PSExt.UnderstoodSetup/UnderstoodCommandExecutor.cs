using System.Collections.Generic;
using PSExt.Shared.Contracts;
using PSExt.Shared.Data;

namespace PSExt.UnderstoodSetup
{
    public class UnderstoodCommandExecutor : IDevSetupCommandExecutor
    {
        public List<DevSetupCommandResult> ExecuteCommands(List<IDevSetupCommand> commands)
        {
            List<DevSetupCommandResult> results = new List<DevSetupCommandResult>();

            foreach (var cmd in commands)
            {
                cmd.Execute();
                results.AddRange(cmd.CommandResults);
            }

            return results;
        }
    }
}
