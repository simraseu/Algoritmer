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

            Console.WriteLine("Vælg sortering:");
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
                    // Sorter efter Group Number (Selection Sort)
                    SortingAlgos.SelectionSort(students);
                    break;
                case 2:
                    // Vælg sorteringsmetode for navne
                    Console.WriteLine("Vælg sorteringsmetode for navne:");
                    Console.WriteLine("1. Bubble Sort");
                    Console.WriteLine("2. Quick Sort");
                    Console.Write("Indtast dit valg: ");

                    int nameSortingChoice;
                    while (!int.TryParse(Console.ReadLine(), out nameSortingChoice) || nameSortingChoice < 1 || nameSortingChoice > 2)
                    {
                        Console.WriteLine("Ugyldigt valg. Prøv igen.");
                    }

                    if (nameSortingChoice == 1)
                    {
                        // Sorter efter Navn (Bubble Sort)
                        SortingAlgos.bubbleSort(students);
                    }
                    else
                    {
                        // Sorter efter Navn (Quick Sort)
                        SortingAlgos.QuickSort(students, 0, students.Count - 1);
                    }
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
    }
}
