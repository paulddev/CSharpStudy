using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_BasicAttribute
{
    class MyClass
    {
        // 컴파일러에게 이 메소드를 사용하지 말라고 경고 메시지를 내보내도록 할 수 있다.
        // 보통 개발자들은 ReadMe를 안 읽고 바로 코딩에 들어가기 때문에!
        [Obsolete("OldMethod는 폐기되었습니다. NewMethod()를 사용하세여!")]
        public void OldMethod()
        {
            Console.WriteLine("old");
        }

        public void NewMethod()
        {
            Console.WriteLine("new!!");
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass obj = new MyClass();
            obj.OldMethod();
            obj.NewMethod();
        }
    }
}
