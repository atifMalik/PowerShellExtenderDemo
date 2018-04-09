using System.Collections.Generic;

namespace PSExt.Shared.Contracts
{
    public interface IDevSetupCommandFactory
    {
        List<IDevSetupCommand> CreateAllCommands();
    }
}
