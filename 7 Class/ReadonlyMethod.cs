using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 읽기 전용 메소드 역시 구조체에서만 선언할 수 있다.
 * 주의할 점은 메소드에서 객체의 필드를 바꾸려 들면 컴파일 에러를 발생시킨다.
 */

namespace ConsoleApp4.Class_7
{
    struct ACSetting
    {
        public double currentInCelsius; // 현재 온도
        public double target;

        public readonly double GetFahrenheit()
        {
            //target = currentInCelsius * 1.8 + 32;
            return currentInCelsius * 1.8 + 32;
        }
    }

    class Program
    {
        static void Main()
        {
            ACSetting acs;
            acs.currentInCelsius = 25;
            acs.target = 25;

            Console.WriteLine($"{acs.GetFahrenheit()}");
        }
    }
}
