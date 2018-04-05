using System.Linq;
using AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtifMalik.Dev.PSExt.PowershellExtenderTests.UnderstoodTests
{
    [TestClass]
    public class GemInstallDigestTests
    {
        [TestMethod]
        public void GemDigest_Installed_Successfully()
        {
            InstallGemDigest cmdlet = new InstallGemDigest();
            var result = cmdlet.Invoke<bool>().ToList().FirstOrDefault();

            Assert.IsTrue(result);
        }
    }
}
