using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSExt.PowershellExtender.UnderstoodCommands;

namespace PSExt.PowershellExtenderTests.UnderstoodTests
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
