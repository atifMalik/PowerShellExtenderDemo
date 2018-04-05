using System;
using System.Management.Automation;

namespace Rightpoint.Dev.Cms.PowershellExtender.UnderstoodCommands
{
    [Cmdlet("Run", "DemoCommand")]
    public class RunDemoCommand : Cmdlet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            Console.WriteLine("For Demo purposes");
            Console.WriteLine("For Demo purposes");
            Console.WriteLine("For Demo purposes");
            Console.WriteLine("For Demo purposes");
            Console.WriteLine("For Demo purposes");
        }
    }
}
