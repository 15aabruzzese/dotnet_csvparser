using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CSVParser
{
    //Singleton Class
    public partial class CSV_Parser
    {
        private static CSV_Parser? parserInstance;
        private static readonly object objLock = new();
        private static List<CSV_Entry> ValidListOfEmails = [];
        private static List<CSV_Entry> InvalidListOfEmails = [];
        private static int totalNumberOfValidEmails = 0;
        private static int totalNumberOfInvalidEmails = 0;

        private CSV_Parser(){}

        public static CSV_Parser GetInstance(string filePath)
        {
            lock (objLock)
            {
                if (parserInstance == null)
                {
                    parserInstance = new CSV_Parser();
                    ParseCsv(filePath);
                }
                return parserInstance;
            }
        }

        //Checks if the email is null or whitespace, then uses a basic regex pattern to validate the overall structure of the email.
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Simple regex pattern for basic email validation
            return MyRegex().IsMatch(email);
        }

        /*
        Cleans static fields of the class then parses a new file updating the values of the class
        Checks The Following:
            Ensures the string starts with at least one character that is not an '@' or whitespace.
            There should be a '@' symbol.
            After '@', there should be at least one character that is not an '@' or whitespace, followed by a dot.
            Ends with at least one character that is not an '@' or whitespace.
        */
        private static void ParseCsv(string filePath)
        {
            CleanStaticParserInfo();
            try
            {
                using var reader = new StreamReader(filePath);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (IsValidEmail(parts[2]))
                    {
                        ValidListOfEmails.Add(new CSV_Entry(parts[0], parts[1], parts[2]));
                        totalNumberOfValidEmails++;
                    }
                    else
                    {
                        InvalidListOfEmails.Add(new CSV_Entry(parts[0], parts[1], parts[2]));
                        totalNumberOfInvalidEmails++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the CSV file: {ex.Message}");
            }
        }

        public static void PrintValidEmails()
        {
            foreach (var CSV_Entry in ValidListOfEmails)
            {
                Console.WriteLine($"Name: {CSV_Entry.FirstName} {CSV_Entry.LastName}, Email: {CSV_Entry.Email}");
            }
            Console.WriteLine($"Total Number Of Valid Email Addresses: {totalNumberOfValidEmails}");
        }

        public static void PrintInvalidEmails()
        {
            foreach (var CSV_Entry in InvalidListOfEmails)
            {
                Console.WriteLine($"Name: {CSV_Entry.FirstName} {CSV_Entry.LastName}, Email: {CSV_Entry.Email}");
            }
            Console.WriteLine($"Total Number Of Invalid Email Addresses: {totalNumberOfInvalidEmails}");
        }

        public static int GetValidEmailTotal(){
            return totalNumberOfValidEmails;
        }

        public static int GetInvalidEmailTotal(){
            return totalNumberOfInvalidEmails;
        }

        //Resets/Clears static fields
        public static void CleanStaticParserInfo(){
            ValidListOfEmails.Clear();
            InvalidListOfEmails.Clear();
            totalNumberOfInvalidEmails = 0;
            totalNumberOfValidEmails = 0;
        }

        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, "en-US")]
        private static partial Regex MyRegex();
    }
}