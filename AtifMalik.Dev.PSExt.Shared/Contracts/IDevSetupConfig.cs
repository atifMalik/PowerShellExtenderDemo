namespace AtifMalik.Dev.PSExt.Shared.Contracts
{
    public interface IDevSetupConfig
    {
        string MetabaseIISRootPath { get; }
        string IISDirectoryPath { get; }
        string IIS_SiteName { get; }
        string BitBucketRepoPath { get; }
        string NewAppPoolName { get; }
        string GitUsername { get; set; }
        string GitPassword { get; set; }
        string GitRepoFolderHdd { get; set; }

    }
}
