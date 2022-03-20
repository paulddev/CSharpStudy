using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 읽기 전용 필드
 * 
 * 변수는 변하는 데이터를 담지만, 상수는 변하지 않는 데이터를 담는다.
 * 상수는 프로그램이 실행되기 전부터 이미 정해졌다. 그리고 프로그램 실행 중에는 절대 그 값을 바꿀 수 없다.
 * 이에 반해 변수는 자유롭게 값을 변경할 수 있다.
 * 
 * 읽기 전용 필드는 상수와 변수 그 중간 어딘가에 있다.
 * 
 * 읽기 전용 필드는 읽기만 가능한 필드이며,
 * 클래스나 구조체의 멤버로만 존재할 수 있고 생성자 안에서 한 번 값을 지정하면, 그 후로는 값을 변경할 수 없는 것이 특징이다.
 * readonly 키워드를 이용해 사용할 수 있다.
 * 
 * 핵심은 읽기 전용 필드는 생성자 안에서만 초기화가 가능하다.
 */

namespace ConsoleApp4.Class_7
{
    class Configuration
    {
        private readonly int min;
        private readonly int max;

        public Configuration(int a, int b)
        {
            // 읽기 전용 필드는 생성자 안에서만 초기화 가능하다. => 유연하다
            // 또는 변수 이니셜라이저에서는 가능하다.
            // Class a = new Class { ID = "Admin", PW = "1234" }; 객체 이니셜라이저 예시(생성자가 없어도 멤버변수 초기화가 가능하다)
            // int[] a = new int[3] {100, 200, 300}; 배열의 이니셜라이저
            // List<int> list = new List<int>() {100, 200, 300}; 제너릭 컬렉션의 이니셜라이저
            min = a;
            max = b;
        }

        public void ChangeMax(int newMax)
        {
            //생성자가 아닌 다른 곳에서 값을 수정하려고 하면 컴파일 에러를 발생시킨다.
            //max = newMax;
        }
    }

    class Program
    {
        static void Main()
        {
            Configuration c = new Configuration(100, 10);
        }
    }
}
