using System;
using System.Management.Automation;
using System.Threading;

namespace AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands
{
    [Cmdlet(VerbsLifecycle.Install, "GemCompass")]
    public class InstallGemCompass : Cmdlet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            using (PowerShell powerShellInstance = PowerShell.Create())
            {
                // Directly invoke the MSI Installer
                powerShellInstance.AddScript("gem install compass -v 1.0.3");

                IAsyncResult result = powerShellInstance.BeginInvoke();

                while (result.IsCompleted == false)
                {
                    Console.WriteLine("Waiting for pipeline to finish");
                    Thread.Sleep(1000);
                }

                Console.Write("gem Compass Installed");
                WriteObject(true);
            }
        }
    }
}
