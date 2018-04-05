﻿using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using AtifMalik.Dev.PSExt.Shared.Data;

namespace AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands
{

    [Cmdlet(VerbsLifecycle.Install, "GemBreakpoint")]
    public class InstallGemBreakpoint : DevSetupCommandBase
    {
        public InstallGemBreakpoint()
        {
            CommandResults = new List<DevSetupCommandResult>();
        }

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
