using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayalas_Project
{
    public class CSV
    {
        public List<List<object>> GenerateData(List<string> femaleFirstNames, List<string> maleFirstNames, List<string> lastNames, int rowCount)
        {
            List<List<object>> data = new List<List<object>>();
            Random random = new Random();

            for (int i = 0; i < rowCount; i++)
            {
                string firstName = (random.Next(2) == 0) ? femaleFirstNames[random.Next(femaleFirstNames.Count)] : maleFirstNames[random.Next(maleFirstNames.Count)];
                string lastName = lastNames[random.Next(lastNames.Count)];
                int age = random.Next(18, 71);
                double weight = Math.Round(random.NextDouble() * (200 - 100) + 100, 2); // Generate weight in lbs
                string gender = (firstName == femaleFirstNames[random.Next(femaleFirstNames.Count)]) ? "Female" : "Male";

                List<object> person = new List<object> { firstName, lastName, age, weight, gender };
                data.Add(person);
            }

            return data;
        }

        public void WriteToCsv(string filePath, string[] headers, List<List<object>> data)
        {
            using (StreamWriter file = new StreamWriter(filePath))
            {
                file.WriteLine(string.Join(",", headers));

                foreach (var row in data)
                {
                    file.WriteLine(string.Join(",", row));
                }
            }
        }

        public void PrintCsvContents(string filePath)
        {
            Console.WriteLine("Contents of the CSV file:");
            var csvLines = File.ReadAllLines(filePath);
            foreach (var line in csvLines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }

}

