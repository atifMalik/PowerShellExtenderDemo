using System.Collections.Generic;
using AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands;
using AtifMalik.Dev.PSExt.Shared.Configuration;
using AtifMalik.Dev.PSExt.Shared.Contracts;

namespace AtifMalik.Dev.PSExt.UnderstoodSetup.Business
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
