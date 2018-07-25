using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Reflection;
using PSExt.Shared.Contracts;
using PSExt.Shared.Data;

namespace PSExt.PowershellExtender
{
    /// <summary>
    /// Abstract class contains operations common to all commands in the project, to avoid duplication of code.
    /// The IDevSetupCommand interface is implemented on abstract class to ensure consistent command behavior.
    /// </summary>
    public abstract class DevSetupCommandBase : Cmdlet, IDevSetupCommand
    {
        public DevSetupCommandBase()
        {
            CommandResults = new List<DevSetupCommandResult>();
        }

        #region IDevSetupCommand Members
        public virtual int CommandOrder { get; set; }

        public List<DevSetupCommandResult> CommandResults { get; protected set; }

        /// <summary>
        /// IDevSetupCommand method that provides clients with a way to execute the command.
        /// This method follows 'Template Method' design pattern.
        /// The command results are populated here; try-catch logic is encapsulated here as well.
        /// </summary>
        public void Execute()
        {
            DevSetupCommandResult result = new DevSetupCommandResult() { CommandName = GetType().Name };

            try
            {
                result = ExecuteCommand();
            }
            catch (Exception ex)
            {
                result.CommandResult = false;
                result.Message = ex.Message;
            }
            finally
            {
                if (result != null)
                    CommandResults.Add(result);
            }
        }
        #endregion

        /// <summary>
        /// Abstract method must be overridden by command classes; part of 'Template Method' design pattern.
        /// </summary>
        /// <returns></returns>
        protected abstract DevSetupCommandResult ExecuteCommand();

        /// <summary>
        /// Cmdlet class method that allows the command to be execute as a PowerShell command through the PS IDE or console.
        /// </summary>
        protected sealed override void ProcessRecord()
        {
            base.ProcessRecord();
            Execute();
            WriteObject(CommandResults);
        }

        /// <summary>
        /// Uses reflection to validate PowerShell parameters that are marked as mandatory.
        /// </summary>
        /// <returns></returns>
        protected bool ValidateParameters()
        {
            var validationPassed = true;

            foreach (PropertyInfo propInfo in GetType().GetProperties())
            {
                if (Attribute.GetCustomAttribute(propInfo, typeof(ParameterAttribute)) is ParameterAttribute attribute && attribute.Mandatory)
                {
                    string value = propInfo.GetValue(this) as string;
                    if (string.IsNullOrEmpty(value))
                    {
                        DevSetupCommandResult result = new DevSetupCommandResult() { CommandName = GetType().Name, CommandResult = false };
                        result.Message = string.Format("{0} Cmdlet Parameter was not supplied.", propInfo.Name);
                        CommandResults.Add(result);

                        validationPassed = false;
                    }
                }
            }

            return validationPassed;
        }
    }
}
