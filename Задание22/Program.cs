using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание22
{
    internal class Program
    {
        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();   
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 10);
            }
            return array;
        }
        static int Sum(Task<int[]> task)
        {
            int[] array = task.Result;
            int S = 0;
            for (int i = 0; i < array.Count(); i++)
            {
                S += array[i];
                Console.WriteLine(S);
            }
            return S;
        }
        static int Max(Task<int[]> task)
        {
            int[] array = task.Result;
            int max = array[0];
            for (int i = 0; i < array.Count(); i++)
            {
                foreach (int a in array)
                {
                    if (a > max)
                        max = a;
                    Console.WriteLine(max);
                }
            }
            return max;
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);

            Func<Task<int[]>, int> func2 = new Func<Task<int[]>, int>(Sum);
            Task<int> task2 = task1.ContinueWith<int>(func2);

            Func<Task<int[]>, int> func3 = new Func<Task<int[]>, int>(Max);
            Task<int> task3 = task1.ContinueWith<int>(func3);

            task1.Start();

            Console.ReadKey();
        }
    }
}
