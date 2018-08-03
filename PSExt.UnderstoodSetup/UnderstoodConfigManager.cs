using PSExt.Shared.Contracts;

namespace PSExt.UnderstoodSetup
{
    /// <summary>
    /// Encapsulates Config/Parameters Access Logic.
    /// </summary>
    public static class UnderstoodConfigManager
    {
        // Properties with 'private' setters
        public static string IISDirectoryPath { get; } = @"C:\inetpub\wwwroot\Poses\Understood.org\local\Website";
        public static string IIS_SiteName { get; } = "understood.org.local";
        public static string MetabaseIISRootPath { get; } = @"IIS://Localhost/W3SVC";
        public static string RubyDownloadUrl { get; } = @"https://dl.bintray.com/oneclick/rubyinstaller/rubyinstaller-2.1.9-x64.exe";
        public static string RubyInstallerFilename { get; } = @"rubyinstaller-2.1.9-x64.exe";
        public static string NewAppPoolName { get; } = "UnderstoodOrgLocalAppPool";

        // Properties with 'public' setters
        public static string GitHubRepoUrl { get; set; }
        public static string GitUsername { get; set; }
        public static string GitPassword { get; set; }
        public static string GitRepoFolderHdd { get; set; }
    }
}
