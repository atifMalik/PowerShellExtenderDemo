using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Web.Administration;
using PSExt.Shared.Data;

namespace PSExt.PowershellExtender.UnderstoodCommands
{
    /// <summary>
    /// Adds an App Pool with the given App Pool name.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AppPool")]
    public class AddAppPool : DevSetupCommandBase
    {
        protected override sealed DevSetupCommandResult ExecuteCommand()
        {
            using (ServerManager serverManager = new ServerManager())
            {
                ApplicationPool newPool = serverManager.ApplicationPools.Add(AppPoolName);
                newPool.ManagedRuntimeVersion = "v4.0";
                newPool.Enable32BitAppOnWin64 = false;
                newPool.ManagedPipelineMode = ManagedPipelineMode.Integrated;
                newPool.QueueLength = 1000;

                // Set NetworkService as App Pool Identity
                newPool.ProcessModel.IdentityType = ProcessModelIdentityType.NetworkService;

                serverManager.CommitChanges();
            }

            DevSetupCommandResult result = new DevSetupCommandResult() { CommandName = GetType().Name, CommandResult = true };
            result.Message = "New App Pool was created Successfully";

            return result;
        }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string AppPoolName { get; set; }
    }
}
