using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_ThrowExpression
{
    class Program
    {
        static void Main()
        {
            try
            {
                int? a = null;
                // 조건 연산자를 응용한 방법 (a가 null이면 우측 사용)
                int b = a ?? throw new ArgumentNullException();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                int[] array = new[] { 1, 2, 3 };
                int index = 4;
                int value = array[index >= 0 && index < 3 ? index : throw new IndexOutOfRangeException()];
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
