using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmer
{
    public class SortingAlgos
    {

        //Bubble Sort
        public static void bubbleSort(List<Student> list)
        {
            int n = list.Count;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++) // Start fra 1 i stedet for 0
                {
                    if (string.Compare(list[i - 1].FullName, list[i].FullName) > 0)
                    {
                        //Swap
                        Student temp = list[i - 1];
                        list[i - 1] = list[i];
                        list[i] = temp;
                        swapped = true;
                    }
                }
                n--;
            } while (swapped);
        }




        //Selection Sort
        public static void SelectionSort(List<Student> list)
        {
            int n = list.Count;
            for (int i = 0; i < n - 1; i++) { 
            int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (list[j].GroupNumber < list[minIndex].GroupNumber)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    //Swap
                    Student temp = list[minIndex];
                    list[minIndex] = list[i];
                    list[i] = temp;
                  
                }
            }                                    
        }

        //Quick Sort
        public static void QuickSort(List<Student> list, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(list, left, right);
                QuickSort(list, left, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, right);
            }
        }

        private static int Partition(List<Student> list, int left, int right)
        {
            Student pivotValue = list[right];
            int pivotIndex = left;

            for (int i = left; i <= right; i++) // Ændring her
            {
                if (string.Compare(list[i].FullName, pivotValue.FullName) < 0)
                {
                    Student temp = list[i];
                    list[i] = list[pivotIndex];
                    list[pivotIndex] = temp;
                    pivotIndex++;
                }
            }

            Student temp2 = list[pivotIndex];
            list[pivotIndex] = list[right];
            list[right] = temp2;

            return pivotIndex;
        }




    }
}
