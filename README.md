# PowerShellExtenderDemo

### This solution shows how to extend PowerShell using C# __Cmdlet__ classes in .NET __System.Management.Automation__ namespace.

This is a DevOps solution which includes an MSI Installer project. ("Understood" is the name of a software development project.) The MSI Installer was designed to install/create all dependencies that happen to be pre-requisites for a software developer to commence work on the (Understood) development project. 

The Installer project runs all commands, defined in __PowershellExtender__ project, as part of the installation process. A log file is produced at the termination of MSI install - the file notes commands that passed or failed. The user will then have the ability to re-run the failed commands individually, after remediating the issues mentioned in log file. 

To re-run the (failed) commands individually, the user can open a PowerShell (PS) console, import __PowershellExtender__ (C#) class library as a PowerShell module using the following PS command, and then execute the individual command as a PS command, using the name attribute string defined on the Command class.

* __-Command "Import-Module .\PowershellExtender.dll"__

### *To facilitate the above-mentioned use cases, the command classes are derived from the following two base constructs*
* *a custom interface (__IDevSetupCommand__) that allows the MSI project to execute commands in bulk as C# command objects that follow the simple 'Command' design pattern, and*
* *__'Cmdlet'__ class defined in __System.Management.Automation__ namespace; this allows the same command to be executed individually as a PowerShell command.*

### Following is a brief description for each of the projects in the solution.

#### 1. PSExt.PowershellExtender
This project contains all commands (following the 'Command' design pattern); each command class inherits from __DevSetupCommandBase__ class. The __DevSetupCommandBase__ class inherits from __Cmdlet__ class as well as implements __IDevSetupCommand__ interface.

1. The __IDevSetupCommand__ interface defines __Execute()__ method that allows the MSI installer to execute these commands as C# command objects.
2. The __Execute()__ method follows __'Template Method'__ design pattern; this is to avoid duplication of code across command classes.
3. Inheriting from __Cmdlet__ class allows the same command to be executed as a PowerShell command. __ProcessRecord()__ method (overridden from __Cmdlet__ class) gets called, each time the command is executed as a PowerShell command.
4. __ProcessRecord()__ method calls into __Execute()__ method (see #1 above), thus ensuring that same logic is executed when the command is executed as a PowerShell command.


#### 2. PSExt.PowershellExtenderTests
This project contains Unit Tests to test the individual commands in Project #1 (above). The unit tests are fairly rudimentary, in the sense that the actual command dependencies were never abstracted away, so no Mocks in this MS Test project.

#### 3. PSExt.Shared
This project contains interfaces that are common to all different DevOps projects (Only the __"Understood"__ project is fully fleshed out as of yet).
It also contains the data class __DevSetupCommandResult__ which encapsulates the execution results for each command.

#### 4. PSExt.UnderstoodSetup
This project is specific to the "__Understood__" DevOps project. It houses:
1. A factory class to create commands that are specific to "__Understood__" project,
2. A Command Executor class to execute all commands created through factory,
3. __UnderstoodConfigManager__ contains data properties that are populated with parameter values provided by user during the MSI Install process, and
4. __UnderstoodSetupAction__ class that defines logic to be executed during the MSI Install process.

##### Note: Each DevOps project will have its own copy of "Setup" project.

#### 5. PSExt.UnderstoodSetup.Installer
Finally the MSI Installer project that uses SetupAction in project #4 (above), to run commands (also created in project #4 above) as part of the MSI Install process.

