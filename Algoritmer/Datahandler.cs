using System;
using System.IO;
using System.Collections.Generic;
using Algoritmer;

namespace Algoritmer
{
    public class DataHandler
    {
        private readonly string dataFileName;

        // Constructor
        public DataHandler(string dataFileName)
        {
            // Tjek om filen eksisterer
            if (File.Exists(dataFileName))
            {
                this.dataFileName = dataFileName;
            }
            else
            {
                throw new FileNotFoundException("Filen blev ikke fundet.", dataFileName);
            }
        }
        // SaveStudents method
        public void SaveStudents(List<Student> students)
        {
            try
            {
                // Åbn filen til skrivning (skriver over eksisterende fil)
                using (StreamWriter writer = new StreamWriter("sorted_students.txt"))
                {
                    foreach (var student in students)
                    {
                        // Skriv hver studerendes oplysninger til filen
                        writer.WriteLine($"{student.FullName},{student.GroupNumber}");
                    }
                }
                Console.WriteLine("Sorteret data blev gemt til filen 'sorted_students.txt'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl ved gemning af data: {ex.Message}");
            }
        }




        // LoadStudents method
        public List<Student> LoadStudents()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (StreamReader reader = new StreamReader(dataFileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 2)
                        {
                            string fullName = parts[0].Trim();
                            int groupNumber;

                            if (int.TryParse(parts[1].Trim(), out groupNumber))
                            {
                                Student student = new Student(fullName, groupNumber);
                                students.Add(student);
                            }
                            else
                            {
                                Console.WriteLine($"Ugyldigt gruppenummerformat på linje: {line}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Ugyldigt antal dele på linje: {line}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl ved indlæsning af data: {ex.Message}");
            }

            return students;
        }




    }
}




