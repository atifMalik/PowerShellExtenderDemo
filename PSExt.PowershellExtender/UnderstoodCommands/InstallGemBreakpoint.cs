using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using PSExt.Shared.Data;

namespace PSExt.PowershellExtender.UnderstoodCommands
{

    [Cmdlet(VerbsLifecycle.Install, "GemBreakpoint")]
    public class InstallGemBreakpoint : DevSetupCommandBase
    {
        protected override sealed DevSetupCommandResult ExecuteCommand()
        {
            using (PowerShell powerShellInstance = PowerShell.Create())
            {
                // Directly invoke the MSI Installer
                powerShellInstance.AddScript("gem install breakpoint");

                IAsyncResult psResult = powerShellInstance.BeginInvoke();

                while (psResult.IsCompleted == false)
                {
                    Console.WriteLine("Waiting for pipeline to finish");
                    Thread.Sleep(1000);
                }
            }

            DevSetupCommandResult result = new DevSetupCommandResult() { CommandName = GetType().Name, CommandResult = true };
            result.CommandResult = true;
            result.Message = "front-end libraries for UND project were installed successfully on this machine";

            return result;
        }
    }
}
