using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 자동 구현 프로퍼티
 * 
 * 프로퍼티는 데이터의 오염에 대해선 메소드처럼 안전하고, 데이터를 다룰 때는 필드처럼 간결하다.
 * 하지만, 많은 경우에 중복된 코드를 작성하고 있다는 기분이 든다.
 * 
 * C# 3.0부터는 get;set;을 지원한다.
 * 필드 선언 필요없이 get접근자와 set접근자 뒤에 세미콜론만 붙여주면 된다.
 * 
 * C# 7.0부터는 자동 구현 프로퍼티를 선언함과 동시에 초기화를 수행할 수 있다.
 * public string name { get; set; } = "name";
 * 
 * 덕분에 자동 구현 프로퍼티에 초깃값이 필요할 때 생성자에 초기화 코드를 작성하는 수고를 덜 수 있다.
 * 
 * 중요한 것은 자동 구현 프로퍼티 뒤에서 일어나는 일이다.
 * 
 * C# 컴파일러가 보이지 않는 곳에서 자동 구현 프로퍼티를 위해 하는 일들이 있다.
 * public string Name { get; set; } 이렇게 선언해도
 * 뒤에서는 아래와 같은 작업을 한다
 * 
 * private string name;
 * public string Name
 * {
 *  get { return name; }
 *  set { name = value; }
 * }
 * 
 * 자동 구현 프로퍼티를 사용했을 때는 C# 컴파일러가 자동으로 구현해준다.
 * <string>k_BackingField 라는 private 필드가 따로 생기고,
 * get_Name(), set_Name()라는 메서드도 생긴다.
 */

namespace AutoImplementedProperty
{
    class Box
    {
        public string name { get; set; } = "Box";
        public int size { get; set; } = 10;
    }

    class Program
    {
        static void Main()
        {
            Box box = new Box();
            Console.WriteLine($"{box.name}, {box.size}");

            box.name = "Big box";
            box.size = 100;
            Console.WriteLine($"{box.name}, {box.size}");
        }
    }
}
