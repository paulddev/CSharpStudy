using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 객체 복사하기 : 얕은 복사와 깊은 복사 (중요!)
 * 
 * 참조 형식은 힙 영역에 객체를 할당하고 스택에 있는 참조가 힙 영역에 할당된 메모리를 가리킨다.
 * 
 * 객체를 복사할 때 참조만 살짝 복사하는 것을 얕은 복사(Shallow Copy)라고 한다.
 * 그런데, 별도의 힙 공간에 객체를 보관하기를 원한다면 깊은 복사(Deep Copy)를 해야 한다.
 * 
 * C#에서는 자동으로 해주는 구문이 없다.
 * 스스로 깊은 복사를 수행하는 코드를 만들어야 한다....
 * => 보통 ICloneable.Clone()을 이용해서 구현한다.
 */

namespace ConsoleApp4.Class_7
{
    class MyClass
    {
        public int myField1;
        public int myField2;

        public MyClass DeepCopy()
        {
            MyClass newCopy = new MyClass();
            newCopy.myField1 = this.myField1;
            newCopy.myField2 = this.myField2;

            return newCopy;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Shallow Copy");

            {
                MyClass source = new MyClass();
                source.myField1 = 10;
                source.myField2 = 20;

                MyClass target = source;
                target.myField2 = 100;

                Console.WriteLine($"{source.myField1} {source.myField2}");
                Console.WriteLine($"{target.myField1} {target.myField2}");
            }

            Console.WriteLine("\nDeep Copy");

            {
                MyClass source = new MyClass();
                source.myField1 = 10;
                source.myField2 = 20;
                
                // 서로 독립된 공간을 가리킨다.
                MyClass target = source.DeepCopy();
                target.myField2 = 100;

                Console.WriteLine($"{source.myField1} {source.myField2}");
                Console.WriteLine($"{target.myField1} {target.myField2}");
            }
        }
    }
}
