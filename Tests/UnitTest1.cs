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
            Assert.NotNull(programType, "Program class should exist in CSVParser namespace");
        }

        [Test]
        public void InitalizeParser()
        {
            var testParser = CSV_Parser.GetInstance("../../../../CSVInputDirectory/dotNetTest.csv");
        }

        [Test]
        public void InitalizeCSVEntry()
        {
            CSV_Entry testEntry = new CSV_Entry("First Name","Last Name","Email Address");
        }

        [Test]
        public void EmailValidationTest()
        {
            Assert.IsTrue(CSV_Parser.IsValidEmail("andrew.abruzzese@outlook.com"), "Testing Valid Email");
            Assert.IsFalse(CSV_Parser.IsValidEmail("somethingsomething@giberish"), "Email without domain extension should be invalid.");
            Assert.IsFalse(CSV_Parser.IsValidEmail("somethingsomething.giberish.com"), "Email without @ should be invalid.");
            Assert.IsFalse(CSV_Parser.IsValidEmail("anothertestemail@giberish."), "Email with invalid domain should be invalid.");
        }
        
        [Test]
        public void TestTotalInvalid()
        {
            CSV_Parser testParser = CSV_Parser.GetInstance("../../../../CSVInputDirectory/dotNetTest.csv");
            Assert.IsTrue(testParser.getInvalidEmailTotal() == 3, "Total Invalid: "+testParser.getInvalidEmailTotal());
        }

        [Test]
        public void TestTotalValid()
        {
            CSV_Parser testParser = CSV_Parser.GetInstance("../../../../CSVInputDirectory/dotNetTest.csv");
            Assert.IsTrue(testParser.getValidEmailTotal() == 1, "Total Valid: "+testParser.getValidEmailTotal());
        }
    }
}
