using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 대리자를 쓰는 이유 : 입맛에 맞게 인수를 다르게 넣으면 다르게 동작하는 함수를 만들 수 있다.
namespace _2_UsingCallback
{
    delegate int Compare(int a, int b);

    class Program
    {
        static int AscendCompare(int a, int b)
        {
            if (a > b) return 1; // 변경하고자 하는 것을 위에 적자.
            else if (a == b) return 0;
            else return -1;
        }
        static int DescendCompare(int a, int b)
        {
            if (a < b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        static void BubbleSort(int[] DataSet, Compare Comparer)
        {
            int i = 0;
            int j = 0;
            int temp = 0;

            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = 0; j < DataSet.Length - 1 - i; j++)
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }

        static void Main()
        {
            int[] array = { 3, 7, 4, 2, 10 };

            BubbleSort(array, new Compare(AscendCompare));
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();

            BubbleSort(array, new Compare(DescendCompare));
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
    }
}
