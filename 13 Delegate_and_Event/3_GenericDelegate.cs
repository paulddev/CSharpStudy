using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_GenericDelegate
{
    // 일반화 버전의 대리자 방법
    delegate int Compare<T>(T a, T b);

    class Program
    {
        // IComparable 인터페이스에는
        // CompareTo 메소드가 있다.
        static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            // 자신보다 크면 -1,
            // 자신과 같으면 0,
            // 자신보다 작으면 1 (이때 바꿔줘야 오름차순)
            return a.CompareTo(b);
        }

        static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            // -1을 곱하면,
            // 자신보다 큰 경우 1,
            // 같으면 0,
            // 자신보다 작은 경우 -1
            return a.CompareTo(b) * -1;
        }

        static void BubbleSort<T>(T[] DataSet, Compare<T> Comparer)
        {
            for (int i = 0; i < DataSet.Length - 1; i++)
            {
                for (int j = 0; j < DataSet.Length - 1 - i; j++)
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        T temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }

        static void Main()
        {
            int[] array = { 3, 7, 4, 2, 10 };

            BubbleSort<int>(array, new Compare<int>(AscendCompare));
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");
            Console.WriteLine();

            BubbleSort<int>(array, new Compare<int>(DescendCompare));
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");
            Console.WriteLine();
        }
    }
}
