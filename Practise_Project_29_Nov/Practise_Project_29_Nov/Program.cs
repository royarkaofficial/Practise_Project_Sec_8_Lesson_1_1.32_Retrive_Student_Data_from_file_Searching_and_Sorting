using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practise_Project_29_Nov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Specify the path to the text file
            string filePath = "E:/Phase 2/Practise Project Sec 8_Last_Date_29_Nov/students.txt";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Create a list to store student objects
                List<Student> students = new List<Student>();

                // Parse and store student data
                foreach (var line in lines)
                {
                    // Split the line into name and class
                    string[] data = line.Split(',');

                    // Check if the line has the expected format
                    if (data.Length == 2)
                    {
                        string name = data[0].Trim();
                        string studentClass = data[1].Trim();

                        // Create a Student object and add it to the list
                        students.Add(new Student { Name = name, Class = studentClass });
                    }
                    else
                    {
                        Console.WriteLine($"Invalid data format: {line}");
                    }
                }
                // Sort the students by name
                students = students.OrderBy(s => s.Name).ToList();

                // Display the sorted student data
                DisplayStudents(students);

                // Search for a student by name
                Console.WriteLine("Enter the name to search:");
                string searchName = Console.ReadLine().Trim();

                // Find the first student whose name contains the search string
                Student foundStudent = students.FirstOrDefault(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

                // Display the result
                if (foundStudent != null)
                {
                    Console.WriteLine($"Student found: {foundStudent.Name}, Class: {foundStudent.Class}");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }

            Console.ReadKey();
        }
        // Method to display students
        static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine("Sorted Student Data:");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Class: {student.Class}");
            }
            Console.WriteLine();
        }
        // Class to represent a Student
        class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
        }
    }
}