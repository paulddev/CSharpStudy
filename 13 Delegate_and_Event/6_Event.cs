using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Event
 * 외부에서 직접 사용할 수 없다. (이벤트 기반 프로그래밍)
 * 
 * 대리자는 대리자로 콜백용도로 사용하고,
 * 이벤트는 이벤트대로 객체의 상태 변화나 사건의 발생을 알리는 용도로 구분해서 사용한다.
 * 
 * 추가로 이벤트는 +=, -= 만 가능한데,
 * 그 이유는 중간에 = 로 인해 기존에 등록해둔 대리자들이 사라지는 경우가 발생할 수 있기 때문이다.
 * 따라서 기존에 등록된 핸들러들을 맘대로 초기화할 수 없도록 되어 있다.
 */

namespace _6_Event
{
    delegate void EventHandler(string message);

    class MyNotifier
    {
        public event EventHandler SomethingHappend;
        public void DoSomething(int num)
        {
            int temp = num % 10;

            if (temp != 0 && temp % 3 == 0)
            {
                // SomethingHappend의 이름으로 참조된 대리자를 호출하게 된다.
                SomethingHappend(String.Format("{0} : 짝", num));
            }
        }
    }

    class Program
    {
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }
        static void Main()
        {
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappend += new EventHandler(MyHandler); // 대리자 인스턴스에 어떤 인수를 넣을지

            for(int i = 1; i < 30; i++)
            {
                notifier.DoSomething(i);
            }
        }
    }
}
