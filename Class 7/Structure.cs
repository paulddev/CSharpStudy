using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 구조체
 * C#의 복합 데이터 형식에는 클래스 말고도 구조체가 있다.
 * 
 * struct 키워드를 사용해서 선언한다.
 * struct 구조체이름
 * {
 *    // 필드
 *    // 메소드
 * }
 * 
 * 클래스는 실세계의 객체를 추상화하려는데 그 존재의 이유
 * 구조체는 데이터를 담기 위한 자료구조로 이용
 * 
 * 은닉성을 비롯한 객체지향의 원칙을 구조체에 강하게 적용하지 않는 편이며,
 * 편의를 위해 필드를 public으로 선언해서 사용하는 경우가 많다.
 * 
 * 특징       클래스                        구조체
 * 키워드     class                         struct
 * 형식       참조 형식(힙 할당)             값 형식(스택에 할당)
 * 복사       얕은 복사(Shallow Copy)        깊은 복사(Deep Copy)
 * 인스턴스   new 연산자와 생성자 필요        선언만으로도 생성이 된다.(new 도 가능)
 * 생성자     매개변수 없는 생성자 선언 가능   매개변수 없는 생성자 선언 불가능
 * 상속       가능                           값 형식이므로 상속 불가능
 * 
 * 핵심은 구조체의 인스턴스는 스택에 할당되고, 인스턴스가 선언된 블록이 끝나는 지점의 메모리에서 사라진다.
 * 인스턴스의 사용이 끝나면 즉시 메모리에서 제거된다는 점과 가비지 콜렉터를 덜 귀찮게 한다는 점에서
 * 구조체는 클래스에 비해 성능의 이점을 가지게 된다.
 * 
 * 구조체는 값 형식이기 때문에 할당 연산자(=)를 통해 모든 필드가 그대로 복사된다.
 * 
 * 구조체는 생성자를 호출할 때가 아니면 굳이 new 연산자를 사용하지 않아도 인스턴스를 만들 수 있다.
 * 구조체는 매개변수가 없는 생성자를 생성할 수 없지만, 구조체의 각 필드는 CLR이 기본값으로 초기화를 해준다.
 */

namespace Structure
{
    struct Point3D
    {
        public int x;
        public int y;
        public int z;

        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // System.Object 형식의 ToString() 메소드를 오버라이딩
        public override string ToString()
        {
            return String.Format($"{x}, {y}, {z}");
        }
    }

    class Program
    {
        static void Main()
        {
            // 선언만으로도 인스턴스가 생성된다.
            Point3D p3d1;
            p3d1.x = 10;
            p3d1.y = 20;
            p3d1.z = 30;

            Console.WriteLine(p3d1.ToString());

            Point3D p3d2 = new Point3D(100, 200, 300);
            Point3D p3d3 = p3d2; // 깊은 복사
            p3d3.z = 400;

            Console.WriteLine(p3d2.ToString());
            Console.WriteLine(p3d3.ToString());
        }
    }
}
