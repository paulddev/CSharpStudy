using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_AnonymousMethod
{
    // 대리자에 익명의 메소드도 참조할 수 있다.
    delegate int Compare(int a, int b);

    class Program
    {
        static void BubbleSort(int[] DataSet, Compare Comparer)
        {
            for(int i = 0; i < DataSet.Length - 1; i++)
            {
                for(int j = 0; j < DataSet.Length - 1 - i; j++)
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        int temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }

        static void Main()
        {
            int[] array = { 3, 7, 4, 2, 10 };

            // 익명 메소드
            BubbleSort(array, delegate (int a, int b)
            {
                if (a > b) return 1;
                else if (a == b) return 0;
                else return -1;
            });

            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");
        }
    }
}
