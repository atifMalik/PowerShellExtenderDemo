using System;
using PSExt.PowershellExtender.UnderstoodCommands;
using PSExt.UnderstoodSetup;

namespace PSExt.UnderstoodSetupTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunspaceConfiguration runspaceConfig = RunspaceConfiguration.Create();
            //Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfig);
            //runspace.Open();

            ////RunspaceInvoke scriptInvoker = new RunspaceInvoke();
            //Pipeline pipeline = runspace.CreatePipeline();

            ////Here's how you add a new script with arguments
            //string scriptfile = "just another script";
            //Command myCommand = new Command(scriptfile);
            //CommandParameter testParam = new CommandParameter("key", "value");
            //myCommand.Parameters.Add(testParam);

            //pipeline.Commands.Add(myCommand);

            //// Execute PowerShell script
            //var results = pipeline.Invoke();
            //pipeline.Dispose();

            //var cmd = new AddAppPool();

            UnderstoodCommandFactory factory = new UnderstoodCommandFactory();
            var commands = factory.CreateAllCommands();

            var executor = new UnderstoodCommandExecutor();
            var results = executor.ExecuteCommands(commands);

            foreach (var result in results)
            {
                string strResult = result.CommandResult ? "PASSED" : "FAILED";
                Console.WriteLine("Command {0} {1} with Message: {2}.", result.CommandName, strResult, result.Message.Trim());
            }

            Console.ReadLine();
        }
    }
}
