namespace PSExt.Shared.Contracts
{
    public interface IDevSetupConfig
    {
        string MetabaseIISRootPath { get; }
        string IISDirectoryPath { get; }
        string IIS_SiteName { get; }
        string NewAppPoolName { get; }

        string GitHubRepoUrl { get; }
        string GitUsername { get; set; }
        string GitPassword { get; set; }
        string GitRepoFolderHdd { get; set; }

    }
}
