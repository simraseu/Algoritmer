using System;
using System.Collections.Generic;
using Algoritmer;
using uge_14_algoritmer;

namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataFileName = "students.txt";
            DataHandler dataHandler = new DataHandler(dataFileName);

            // Hovedmenu
            Console.WriteLine("Hovedmenu:");
            Console.WriteLine("1. Sortering");
            Console.WriteLine("2. Søgning");
            Console.Write("Indtast dit valg: ");

            int mainChoice;
            while (!int.TryParse(Console.ReadLine(), out mainChoice) || mainChoice < 1 || mainChoice > 2)
            {
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
            }

            switch (mainChoice)
            {
                case 1:
                    SortingMenu(dataHandler);
                    break;
                case 2:
                    SearchMenu(dataHandler);
                    break;
                default:
                    break;
            }
        }

        // Metode til sortering menu
        static void SortingMenu(DataHandler dataHandler)
        {
            Console.WriteLine("Sortering:");
            Console.WriteLine("1. Sorter efter Group Number");
            Console.WriteLine("2. Sorter efter Navn");
            Console.Write("Indtast dit valg: ");

            int sortingChoice;
            while (!int.TryParse(Console.ReadLine(), out sortingChoice) || sortingChoice < 1 || sortingChoice > 2)
            {
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
            }

            List<Student> students = dataHandler.LoadStudents();

            switch (sortingChoice)
            {
                case 1:
                    SortingAlgos.SelectionSort(students);
                    break;
                case 2:
                    SortingAlgos.QuickSort(students, 0, students.Count - 1);
                    break;
                default:
                    break;
            }

            // Udskriv sorteret liste til konsollen
            Console.WriteLine("Sorteret liste:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FullName} - Gruppe {student.GroupNumber}");
            }

            // Gem sorteret data til filen
            dataHandler.SaveStudents(students);
        }

        // Metode til søgning menu
        static void SearchMenu(DataHandler dataHandler)
        {
            Console.WriteLine("Søgning:");
            Console.WriteLine("1. Linear søgning");
            Console.WriteLine("2. Binær søgning");
            Console.Write("Indtast dit valg: ");

            int searchChoice;
            while (!int.TryParse(Console.ReadLine(), out searchChoice) || searchChoice < 1 || searchChoice > 2)
            {
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
            }

            List<Student> students = dataHandler.LoadStudents();

            switch (searchChoice)
            {
                case 1:
                    Console.Write("Indtast fulde navn for at søge: ");
                    string fullNameLinear = Console.ReadLine();
                    var resultLinear = SearchAlgorithms.LinearSearch(students, fullNameLinear);
                    if (resultLinear != null)
                    {
                        Console.WriteLine($"Studerende fundet: {resultLinear.FullName} - Gruppe {resultLinear.GroupNumber}");
                    }
                    else
                    {
                        Console.WriteLine("Studerende ikke fundet.");
                    }
                    break;
                case 2:
                    // Før binær søgning skal listen være sorteret efter navn
                    SortingAlgos.QuickSort(students, 0, students.Count - 1);

                    Console.Write("Indtast fulde navn for at søge: ");
                    string fullNameBinary = Console.ReadLine();
                    var resultBinary = SearchAlgorithms.BinarySearch(students, fullNameBinary);
                    if (resultBinary != null)
                    {
                        Console.WriteLine($"Studerende fundet: {resultBinary.FullName} - Gruppe {resultBinary.GroupNumber}");
                    }
                    else
                    {
                        Console.WriteLine("Studerende ikke fundet.");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
