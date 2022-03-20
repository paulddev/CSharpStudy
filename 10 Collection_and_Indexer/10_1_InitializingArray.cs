using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * 배열을 초기화하는 방법 3가지!
 */

namespace _10_1_InitializingArray
{
    class Program
    {
        static void Main()
        {
            string[] array1 = new string[3] { "안녕", "hello", "hi" }; // 읽기 편하다.
            string[] array2 = new string[] { "안녕", "hello", "hi" };
            string[] array3 = { "안녕", "hello", "hi" };
        }
    }
}
