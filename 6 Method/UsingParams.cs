using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 가변 개수의 인수 - 개수가 유연하게 변할 수 있는 인수
 * 
 * params 키워드와 배열을 이용해서 선언한다.
 * 
 * 매개변수의 개수가 유한하게 정해져 있다면 가변 개수의 인수보다는 메소드 오버로딩을 사용하는 것이 적절하다.
 * 가변 개수의 인수는 형식은 같으나 인수의 개수만 유연하게 달라질 수 있는 경우에 적합하다.
 */

namespace ConsoleApp4.Method_6
{
    internal class UsingParams
    {
        static int Sum(params int[] args)
        {
            Console.WriteLine("Summing...");

            int sum = 0;

            for(int i = 0; i < args.Length; i++)
            {
                if (i > 0)
                    Console.Write(", ");

                Console.Write(args[i]);

                sum += args[i];
            }
            Console.WriteLine();

            return sum;
        }

        static void Main()
        {
            int sum = Sum(3, 4, 5, 6, 7, 8, 9, 10);
            Console.WriteLine(sum);

            int sum2 = Sum(new int[] { 1, 2, 3, 4, 5 });
            Console.WriteLine(sum2);

            int[] arr = { 2, 4, 6, 8, 10 };
            int sum3 = Sum(arr);
            Console.WriteLine(sum3);
        }
    }
}
