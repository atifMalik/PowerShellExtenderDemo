﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PSExt.UnderstoodSetup
{
    [RunInstaller(true)]
    public partial class UnderstoodSetupAction : Installer
    {
        public UnderstoodSetupAction()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

#if DEBUG
            int processId = Process.GetCurrentProcess().Id;
            string message = string.Format("Please attach the debugger (elevated on Vista or Win 7) to process [{0}].", processId);
            MessageBox.Show(message, "Debug");
#endif
            
            UnderstoodConfigManager.GitUsername = Context.Parameters["GitUserName"];
            UnderstoodConfigManager.GitPassword = Context.Parameters["GitPwd"];
            UnderstoodConfigManager.GitHubRepoUrl = Context.Parameters["GitRepoURL"];
            UnderstoodConfigManager.GitRepoFolderHdd = Path.Combine(Context.Parameters["TargetDir"], "Source Code");

            var commands = new UnderstoodCommandFactory().CreateAllCommands();
            var results = new UnderstoodCommandExecutor().ExecuteCommands(commands);

            var sbLogContents = new StringBuilder();

            foreach (var result in results)
            {
                string strResult = result.CommandResult ? "PASSED" : "FAILED";
                sbLogContents.AppendFormat("Command {0} {1} with Message: {2}.{3}", result.CommandName, strResult, result.Message, Environment.NewLine);
            }


            var logFilePath = Path.Combine(Context.Parameters["TargetDir"], "Setup_Install.log");

            using (var streamWriter = new StreamWriter(logFilePath))
            {
                streamWriter.WriteLine(sbLogContents.ToString());
            }
        }
    }
}
