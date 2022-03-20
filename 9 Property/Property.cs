using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 프로퍼티
 * 은닉성을 표현하는 방법
 * 
 * 프로퍼티 선언 문법에서는 get {}, set {} 은 접근자라고 한다.
 * get 접근자는 필드로부터 값을 읽어오고(Read)
 * set 접근자는 필드에 값을 할당한다(Write)
 * 
 * set 접근자를 구현하지 않으면, 해당 프로퍼티는 읽기 전용 프로퍼티가 된다.
 */

namespace Property
{
    class BirthdayInfo
    {
        private string name;
        private DateTime date;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }

    class Program
    {
        static void Main()
        {
            BirthdayInfo birth = new BirthdayInfo();
            birth.Name = "do";
            birth.Date = new DateTime(1995, 2, 8);

            Console.WriteLine(birth.Name);
            Console.WriteLine(birth.Date);
        }
    }
}
