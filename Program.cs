using System;
using System.IO;

namespace TestTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] InputArray = ReadFromFile("input.txt");
            Console.Write("Массив до сортировки: ");
            PrintArray(InputArray);

            int[] SortedArray = QuickSort(InputArray, 0, InputArray.Length - 1);

            Console.Write("\nВызов метода QuickSort()...\n\n");
            Console.Write("Массив после сортировки: ");
            PrintArray(SortedArray);

            /* 
             * Иной способ вывода массива в консоль: 
             * foreach (var element in Array)
             *    Console.Write($"{element} ")
            */

            Console.ForegroundColor = ConsoleColor.Black;
        }

        static int[] ReadFromFile(string Path)
        {
            int[] Arr;
            using (var sr = new StreamReader(Path))
            {
                string[] Values = sr.ReadLine().Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                Arr = new int[Values.Length];

                for (int i = 0; i < Values.Length; i++)
                    Arr[i] = int.Parse(Values[i]);
            }
            return Arr;
        }

        static void PrintArray(int[] Array)
        {
            var OldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(string.Join(", ", Array));

            Console.ForegroundColor = OldColor;
        }

        static int[] QuickSort(int[] Array, int MinIndex, int MaxIndex)
        {
            if (MinIndex >= MaxIndex)
                return Array;

            int Pivot = GetPivotIndex(Array, MinIndex, MaxIndex); // Выбор базового элемента (последний элемент массива)

            QuickSort(Array, 0, Pivot - 1); // Сортировка слева от pivot
            QuickSort(Array, Pivot + 1, MaxIndex); // Сортировка справа от pivot

            return Array;
        }

        static int GetPivotIndex(int[] Array, int MinIndex, int MaxIndex)
        {
            int pivot = MinIndex - 1;

            for (int _ = MinIndex; _ <= MaxIndex; _++)
            {
                if (Array[_] < Array[MaxIndex])
                {
                    pivot++;
                    Swap(ref Array[pivot], ref Array[_]);
                }
            }

            pivot++;
            Swap(ref Array[pivot], ref Array[MaxIndex]);

            return pivot;
        }

        static void Swap(ref int LeftIndex, ref int RightIndex)
            => (LeftIndex, RightIndex) = (RightIndex, LeftIndex);
    }
}