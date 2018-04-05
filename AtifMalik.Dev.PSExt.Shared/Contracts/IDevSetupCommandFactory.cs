using System.Collections.Generic;

namespace AtifMalik.Dev.PSExt.Shared.Contracts
{
    public interface IDevSetupCommandFactory
    {
        List<IDevSetupCommand> CreateAllCommands();
    }
}
