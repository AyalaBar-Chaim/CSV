using Ayalas_Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        CSV csv = new CSV();
        List<string> femaleFirstNames = new List<string> { "Ayala", "Miriam", "Tova", "Michal", "Noa", "Shira", "Tamar", "Hadas" };
        List<string> maleFirstNames = new List<string> { "Naftali", "Avi", "David", "Yonatan", "Tzvi", "Yakov", "Asher", "Nachum" };
        List<string> lastNames = new List<string> { "Smith", "Johnson", "Williams", "Jones", "Brown", "Miller", "Davis", "Garcia", "Rodriguez", "Martinez" };

        string[] headers = { "FirstName", "LastName", "Age", "Weight", "Gender" };
        string filePath = "persons_details.csv";

        // Generate data and write to CSV
        List<List<object>> data = csv.GenerateData(femaleFirstNames, maleFirstNames, lastNames, 1000);
        csv.WriteToCsv(filePath, headers, data);

        Console.WriteLine("CSV file created successfully.\n");

        // Print the contents of the CSV file
        //PrintCsvContents(filePath);

        // Read and analyze CSV data
        var lines = File.ReadAllLines(filePath).Skip(1); // Skip header
        var parsedData = lines.Select(line => line.Split(',')).Select(fields => new
        {
            FirstName = fields[0],
            LastName = fields[1],
            Age = int.Parse(fields[2]),
            Weight = double.Parse(fields[3]),
            Gender = fields[4]
        }).ToList();

        // Calculate and print statistics
        double averageAge = parsedData.Average(person => person.Age);
        Console.WriteLine($"\nAverage age of all people: {averageAge:F2} years");

        int countInRange = parsedData.Count(person => person.Weight >= 120 && person.Weight <= 140);
        Console.WriteLine($"Total number of people weighing between 120lbs and 140lbs: {countInRange}");

        double averageAgeInRange = parsedData.Where(person => person.Weight >= 120 && person.Weight <= 140).Average(person => person.Age);
        Console.WriteLine($"Average age of people weighing between 120lbs and 140lbs: {averageAgeInRange:F2} years");
    }
}

