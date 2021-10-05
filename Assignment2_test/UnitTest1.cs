using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;

namespace Assignment2_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ParticleMovement particleMovement = new ParticleMovement();


            particleMovement.CalculateDistance();
            particleMovement.MagneticField = false;
            Assert.AreEqual(false, particleMovement.MagneticField);
            particleMovement.GravitationalField = true;
            Assert.AreEqual(true, particleMovement.GravitationalField);
        }
    }
}
