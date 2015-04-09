using System;

namespace DelegateSample
{
    public class Program
    {
        public delegate bool ComparisonHandler(int first, int second);

        public static void BubbleSort(int[] items, ComparisonHandler comparisonMethod)
        {
            int i, j, temp;

            if (comparisonMethod == null)
            {
                throw new ArgumentNullException("comparisonMethod");
            }

            if (items == null)
            {
                return;
            }

            for (i = items.Length - 1; i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    if (comparisonMethod(items[j - 1], items[j]))
                    {
                        temp = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }

        public static bool GreaterThan(int first, int second)
        {
            return first > second;
        }

        private static void Main(string[] args)
        {
            var items = new int[5];

            for (int i = 0; i < items.Length; i++)
            {
                // UNDONE 检测输入
                items[i] = int.Parse(Console.ReadLine());
            }

            BubbleSort(items, (first, second) => first < second);

            Console.WriteLine("The result is: ");
            foreach (int item in items)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}