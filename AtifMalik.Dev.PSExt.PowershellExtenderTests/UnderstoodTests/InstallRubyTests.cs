using System.IO;
using System.Linq;
using AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands;
using AtifMalik.Dev.PSExt.Shared.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtifMalik.Dev.PSExt.PowershellExtenderTests.UnderstoodTests
{
    [TestClass]
    public class InstallRubyTests
    {
        public static dynamic _results;

        [ClassInitialize]
        public static void Run_Ruby_Command(TestContext context)
        {
            InstallRuby cmdlet = new InstallRuby();

            _results = cmdlet.Invoke<bool>().ToList().FirstOrDefault();
        }

        [TestMethod]
        public void Ruby_Installer_File_Exists()
        {
            var path = Path.Combine(Path.GetTempPath(), UnderstoodConfigManager.Instance.RubyInstallerFilename);

            var exists = File.Exists(path);

            Assert.IsTrue(exists);
        }


        //[TestMethod]
        //public void Ruby_Program_Installed_Successfully()
        //{
        //    var didIt = IsSoftwareInstalled(UnderstoodConfigManager.Instance["Ruby_Installed_ProgramName"]);
        //    Assert.IsTrue(didIt);
        //}

        //private bool IsSoftwareInstalled(string softwareName)
        //{
        //    var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall") ??
        //                Registry.LocalMachine.OpenSubKey(
        //                    @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
        //                );

        //    if (key == null)
        //        return false;

        //    return key.GetSubKeyNames()
        //        .Select(keyName => key.OpenSubKey(keyName))
        //        .Select(subkey => subkey.GetValue("DisplayName") as string)
        //        .Any(displayName => displayName != null && displayName.Contains(softwareName));
        //}
    }
}
