using System.Collections.Generic;
using AtifMalik.Dev.PSExt.Shared.Contracts;
using AtifMalik.Dev.PSExt.Shared.Data;

namespace AtifMalik.Dev.PSExt.UnderstoodSetup.Business
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
