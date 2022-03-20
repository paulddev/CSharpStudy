using System;

/*
 * 인터페이스의 기본 구현 메소드
 * 
 * Legacy(유산) - 레거시 코드는 업그레이드에 각별한 주의가 필요하다.
 * 
 * 기본 구현 메소드는 이런 상황에서 요긴하게 사용가능하다.
 * 인터페이스에 새로운 메소드를 추가할 때 기본적인 구현체를 갖도록 해서 기존에 있는 파생 클래스에서의
 * 컴파일 에러를 막을 수 있게 한다.
 * 
 * 인터페이스의 기본 구현 메소드는 인터페이스 참조로 업캐스팅했을 때만 사용할 수 있다는 점 때문에
 * 프로그래머가 파생 클래스에서 인터페이스에 추가된 메소드를 엉뚱하게 호출할 가능성도 없다.
 * 
 * C# 8.0부터 인터페이스에 선언된 멤버에 대한 구현을 정의할 수 있습니다. 
 */

namespace DefaultImplementation
{
    interface ILogger
    {
        void WriteLog(string message);

        void WriteError(string error) // 새로운 메소드 추가
        {
            //WriteError() 에 기본 구현을 제공한다.
            WriteLog(error);
        }
    }

    public interface IControl
    {
        void Paint()
        {
            Console.WriteLine("Default Paint method");
        }
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
        }
    }

    class Program
    {
        static void Main()
        {
            ILogger logger = new ConsoleLogger();
            logger.WriteLog("System Up");
            logger.WriteError("System Fail");

            ConsoleLogger clogger = new ConsoleLogger();
            clogger.WriteLog("System Up");
            //clogger.WriteError("System Fail"); // 컴파일 에러
        }
    }
}
