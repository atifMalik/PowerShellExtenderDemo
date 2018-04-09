using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSExt.PowershellExtender.UnderstoodCommands;

namespace PSExt.PowershellExtenderTests.UnderstoodTests
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
