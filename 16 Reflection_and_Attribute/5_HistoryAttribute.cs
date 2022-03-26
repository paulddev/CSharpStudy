using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 애트리뷰트도 역시 하나의 클래스
 * 
 * 애트리뷰트는 Obsolete 말고도 종류가 많다.
 * C, C++로 작성된 네이티브 DLL(Dynamic Link Library)에 있는 함수를 호출할 때 사용하는 [DLLImport]
 * 조건부 메소드 실행을 지정할 때 사용하는 [Conditional]
 * 
 * 즉, 애트리뷰트는 코드에 대한 부가 정보를 기록하고 읽을 수 있는 기능
 * 주석이 사람이 쓰고 사람이 읽는다면
 * 애트리뷰트는 사람이 쓰고 컴퓨터가 읽는다.
 * 
 * 직접 애트리뷰트를 작성할 수 있다
 * System.Attribute 를 상속하면 된다.
 */

namespace _5_HistoryAttribute
{
    // AllowMultiple -> History 애트리뷰트를 여러 번 사용할 수 있도록 한다.
    // 원래는 애트리뷰트를 추가하고 싶어도 더 추가가 불가능하다.
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    class History : System.Attribute
    {
        private string programmer;
        public double version;
        public string changes;

        public History(string programmer)
        {
            this.programmer = programmer;
            version = 1.0;
            changes = "first release";
        }

        public string GetProgrammer()
        {
            return programmer;
        }

        [History("Paul", version  = 0.1, changes = "2022-03-26 Created class stub")]
        [History("Devb", version = 0.2, changes = "2022-03-27 Added Func() Method")]
        class MyClass
        {
            public void Func()
            {
                Console.WriteLine("추가된 새로운 메서드");
            }
        }

        class Program
        {
            static void Main()
            {
                Type type = typeof(MyClass);
                Attribute[] attributes = Attribute.GetCustomAttributes(type);

                Console.WriteLine("MyClass change history...");

                foreach(Attribute a in attributes)
                {
                    History h = a as History;
                    if (h != null)
                    {
                        Console.WriteLine("Ver:{0}, Programmer:{1}, Changes:{2}", h.version, h.GetProgrammer(), h.changes);
                    }
                }
            }
        }
    }
}
