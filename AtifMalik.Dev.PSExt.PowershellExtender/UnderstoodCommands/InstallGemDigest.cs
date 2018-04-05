using System;
using System.Management.Automation;
using System.Threading;

namespace AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands
{
    [Cmdlet(VerbsLifecycle.Install, "GemDigest")]
    public class InstallGemDigest : Cmdlet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            using (PowerShell powerShellInstance = PowerShell.Create())
            {
                // Directly invoke the MSI Installer
                powerShellInstance.AddScript("gem install digest");

                IAsyncResult result = powerShellInstance.BeginInvoke();

                while (result.IsCompleted == false)
                {
                    Console.WriteLine("Waiting for pipeline to finish");
                    Thread.Sleep(1000);
                }

                Console.Write("gem Digest Installed");
                WriteObject(true);
            }
        }
    }
}
