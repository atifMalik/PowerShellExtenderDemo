using System.Linq;
using AtifMalik.Dev.PSExt.PowershellExtender.UnderstoodCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtifMalik.Dev.PSExt.PowershellExtenderTests.UnderstoodTests
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
