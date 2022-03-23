using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_DelegateChains
{
    // 대리자 하나에 여러 개의 메소드를 동시에 참조할 수 있다. => 체이닝 기법
    delegate void Notify(string message);

    class Notifier
    {
        public Notify EventOccured;
    }

    class EventListener
    {
        private string name;
        public EventListener(string name)
        {
            this.name = name;
        }

        public void SomethingHappend(string message)
        {
            Console.WriteLine($"{name}.SomethingHappend : {message}");
        }
    }

    class Program
    {
        static void Main()
        {
            Notifier notifier = new Notifier();
            EventListener listener1 = new EventListener("Listener1");
            EventListener listener2 = new EventListener("Listener2");
            EventListener listener3 = new EventListener("Listener3");

            // += 연산자를 이용해서 Chain 만들고, 호출하기
            notifier.EventOccured += listener1.SomethingHappend;
            notifier.EventOccured += listener2.SomethingHappend;
            notifier.EventOccured += listener3.SomethingHappend;
            notifier.EventOccured("You've got mail");
            Console.WriteLine();

            notifier.EventOccured -= listener2.SomethingHappend;
            notifier.EventOccured("Download Complete");
            Console.WriteLine();

            // +, = 연산자를 이용한 체인 만들기
            notifier.EventOccured = new Notify(listener2.SomethingHappend)
                                  + new Notify(listener3.SomethingHappend);
            notifier.EventOccured("Nuclear");
            Console.WriteLine();

            // 기본적으로 대리자에 인스턴스를 생성하고 인수를 넣을 수 있다.
            Notify notify1 = new Notify(listener1.SomethingHappend);
            Notify notify2 = new Notify(listener2.SomethingHappend);

            notifier.EventOccured = (Notify)Delegate.Combine(notify1, notify2);
            notifier.EventOccured("Fire!");
            Console.WriteLine();

            notifier.EventOccured = (Notify)Delegate.Remove(notifier.EventOccured, notify2);
            notifier.EventOccured("Remove");
            Console.WriteLine();
        }
    }
}
