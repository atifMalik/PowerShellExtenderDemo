using System.Collections.Generic;
using PSExt.PowershellExtender.UnderstoodCommands;
using PSExt.Shared.Contracts;

namespace PSExt.UnderstoodSetup
{
    public class UnderstoodCommandFactory : IDevSetupCommandFactory
    {
        public List<IDevSetupCommand> CreateAllCommands()
        {
            List<IDevSetupCommand> commands = new List<IDevSetupCommand>()
            {
                //new AddUrlRewriteModule()
                new AddAppPool() { AppPoolName = UnderstoodConfigManager.NewAppPoolName },
                new AddIISSite() { SiteName = UnderstoodConfigManager.IIS_SiteName + "_2", PhysicalPath = UnderstoodConfigManager.IISDirectoryPath, AppPoolName = UnderstoodConfigManager.NewAppPoolName },
                //new InitializeGitGubRepo() { UserName = config.GitUsername, Password = config.GitPassword, GitHubRepoUrl = config.GitHubRepoUrl, PhysicalPath = config.GitRepoFolderHdd }
            };

            return commands;
        }
    }
}
