using System.Collections.Generic;
using AtifMalik.Dev.PSExt.Shared.Data;

namespace AtifMalik.Dev.PSExt.Shared.Contracts
{
    public interface IDevSetupCommand
    {
        int CommandOrder { get; set; }
        void Execute();
        List<DevSetupCommandResult> CommandResults { get; }
    }
}
