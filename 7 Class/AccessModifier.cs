using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 접근 한정자로 공개 수준 결정하다.
 * 
 * 쉽게 생각해서 내가 선풍기를 사용하는데 내부의 기능까지 알 필요없이 강,중,약,회전,On,Off 기능만 알면 된다.
 * 더 알면 머리 아프다..
 * 
 * 그래서 필요한 최소의 기능만 노출하고, 내부를 감추는 것을 은닉성(Encapsulation)이라고 한다.
 * 
 * 객체지향 프로그래밍에는 3대 특성이 있는데
 * 1. 은닉성(Encapsulation)
 * 2. 상속성(Inheritance)
 * 3. 다형성(Polymorphism)
 * 
 * 다양한 접근 한정자를 살펴보자.
 * public : 클래스의 외부/내부 모두 접근 가능
 * protected : 클래스의 외부에서는 접근할 수 없지만, 자신과 파생 클래스에서 접근이 가능
 * private : 클래스의 내부에서만 접근 가능, 파생 클래스도 접근 불가능
 * 
 * internal : 같은 어셈블리에 있는 코드에서만 public으로 접근 가능, 다만 다른 어셈블리에 있는 코드는 private와 같은 수준의 접근성을 가진다.
 * protected internal : 같은 어셈블리에 있는 코드에서만 protected으로 접근 가능, 다만 다른 어셈블리에 있는 코드는 private와 같은 수준의 접근성을 가진다.
 * private internal : 같은 어셈블리에 있는 코드에서만 private으로 접근 가능, 다만 다른 어셈블리에 있는 코드는 privaste와 같은 수준의 접근성을 가진다.
 * 
 * 디폴트는??
 * 접근 한정자를 수식하지 않은 클래스의 멤버는 모두 private로 접근 수준이 자동으로 설정된다.
 */

namespace ConsoleApp4.Class_7
{
    class WaterHeater
    {
        protected int temperature;

        public void SetTemperature(int temperature)
        {
            if (temperature < -5 || temperature > 42)
            {
                throw new Exception("Out of temperature range");
            }

            this.temperature = temperature;
        }

        internal void TurnOnWater()
        {
            Console.WriteLine($"Turn on water : {temperature}");
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                WaterHeater heater = new WaterHeater();
                heater.SetTemperature(20);
                heater.TurnOnWater();

                heater.SetTemperature(-2);
                heater.TurnOnWater();

                heater.SetTemperature(50); // 예외 발생, 69행은 실행되지 않고, catch 블록으로 이동하게 된다.
                heater.TurnOnWater();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
