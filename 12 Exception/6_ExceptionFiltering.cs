using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_ExceptionFiltering
{
    class FilterableException : Exception
    {
        public int ErrorNo { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter Number Between 0~10");
            string input = Console.ReadLine();
            try
            {
                int num = Int32.Parse(input);

                if (num < 0 || num > 10)
                    throw new FilterableException() { ErrorNo = num };
                else
                    Console.WriteLine($"Output : {num}");
            }
            // 예외 필터가 가능하다. (when 키워드를 이용해서 구현한다)
            catch(FilterableException e) when (e.ErrorNo < 0)
            {
                Console.WriteLine("Negative input is not allowed.");
            }
            catch(FilterableException e) when (e.ErrorNo > 10)
            {
                Console.WriteLine("Too big number is not allowed.");
            }
        }
    }
}
