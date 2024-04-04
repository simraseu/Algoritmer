using System.Collections.Generic;

namespace Algoritmer
{
    public class SearchAlgorithms
    {
        // Lineær søgealgoritme
        public static Student LinearSearch(List<Student> students, string fullName)
        {
            foreach (var student in students)
            {
                if (student.FullName == fullName)
                {
                    return student;
                }
            }
            return null; // Returnerer null, hvis studerende ikke findes
        }

        // Binær søgealgoritme
        public static Student BinarySearch(List<Student> students, string fullName)
        {
            int start = 0;
            int end = students.Count - 1;

            while (start <= end)
            {
                int middle = (start + end) / 2;

                if (students[middle].FullName == fullName)
                {
                    return students[middle];
                }
                else if (string.Compare(students[middle].FullName, fullName) < 0)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            return null; // Returnerer null, hvis studerende ikke findes
        }
    }
}
