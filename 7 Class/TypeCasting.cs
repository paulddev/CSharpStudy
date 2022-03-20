using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * 기반 클래스와 파생 클래스 사이의 형식 변환, is와 as
 * 
 * is : 객체가 해당 형식에 해당하는지 검사하여 그 결과를 bool 값으로 반환한다.
 * as : 형식 변환 연산자와 같은 역할을 한다. 
 *      다만 변환에 실패하는 경우 형식 변환 연산자는 예외를 던지는 반면에 as 연산자는 객체 참조를 null로 만든다는 것이 다르다.
 * 
 * 단, as 연산자는 참조 형식에 대해서만 사용이 가능하며, 값 형식의 객체는 기존의 형식 변환 연산자를 사용해야 한다.
 */

namespace ConsoleApp4.Class_7
{
    class Mammal // 포유류
    {
        public void Nurse()
        {
            Console.WriteLine("Nurse()");
        }
    }

    class Dog : Mammal
    {
        public void Bark()
        {
            Console.WriteLine("Bark()");
        }
    }

    class Cat : Mammal
    {
        public void Meow()
        {
            Console.WriteLine("Meow()");
        }
    }

    class Program
    {
        static void Main()
        {
            Mammal mammal = new Dog();
            Dog dog;

            if (mammal is Dog)
            {
                dog = (Dog)mammal;
                dog.Bark();
            }

            Mammal mammal2 = new Cat();

            Cat cat = mammal2 as Cat;
            if (cat != null)
            {
                cat.Meow();
            }
            else
            {
                Console.WriteLine("cat2 is not a Cat");
            }

            // 위와 같은 뜻
            cat?.Meow();

            cat = null;
            // 뒤에가 실행되지 않는다.
            // null 조건부 연산자 : 객체의 멤버에 접근하기 전에 객체가 null인지 검사하여 그 결과가 참이면 null을 리턴하고,
            // 그렇지 않은 경우에는 .뒤에 지정된 멤버를 반환한다.
            cat?.Meow();
        }
    }
}
