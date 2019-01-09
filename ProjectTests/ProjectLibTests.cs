using System;
using System.Runtime.CompilerServices;
using InnoLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectTests
{
    [TestClass]
    public class ProjectLibTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Points kan ikke være lavere end 0 eller højere end 100")]
        public void TestProjectCreationBadConstructorValues()
        {
            Project project = new Project(2, "TestName", "TestCategory", 101);
        }

        [TestMethod]
        public void TestProjectReadPointsPass()
        {
            Project project = new Project(3,"TestName", "TestCategory", 50);

            Assert.AreEqual(true, project.MyPoints(50));
        }

        [TestMethod]
        public void TestProjectReadPointsFail()
        {
            Project project = new Project(3, "TestName", "TestCategory", 50);

            Assert.AreEqual(false, project.MyPoints(-10));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Points kan ikke være lavere end 0 eller højere end 100")]
        public void TestProjectPointsTooHighException()
        {
            Project project = new Project(3, "TestName", "TestCategory", 50);

            project.Points = 101;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Points kan ikke være lavere end 0 eller højere end 100")]
        public void TestProjectPointsTooLowException()
        {
            Project project = new Project(3, "TestName", "TestCategory", 50);

            project.Points = -1;
        }

        [TestMethod]
        public void TestProjectPointsCorrectHigh()
        {
            Project project = new Project(3, "TestName", "TestCategory", 50);
            project.Points = 100;

            Assert.AreEqual(project.Points, 100);
        }

        [TestMethod]
        public void TestProjectPointsCorrectLow()
        {
            Project project = new Project(3, "TestName", "TestCategory", 50);
            project.Points = 0;

            Assert.AreEqual(project.Points, 0);
        }
        [TestMethod]
        public void TestProjectPropetyCanBeRead()
        {
            Project project = new Project(3, "TestName", "TestCategory", 77);

            Assert.AreEqual(77, project.Points);
        }
    }
}
