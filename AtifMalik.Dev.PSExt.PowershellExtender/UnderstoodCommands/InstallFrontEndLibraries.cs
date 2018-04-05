using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using AtifMalik.Dev.PSExt.Shared.Data;

namespace AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands
{
    [Cmdlet(VerbsLifecycle.Install, "FrontEndLibraries")]
    public class InstallFrontEndLibraries : DevSetupCommandBase
    {
        public InstallFrontEndLibraries()
        {
            CommandResults = new List<DevSetupCommandResult>();
        }

        protected override sealed DevSetupCommandResult ExecuteCommand()
        {
            Process process = new Process();

            process.EnableRaisingEvents = true;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;

            // Redirect the following streams
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            // Capture cmd output and cmd errors by subscribing to events
            process.OutputDataReceived += Process_OutputDataReceived;
            process.ErrorDataReceived += Process_ErrorDataReceived;

            // do not create a cmd window
            process.StartInfo.CreateNoWindow = true;
            //process.StartInfo.Arguments = "/C ";

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            using (StreamWriter input = process.StandardInput)
            {
                input.WriteLine("gem install -V sass -v 3.4.18");
                input.WriteLine("gem install -V compass -v 1.0.3");
                input.WriteLine("gem install -V breakpoint");
                input.WriteLine("gem install -V digest");

                input.Close();
            }
                
            process.WaitForExit();
            process.Close();

            DevSetupCommandResult result = new DevSetupCommandResult() { CommandName = GetType().Name, CommandResult = true };
            result.Message = "front-end libraries for UND project were installed successfully on this machine";

            return result;
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            var result = new DevSetupCommandResult();
            result.CommandResult = false;
            result.CommandName = GetType().Name;
            result.Message = e.Data;

            CommandResults.Add(result);
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            var result = new DevSetupCommandResult();
            result.CommandResult = true;
            result.CommandName = GetType().Name;
            result.Message = e.Data;

            CommandResults.Add(result);
        }
    }
}
