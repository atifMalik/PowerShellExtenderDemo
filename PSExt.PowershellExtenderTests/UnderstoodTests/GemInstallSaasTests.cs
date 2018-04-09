using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSExt.PowershellExtender.UnderstoodCommands;

namespace PSExt.PowershellExtenderTests.UnderstoodTests
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
