using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 꽤 중요한 부분! (집중하자.)
 * 
 * 객체의 삶과 죽음에 대한 부분이다. 생성자와 소멸자
 * 
 * 객체가 생성될 때 생성자가 호출되고, 소멸할 때는 종료자(Finalizer)가 호출된다.
 * 핵심은 종료자다.
 * 
 * 명시적으로 생성자를 구현하지 않더라도 컴파일러가 알아서 디폴트 생성자를 자동으로 만들어주지만,
 * 만약에 사용자가 생성자를 정의했더라면 디폴트 생성자는 자동으로 만들어지지 않는다.
 * 
 * 생성자 또한 메소드처럼 오버로딩이 가능하다. (다양한 타입을 만들 수 있다)
 * 
 * 종료자(소멸자)의 경우는 오버로딩이 불가능하며, 직접 호출할 수 도 없다.
 * CLR의 가비지 컬렉터가 객체가 소멸하는 시점을 판단해서 종료자를 호출해준다.
 * 
 * 다만 CLR의 가비지 컬렉터가 언제 동작할지 예측할 수 없다.
 * GC는 일정 양의 쓰레기가 모여야만 동작하기 때문이다. 따라서 정확하게 호출되는 시기를 알 수 없다.
 * 
 * 가비지 컬렉터는 클래스의 족보를 타고 올라가 객체로부터 상속받은 Finalize() 메소드를 호출하게 되는데
 * 이렇게 하면 응용 프로그램의 성능 저하를 초래할 확률이 높아 권장하지 않는다. 그래서 따로 인터페이스를 상속하여 처리하는 방법도 있다.
 * => Dispose 패턴을 구현하는 방법(IDisposable 인터페이스를 상속받아 구현한다)
 * 
 * 1. 모든 비관리 리소스를 정리
 * 2. 모든 관리 리소스를 정리
 * 3. 객체가 이미 정리되었음을 나타내기 위한 상태 플래그 설정
 * 4. finalizer 호출 회피. 이를 위해 GC.SuppressFinalize(this) 호출
 * 관리, 비관리 모두 제거하려면 Dispose(true), 관리만 제거할려면 Dispose(false)
 * 
 * CLR의 가비지 컬렉터는 똑똑하기 때문에 객체의 소멸을 알아서 처리한다.
 * 그래서 생성은 생성자에서, 뒷처리는 가비지 컬렉터에게 맡기는 편이 좋다.
 * 
 * 뒷처리를 GC가 처리하기 때문에 프로그램의 결과가 매번 다를 수 있다.
 */

namespace ConsoleApp4.Class_7
{
    class Cat
    {
        public Cat()
        {
            Name = "";
            Color = "";
            Console.WriteLine("Cat() 호출");
        }

        public Cat(string _name, string _color)
        {
            this.Name = _name;
            this.Color = _color;
            Console.WriteLine("Cat(string, string) 호출");
        }

        public string Name;
        public string Color;

        ~Cat()
        {
            Console.WriteLine("소멸자 호출");
        }

        public void Meow()
        {
            Console.WriteLine("야옹");
        }
    }

    class Program
    {
        static void Main()
        {
            Cat kitty = new Cat("키티", "하얀색");
            kitty.Meow();
            Console.WriteLine($"{kitty.Name} : {kitty.Color}");
        }
    }
}
