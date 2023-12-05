using NUnit.Framework;
using CSVParser; // Import the namespace where Program class is defined

namespace Tests
{
    public class ProgramTests
    {
        [Test]
        public void ProgramClassExistsTest()
        {
            // Arrange & Act
            var programType = typeof(Program);

            // Assert
            Assert.That(programType, Is.Not.Null, "Program class should exist in CSVParser namespace");
        }

        [Test]
        public void InitalizeParser()
        {
            var testParser = CSV_Parser.GetInstance("../../../../CSVInputDirectory/dotNetTest.csv");
        }

        [Test]
        public void InitalizeCSVEntry()
        {
            CSV_Entry testEntry = new("First Name","Last Name","Email Address");
        }

        [Test]
        public void EmailValidationTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(CSV_Parser.IsValidEmail("andrew.abruzzese@outlook.com"), Is.True, "Testing Valid Email");
                Assert.That(CSV_Parser.IsValidEmail("somethingsomething@giberish"), Is.False, "Email without domain extension should be invalid.");
                Assert.That(CSV_Parser.IsValidEmail("somethingsomething.giberish.com"), Is.False, "Email without @ should be invalid.");
                Assert.That(CSV_Parser.IsValidEmail("anothertestemail@giberish."), Is.False, "Email with invalid domain should be invalid.");
            });
        }

        [Test]
        public void TestTotalInvalid()
        {
            CSV_Parser testParser = CSV_Parser.GetInstance("../../../../CSVInputDirectory/dotNetTest.csv");
            Assert.That(CSV_Parser.GetInvalidEmailTotal(), Is.EqualTo(3), "Total Invalid: "+CSV_Parser.GetInvalidEmailTotal());
        }

        [Test]
        public void TestTotalValid()
        {
            CSV_Parser testParser = CSV_Parser.GetInstance("../../../../CSVInputDirectory/dotNetTest.csv");
            Assert.That(CSV_Parser.GetValidEmailTotal(), Is.EqualTo(1), "Total Valid: "+CSV_Parser.GetValidEmailTotal());
        }
    }
}
