using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Finally
{
    class Program
    {
        static int Divide(int dividend, int divisor)
        {
            try
            {
                Console.WriteLine("Divide() start");
                return dividend / divisor;
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Divide() 예외 발생");
                throw e;
            }
            // 예외가 일어나든 일어나지 않든 반드시 finally 절의 코드를 실행하기 때문에
            // 뒷마무리를 우아하게 실행할 수 있다. (파일닫기 등등 마무리 코드는 이쪽에)
            finally
            {
                Console.WriteLine("Divide() 끝");
            }
        }

        static void Main()
        {
            try
            {
                Console.Write("제수를 입력하세요. : ");
                string temp = Console.ReadLine();
                int dividend = Convert.ToInt32(temp);

                Console.Write("피제수를 입력하세요. : ");
                temp = Console.ReadLine();
                int divisor = Convert.ToInt32(temp);

                Console.WriteLine("{0}/{1} = {2}", dividend, divisor, Divide(dividend, divisor));
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("프로그램을 종료합니다.");
            }
        }
    }
}
