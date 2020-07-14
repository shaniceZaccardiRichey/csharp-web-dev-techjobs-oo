using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {
            Job jobOne = new Job();
            Job jobTwo = new Job();

            int idDifference = (jobTwo.Id - jobOne.Id);

            Assert.IsTrue(idDifference == 1);
            Assert.IsFalse(jobOne.Id == jobTwo.Id);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job jobComplete = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistance"));

            Assert.AreEqual("Product tester", jobComplete.Name);
            Assert.AreEqual("ACME", jobComplete.EmployerName.Value);
            Assert.AreEqual("Desert", jobComplete.EmployerLocation.Value);
            Assert.AreEqual("Quality control", jobComplete.JobType.Value);
            Assert.AreEqual("Persistance", jobComplete.JobCoreCompetency.Value);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job jobOne = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistance"));
            Job jobTwo = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistance"));

            Assert.IsFalse(jobOne.Equals(jobTwo));
        }

        // ToString() Tests
        [TestMethod]
        public void ToStringBlankLines()
        {
            Job jobTest = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistance"));

            string toStringResult = jobTest.ToString();

            Assert.IsTrue(toStringResult.StartsWith("\n"));
            Assert.IsTrue(toStringResult.EndsWith("\n"));
        }

        [TestMethod]
        public void ToStringFieldLines()
        {
            Job jobTest = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistance"));

            string toStringResult = jobTest.ToString();

            Assert.IsTrue(toStringResult.Contains("\nName: Product tester"));
            Assert.IsTrue(toStringResult.Contains("\nEmployer: ACME"));
            Assert.IsTrue(toStringResult.Contains("\nLocation: Desert"));
            Assert.IsTrue(toStringResult.Contains("\nPosition Type: Quality control"));
            Assert.IsTrue(toStringResult.Contains("\nCore Competency: Persistance"));
        }

        [TestMethod]
        public void ToStringDataNotAvailable()
        {
            Job jobTest = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency(""));

            string toStringResult = jobTest.ToString();

            Assert.IsTrue(toStringResult.Contains("\nName: Product tester"));
            Assert.IsTrue(toStringResult.Contains("\nEmployer: ACME"));
            Assert.IsTrue(toStringResult.Contains("\nLocation: Desert"));
            Assert.IsTrue(toStringResult.Contains("\nPosition Type: Quality control"));
            Assert.IsTrue(toStringResult.Contains("\nCore Competency: Data not available."));
        }

        [TestMethod]
        public void ToStringIdOnly()
        {
            Job jobTest = new Job();

            string toStringResult = jobTest.ToString();

            Assert.AreEqual("OOPS! This job does not seem to exist.", toStringResult);
        }
    }
}
