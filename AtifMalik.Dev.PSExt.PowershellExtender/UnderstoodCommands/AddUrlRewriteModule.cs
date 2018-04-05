using System.Collections.Generic;
using System.Management.Automation;
using AtifMalik.Dev.PSExt.Shared.Data;
using Microsoft.Web.Administration;

namespace AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands
{
    [Cmdlet(VerbsCommon.Add, "UrlRewriteModule")]
    public class AddUrlRewriteModule : DevSetupCommandBase
    {
        public AddUrlRewriteModule()
        {
            CommandResults = new List<DevSetupCommandResult>();
        }

        protected override sealed DevSetupCommandResult ExecuteCommand()
        {
            using (ServerManager serverManager = new ServerManager())
            {
                // Add URL Rewite Module to IIS
                Configuration config = serverManager.GetAdministrationConfiguration();
                ConfigurationSection modulesSection = config.GetSection("modules");

                ConfigurationElementCollection modulesCollection = modulesSection.GetCollection();
                ConfigurationElement addElement = modulesCollection.CreateElement("add");
                addElement["name"] = @"Rewrite";
                modulesCollection.Add(addElement);

                //var real_name = modulesCollection.Attributes.Where(n => n.Value.ToString().ToLower().Contains("rewrite"));

                //var real_name = modulesCollection.Where(c => c.Attributes[0].Value.ToString().ToLower().Contains("Modules"));

                //var real_name_1 = modulesCollection.Where(c => c.Attributes[0].Value.ToString().ToLower().Contains("rewrite"));

                //foreach (var mod in modulesCollection)
                //{
                //    var name = mod.ToString();
                //    var name1 = mod.GetType();

                //}

                serverManager.CommitChanges();
            }

            DevSetupCommandResult result = new DevSetupCommandResult() { CommandName = GetType().Name, CommandResult = true };
            result.Message = "URL Rewrite Module was added Successfully";

            return result;
        }
    }
}
