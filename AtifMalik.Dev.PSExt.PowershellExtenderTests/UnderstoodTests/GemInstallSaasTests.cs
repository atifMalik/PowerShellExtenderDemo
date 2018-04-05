using System.Linq;
using AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtifMalik.Dev.PSExt.PowershellExtenderTests.UnderstoodTests
{
    [TestClass]
    public class GemInstallSaasTests
    {
        [TestMethod]
        public void GemSaas_Installed_Successfully()
        {
            InstallGemSass cmdlet = new InstallGemSass();
            var result = cmdlet.Invoke<bool>().ToList().FirstOrDefault();

            Assert.IsTrue(result);
        }
    }
}
