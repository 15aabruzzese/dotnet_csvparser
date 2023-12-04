
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CSVParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Prompt User: Input name of file in the CSVInputDirectory
            Console.WriteLine("Enter the file name:");
            try{
                var fileName = Console.ReadLine();
                string directoryPath = "CSVInputDirectory";
                string fullPath = Path.Combine(directoryPath, fileName != null ? fileName : "");

                if (File.Exists(fullPath))
                {
                    Console.WriteLine("Success: File found.");
                    CSV_Parser x = CSV_Parser.GetInstance(fullPath);
                    x.PrintValidEmails();
                    x.PrintInvalidEmails();
                }
                else
                {
                    Console.WriteLine("Failure: File not found.");
                }
            }catch(Exception e){
                Console.WriteLine("Unexpected Error Occured"+e);
            }
        }
    }
}
