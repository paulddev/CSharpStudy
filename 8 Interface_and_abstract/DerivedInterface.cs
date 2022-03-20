using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 인터페이스를 상속하는 인터페이스
 * 
 * 기존의 인터페이스에 새로운 기능을 추가한 인터페이스를 만들고 싶을 때
 * 해당 인터페이스를 상속하는 인터페이스를 만들면 된다.
 * 
 * 이렇게 하는 이유 2가지
 * 1. 상속하려는 인터페이스가 소스 코드가 아닌 어셈블리로만 제공되는 경우 ex) .NET SDK 인터페이스
 * 2. 상속하려는 인터페이스의 소스 코드를 갖고 있어도 이미 인터페이스를 상속하는 클래스들이 존재하는 경우
 * => 기존의 소스 코드에 영향을 주지 않고, 새로운 기능을 추가하기 위해서는 인터페이스를 상속하는 인터페이스를 이용하는 편이 좋다.
 */

namespace DerivedInterface
{
    interface ILogger
    {
        void WriteLog(string message);
    }

    interface IFormattableLogger : ILogger
    {
        void WriteLog(string format, params object[] args);
    }

    class ConsoleLogger2 : IFormattableLogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }

        public void WriteLog(string format, params object[] args)
        {
            // 지정된 문자열의 형식 항목을 지정된 배열에 있는 해당 개체의 문자열 표현으로 바꾸는 기능
            string message = string.Format(format, args);
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }
    }

    class Program
    {
        static void Main()
        {
            IFormattableLogger logger = new ConsoleLogger2();
            logger.WriteLog("The world is not flat.");
            logger.WriteLog("{0} + {1} = {2}", 1, 1, 2);
        }
    }
}
