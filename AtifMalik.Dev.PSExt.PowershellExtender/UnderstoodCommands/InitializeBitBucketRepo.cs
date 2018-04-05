using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Net;
using System.Text;
using AtifMalik.Dev.PSExt.Shared.Data;

namespace AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands
{
    [Cmdlet(VerbsData.Initialize, "BitBucketRepo")]
    public class InitializeBitBucketRepo : DevSetupCommandBase
    {
        public InitializeBitBucketRepo()
        {
            CommandResults = new List<DevSetupCommandResult>();
        }

        protected override sealed DevSetupCommandResult ExecuteCommand()
        {
            if (!ValidateParameters())
                return null;

            // Create the Directory on file system, if it does not exist
            //var directoryInfo = Directory.CreateDirectory(PhysicalPath);

            //var basicAuthentication = new BasicAuthentication(UserName, Password, BitBucketRepoUrl);
            //var sharpBucket = new SharpBucketV1();
            //sharpBucket.BasicAuthentication(UserName, Password);

            //var endPoint = sharpBucket.RepositoriesEndPoint();
            //var res = endPoint.BranchResource("agency-oasis", "understood.org");

            //var branch = res.ListBranches().Where(c => c.name == "develop").FirstOrDefault();

            //// getting the User end point
            //var userEndPoint = sharpBucket.UserEndPoint();

            // querying the Bitbucket API for various info
            //var info = userEndPoint.
            //var privileges = userEndPoint.ListPrivileges();
            //var follows = userEndPoint.ListFollows();
            //var userRepos = userEndPoint.ListRepositories();

            //sharpBucket


            var creds = Base64Encode(String.Format("{0}:{1}", UserName, Password));

            var url = String.Concat(BitBucketRepoUrl, @"/get/tip.zip");

            string zipFilePath = Path.Combine(Path.GetTempPath(), "test.zip");

            using (var client = new WebClient())
            {
                client.Headers.Add("Authorization", "Basic " + creds);
                client.Headers.Add("Content-Type", "application/octet-stream");
                client.DownloadFile(url, zipFilePath);
            }

            DevSetupCommandResult result = new DevSetupCommandResult() { CommandName = GetType().Name, CommandResult = true };
            result.Message = "New IIS Site was created Successfully";

            return result;
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string PhysicalPath { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string BitBucketRepoUrl { get; set; }
    }
}
