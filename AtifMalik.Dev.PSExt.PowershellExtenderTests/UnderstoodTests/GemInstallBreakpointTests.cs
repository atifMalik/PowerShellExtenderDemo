using System.Linq;
using AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtifMalik.Dev.PSExt.PowershellExtenderTests.UnderstoodTests
{
    [TestClass]
    public class GemInstallBreakpointTests
    {
        [TestMethod]
        public void GemBreakpoint_Installed_Successfully()
        {
            InstallGemBreakpoint cmdlet = new InstallGemBreakpoint();
            var result = cmdlet.Invoke<bool>().ToList().FirstOrDefault();

            Assert.IsTrue(result);
        }
    }
}
