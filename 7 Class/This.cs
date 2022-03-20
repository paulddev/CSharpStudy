using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * This 키워드
 * 
 * this 는 객체가 자신을 지칭할 때 사용하는 키워드다.
 * this 는 모호성을 제거할 수 있다.
 */

namespace ConsoleApp4.Class_7
{
    class Employee
    {
        private string Name;
        private string Position;

        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetPosition(string Position)
        {
            this.Position = Position;
        }

        public string GetPosition()
        {
            return Position;
        }
    }

    class Program
    {
        static void Main()
        {
            Employee poo = new Employee();
            poo.SetName("나 푸야");
            poo.SetPosition("프로그래머");
            Console.WriteLine($"{poo.GetName()}, 나의 직업은 {poo.GetPosition()}");
        }
    }
}
