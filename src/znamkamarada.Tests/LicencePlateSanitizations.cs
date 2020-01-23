using Microsoft.VisualStudio.TestTools.UnitTesting;
using znamkamarada.Services.Library.Tools;

namespace znamkamarada.Tests
{
    [TestClass]
    public class LicencePlateSanitizations
    {
        [TestMethod]
        public void TestLicence01()
        {
            var inputString = "CZ*AZ8360";
            Assert.IsTrue(LicencePlateTools.TrySanitizeInputToLicencePlate(inputString, out var plate));
            Assert.AreEqual("CZ*AZ8360", plate.ToKey());
        }

        [TestMethod]
        public void TestLicence02a()
        {
            var inputString = "AZ8360";
            Assert.IsFalse(LicencePlateTools.TrySanitizeInputToLicencePlate(inputString, out var plate),"Country missing");
        }

        [TestMethod]
        public void TestLicence02b()
        {
            var inputString = "*AZ8360";
            Assert.IsTrue(LicencePlateTools.TrySanitizeInputToLicencePlate(inputString, out var plate), "Unknown country");
            Assert.AreEqual("*AZ8360", plate.ToKey());
        }

        [TestMethod]
        public void TestLicence03()
        {
            var inputString = "";
            Assert.IsFalse(LicencePlateTools.TrySanitizeInputToLicencePlate(inputString, out var plate), "empty");
        }

        [TestMethod]
        public void TestLicence04()
        {
            var inputString = "CZ * Az 83 60";
            Assert.IsTrue(LicencePlateTools.TrySanitizeInputToLicencePlate(inputString, out var plate));
            Assert.AreEqual("CZ*AZ8360",plate.ToKey());

        }
    }
}
