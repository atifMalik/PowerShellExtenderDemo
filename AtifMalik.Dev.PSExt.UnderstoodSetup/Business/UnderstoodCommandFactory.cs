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
                // new AddAppPool() { AppPoolName = config.NewAppPoolName }
                // new AddIISSite() { SiteName = config.IIS_SiteName, PhysicalPath = config.IISDirectoryPath, AppPoolName = config.NewAppPoolName }

                // following needs to be tested on fresh IIS Install
                // new AddUrlRewriteModule()
                // new InstallRuby() { DownloadFilename = config.RubyInstallerFilename, DownloadUrl = config.RubyDownloadURL  }
                // new InstallFrontEndLibraries()
                //new InitializeBitBucketRepo() {
                //            BitBucketRepoUrl = config.BitBucketRepoPath,
                //            UserName = "amalik@rightpoint.com",
                //            Password = "",
                //            PhysicalPath = @"c:\Temp\"
                //}
            };

            return commands;
        }
    }

    public class UnderstoodCommandFactory_Demo : IDevSetupCommandFactory
    {
        public List<IDevSetupCommand> CreateAllCommands()
        {
            var config = UnderstoodConfigManager.Instance;

            return new List<IDevSetupCommand>()
            {
                new AddAppPool() { AppPoolName = config.NewAppPoolName },
                // new AddAppPool(),
                // new AddIISSite()
                new AddIISSite() { SiteName = config.IIS_SiteName + "_test", PhysicalPath = config.IISDirectoryPath, AppPoolName = config.NewAppPoolName }
                // new AddIISSite()
                //new InitializeBitBucketRepo()
                // new InstallRuby()
                // new InstallRuby() { DownloadFilename = config.RubyInstallerFilename, DownloadUrl = config.RubyDownloadURL }
            };
        }
    }
}
