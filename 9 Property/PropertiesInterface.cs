using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 인터페이스와 프로퍼티
 * 
 * 인터페이스는 메소드뿐만 아니라 프로퍼티와 인덱서도 가질 수 있다.
 * 프로퍼티나 인덱서를 가진 인터페이스를 상속하는 클래스는 반드시 해당 프로퍼티와 인덱서를 구현해야한다.
 * 
 * 인터페이스에 들어가는 프로퍼티는 구현을 갖지 않는다.
 * 주의할 점이 있는데 자동 구현 프로퍼티처럼 구현이 없지만, C#컴파일러는 인터페이스의 프로퍼티에 대해서는 자동으로 구현해주지 않는다.
 * 상속 받은 클래스에서는 자동 구현 프로퍼티를 지원한다. 이점을 명시하자.
 */

namespace PropertiesInterface
{
    interface INameValue
    {
        string Name { get; set; }
        string Value { get; set; }
    }

    class NamedValue : INameValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    class Program
    {
        static void Main()
        {
            NamedValue name = new NamedValue() { Name = "이름", Value = "Do" };
            NamedValue height = new NamedValue() { Name = "키", Value = "175cm" };

            Console.WriteLine(name.Name + ' ' + name.Value);
            Console.WriteLine(height.Name + ' ' + height.Value);
        }
    }
}
