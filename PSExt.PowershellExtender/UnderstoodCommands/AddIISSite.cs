using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using Microsoft.Web.Administration;
using PSExt.Shared.Data;

namespace PSExt.PowershellExtender.UnderstoodCommands
{
    /// <summary>
    /// Adds an IIS Site to IIS, with the given Site Name, Physical Path, and App Pool name.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "IISSite")]
    public class AddIISSite : DevSetupCommandBase
    {
        protected override sealed DevSetupCommandResult ExecuteCommand()
        {
            if (!ValidateParameters())
                return null;

            using (ServerManager serverManager = new ServerManager())
            {
                // If the physical directory does not exist, create it.
                Directory.CreateDirectory(PhysicalPath);

                // Create a new IIS Site
                Site site = serverManager.Sites.Add(SiteName, PhysicalPath, 80);

                // Retrieve reference to Binding Info of new site
                BindingCollection bindingCollection = site.Bindings;
                bindingCollection.Clear();

                // Add two Bindings
                string bindingInfo = string.Format("{0}:{1}:{2}", "*", "80", SiteName);
                bindingCollection.Add(bindingInfo, "http");
                bindingInfo = string.Format("{0}:{1}:{2}", "*", "80", "be." + SiteName);
                bindingCollection.Add(bindingInfo, "http");

                if (!string.IsNullOrEmpty(AppPoolName))
                    site.ApplicationDefaults.ApplicationPoolName = AppPoolName;

                serverManager.CommitChanges();
            }

            DevSetupCommandResult result = new DevSetupCommandResult() { CommandName = GetType().Name, CommandResult = true };
            result.Message = "New IIS Site was created Successfully";

            return result;
        }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SiteName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string PhysicalPath { get; set; }

        [Parameter(Mandatory = false)]
        public string AppPoolName { get; set; }
    }
}
