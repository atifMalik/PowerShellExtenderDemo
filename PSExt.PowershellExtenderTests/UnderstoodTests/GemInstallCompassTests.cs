using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSExt.PowershellExtender.UnderstoodCommands;

namespace PSExt.PowershellExtenderTests.UnderstoodTests
{
    [TestClass]
    public class GemInstallCompassTests
    {
        [TestMethod]
        public void GemCompass_Installed_Successfully()
        {
            InstallGemCompass cmdlet = new InstallGemCompass();
            var result = cmdlet.Invoke<bool>().ToList().FirstOrDefault();

            Assert.IsTrue(result);
        }
    }
}
