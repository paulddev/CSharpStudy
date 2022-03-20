using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 오버라이딩과 다형성 (핵중요)
 * 
 * 객체지향 프로그래밍에서 다형성(Polymorphism)은 객체가 여러 형태를 가질 수 있음을 의미한다.
 * 자신으로부터 상속받아 만들어진 파생 클래스를 통해 다형성을 실현한다.
 * 
 * 메소드를 오버라이딩 하기 위해서는 오버라이딩을 할 메소드가 virtual 키워드로 한정되어 있어야 한다.
 * 오버라이딩 하는 측에서는 기반 클래스에 선언되어 있던 메소드를 재정의하고 있음을 컴파일러에 알려야 하므로, override 키워드로 한정해줘야 한다.
 * 
 * private으로 선언한 메소드는 오버라이딩이 불가능하다.
 */

namespace ConsoleApp4.Class_7
{
    class ArmorSuite
    {
        public virtual void Initialize()
        {
            Console.WriteLine("Armored");
        }
    }

    class IronMan : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            Console.WriteLine("Repulsor Rays Armed");
        }
    }

    class WarMachine : ArmorSuite
    {
        public override void Initialize()
        {
            //base.Initialize(); 너프
            Console.WriteLine("Double-Barrel Cannons Armed");
            Console.WriteLine("Micro-Rocket Launcher Armed");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Creating ArmorSuite...");
            ArmorSuite armorSuite = new ArmorSuite();
            armorSuite.Initialize();

            Console.WriteLine("\nCreating IronMan");
            ArmorSuite ironMan = new IronMan();
            ironMan.Initialize();

            Console.WriteLine("\nCreating WarMachine");
            ArmorSuite warmachine = new WarMachine();
            warmachine.Initialize();
        }
    }
}
