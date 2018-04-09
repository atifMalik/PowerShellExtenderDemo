using System.Collections.Generic;
using PSExt.PowershellExtender.UnderstoodCommands;
using PSExt.Shared.Configuration;
using PSExt.Shared.Contracts;

namespace PSExt.UnderstoodSetup.Business
{
    public class UnderstoodCommandFactory : IDevSetupCommandFactory
    {
        public List<IDevSetupCommand> CreateAllCommands()
        {
            var config = UnderstoodConfigManager.Instance;

            List<IDevSetupCommand> commands = new List<IDevSetupCommand>()
            {
                //new AddAppPool() { AppPoolName = config.NewAppPoolName },
                //new AddIISSite() { SiteName = config.IIS_SiteName, PhysicalPath = config.IISDirectoryPath, AppPoolName = config.NewAppPoolName },
                new InitializeGitGubRepo() { UserName = config.GitUsername, Password = config.GitPassword, GitHubRepoUrl = config.GitHubRepoUrl, PhysicalPath = config.GitRepoFolderHdd }
            };

            return commands;
        }
    }
}
