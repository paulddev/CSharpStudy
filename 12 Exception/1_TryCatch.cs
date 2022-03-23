using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_TryCatch
{
    class Program
    {
        static void Main()
        {
            int[] arr = { 1, 2, 3 };
            try
            {
                for(int i = 0; i < 5; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("종료");
        }
    }
}
