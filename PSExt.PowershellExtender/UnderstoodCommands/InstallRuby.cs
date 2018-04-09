using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Net;
using System.Threading;
using PSExt.Shared.Data;

namespace PSExt.PowershellExtender.UnderstoodCommands
{
    /// <summary>
    /// Downloads Ruby installer from hard-coded URL, and runs the Ruby installer.
    /// The Ruby installer needs to be run by user to finish installation of Ruby.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Install, "Ruby")]
    public class InstallRuby : DevSetupCommandBase
    {
        public InstallRuby()
        {
            CommandResults = new List<DevSetupCommandResult>();
        }

        protected override sealed DevSetupCommandResult ExecuteCommand()
        {
            if (!ValidateParameters())
                return null;

            var rubyFilePath = Path.Combine(Path.GetTempPath(), DownloadFilename);

            // Download Ruby Installer File
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(DownloadUrl, rubyFilePath);
            }

            Process installerProcess = Process.Start(rubyFilePath, "/q");

            while (installerProcess.HasExited == false)
            {
                //indicate progress to user

                Console.WriteLine("Waiting for the Ruby program to install");
                Thread.Sleep(250);
            }

            // Directly invoke the EXE using System Diagnostics Process class
            //ProcessStartInfo psi = new ProcessStartInfo();
            //psi.Arguments = "/s /v /qn /min";
            //psi.CreateNoWindow = true;
            //psi.WindowStyle = ProcessWindowStyle.Hidden;
            //psi.FileName = rubyFilePath;
            //psi.UseShellExecute = false;
            //Process.Start(psi);

            DevSetupCommandResult result = new DevSetupCommandResult() { CommandName = GetType().Name, CommandResult = true };
            result.Message = "Ruby was installed successfully on this machine";

            return result;
        }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DownloadUrl { get; set; }
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DownloadFilename { get; set; }
    }
}
