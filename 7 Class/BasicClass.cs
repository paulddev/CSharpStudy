using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Class
 * 속성은 데이터, 기능은 메소드
 * 
 * 클래스가 자동차 설계도라면, 객체는 자동차
 * 
 * 클래스는 복합 데이터 형식이다.
 * 클래스는 다른 말로 청사진이라고도 한다. 실체(인스턴스)가 아니다.
 */

namespace ConsoleApp4.Class_7
{
    class Cat
    {
        // 클래스 내에 선언된 요소들을 일컬어 멤버member라고도 한다.

        // 필드 (클래스 안에 선언된 변수들을 일컬어 필드라고 한다.)
        public string Name;
        public string Color;
        
        // 메소드
        public void Meow()
        {
            Console.WriteLine($"{Name} : 야옹");
        }
    }

    class Program
    {
        static void Main()
        {
            Cat kitty = new Cat();
            kitty.Name = "DoDo";
            kitty.Color = "White";

            kitty.Meow();
            Console.WriteLine($"{kitty.Name}, {kitty.Color}");
        }
    }
}
