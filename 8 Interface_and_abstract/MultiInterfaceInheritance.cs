using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 여러 개의 인터페이스, 한꺼번에 상속하기
 * 
 * 클래스는 여러 클래스를 한꺼번에 상속할 수 없다.
 * => 죽음의 다이아몬드 문제
 * 
 * 죽음의 다이아몬드 문제란?
 * 최초의 클래스가 두 개의 파생 클래스로부터 상속받고, 이 두 개의 파생 클래스를 다시 하나의 클래스가 상속하는 것
 * 1. 문제의 핵심은 모호성이다.
 * 
 * 2. 또 업캐스팅 문제가 있다.
 * Plane plane = new MyVehicle();
 * Car     car = new MyVehicle();
 * 
 * 같은 Ride() 에서 Run 인지 fly 인지 모호하다.
 * 다중 상속은 이러한 재앙을 불러올 위험성이 있기 때문에 C#은 다중 상속을 허용하지 않는다.
 * 
 * 인터페이스의 다중 상속은 가능하다.
 * 인터페이스는 내용이 아닌 외형을 물려주기 때문, 겉모습 만큼은 정확하게 자신을 닮기를 강제한다.
 * 따라서 죽음의 다이어몬드 문제가 발생하지 않는다.
 * 
 * 여러 클래스로투버 구현을 물려받고 싶다고 할때
 * '포함'이라는 기법을 이용하자.
 * 
 * MyVehicle()
 * {
 *    Car car = new Car();
 *    Plane plane = new Plane();
 *    
 *    public void Fly() {plane.Ride();}
 *    public void Run() {car.Ride();}
 * }
 */

namespace MultiInterfaceInheritance
{
    interface IRunnable
    {
        void Run();
    }

    interface IFlyable
    {
        void Fly();
    }

    class FlyingCar : IRunnable, IFlyable
    {
        public void Run()
        {
            Console.WriteLine("Run!!");
        }

        public void Fly()
        {
            Console.WriteLine("Fly!!");
        }
    }

    class Program
    {
        static void Main()
        {
            FlyingCar car = new FlyingCar();
            car.Run();
            car.Fly();

            IRunnable runnable = car as IRunnable;
            runnable.Run();

            IFlyable flyable = car as IFlyable;
            flyable.Fly();
        }
    }
}
