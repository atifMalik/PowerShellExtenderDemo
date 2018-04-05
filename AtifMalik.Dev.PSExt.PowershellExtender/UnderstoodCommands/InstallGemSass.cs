using System;
using System.Management.Automation;
using System.Threading;

namespace AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands
{
    [Cmdlet(VerbsLifecycle.Install, "GemSaas")]
    public class InstallGemSass : Cmdlet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            using (PowerShell powerShellInstance = PowerShell.Create())
            {
                // Directly invoke the MSI Installer
                powerShellInstance.AddScript("gem install sass -v 3.4.18");

                IAsyncResult result = powerShellInstance.BeginInvoke();

                while (result.IsCompleted == false)
                {
                    Console.WriteLine("Waiting for pipeline to finish");
                    Thread.Sleep(1000);
                }

                Console.Write("gem SAAS Installed");
                WriteObject(true);

            }
        }
    }
}
