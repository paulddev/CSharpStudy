using System;
using System.IO;

/*
 * 인터페이스, 키워드 : interface
 * 
 * 메소드, 이벤트, 인덱서, 프로퍼티만 가질 수 있다.
 * 구현부가 없다.
 * 모든 것이 public
 * 
 * 인터페이스는 인스턴스를 가질 수 없지만, 이 인터페이스를 상속받는 클래스의 인스턴스를 만드는 것은 가능하다.
 * 파생 클래스는 인터페이스에 선언된 모든 메소드 및 프로퍼티를 구현해줘야 하며, 메소드들을 public 한정자로 수식해야 한다.
 * 
 * 인터페이스는 인스턴스를 못 만들지만, 참조는 만들 수 있다.
 * 
 * 인터페이스 작명법은 대게 앞에 I를 붙인다.
 * 
 * 인터페이스는 약속이다. 맛에 따라 결정할 수 있어야 한다.
 * 
 */

namespace Interface
{
    interface ILogger
    {
        void WriteLog(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }
    }

    class FileLogger : ILogger
    {
        private StreamWriter writer;

        public FileLogger(string path)
        {
            writer = File.CreateText(path);
            writer.AutoFlush = true;
        }

        public void WriteLog(string message)
        {
            writer.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }
    }

    class ClimateMonitor
    {
        private ILogger logger;
        // 어떤 로거를 장착할지(사용할지) 결정
        public ClimateMonitor(ILogger logger)
        {
            this.logger = logger;
        }

        public void start()
        {
            while(true)
            {
                Console.Write("온도를 입력해주세요: ");
                string temperature = Console.ReadLine();
                if (temperature.Length == 0)
                {
                    break;
                }

                // 로거에 메시지를  이렇게 전달해주세요.
                logger.WriteLog("현제 온도 : " + temperature);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // bin/Debug/MyLog.txt 확인할 수 있다.
            ClimateMonitor monitor = new ClimateMonitor(new FileLogger("MyLog.txt"));
            monitor.start();
        }
    }
}
