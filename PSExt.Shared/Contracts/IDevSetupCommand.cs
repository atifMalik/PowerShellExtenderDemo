using System.Collections.Generic;
using PSExt.Shared.Data;

namespace PSExt.Shared.Contracts
{
    public interface IDevSetupCommand
    {
        int CommandOrder { get; set; }
        void Execute();
        List<DevSetupCommandResult> CommandResults { get; }
    }
}
