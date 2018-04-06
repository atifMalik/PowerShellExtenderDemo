using AtifMalik.Dev.PSExt.Shared.Contracts;

namespace AtifMalik.Dev.PSExt.Shared.Configuration
{
    /// <summary>
    /// Encapsulates Config/Parameters Access Logic.
    /// Implemented as Singleton pattern, to ensure property access consistency over an application lifecycle.
    /// More info on the Singleton pattern used can be found here: http://csharpindepth.com/Articles/General/Singleton.aspx
    /// </summary>
    public sealed class UnderstoodConfigManager : IDevSetupConfig
    {
        private static UnderstoodConfigManager _instance = null;
        private static readonly object _padlock = new object();

        private UnderstoodConfigManager()
        {
        }

        public static UnderstoodConfigManager Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new UnderstoodConfigManager();
                        _instance.RubyDownloadUrl = @"https://dl.bintray.com/oneclick/rubyinstaller/rubyinstaller-2.1.9-x64.exe";
                        _instance.RubyInstallerFilename = @"rubyinstaller-2.1.9-x64.exe";
                        _instance.MetabaseIISRootPath = @"IIS://Localhost/W3SVC";
                        _instance.IIS_SiteName = "understood.org.local";
                        _instance.NewAppPoolName = "UnderstoodOrgLocalAppPool";
                        _instance.IISDirectoryPath = @"C:\inetpub\wwwroot\Poses\Understood.org\local\Website";
                    }

                    return _instance;
                }
            }
        }

        public string IISDirectoryPath { get; private set; }
        public string IIS_SiteName { get; private set; }
        public string MetabaseIISRootPath { get; private set; }
        public string RubyDownloadUrl { get; private set; }
        public string RubyInstallerFilename { get; private set; }
        
        public string NewAppPoolName { get; private set; }

        public string GitHubRepoUrl { get; set; }
        public string GitUsername { get; set; }
        public string GitPassword { get; set; }
        public string GitRepoFolderHdd { get; set; }
    }
}
