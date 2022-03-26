# 박싱과 언박싱에 대해서 알아보자.

## Boxing, UnBoxing
기본적으로 박싱과 언박싱에 대해서 아는 내용은 다음과 같다.
```C#
class Program
{
    static void Main()
    {
        int[] a1 = { 1, 2, 3 };
        object o1 = a1;
        a1[0] = 10;
        int[] a2 = (int[])o1;
        /*
         * a1, o1, a2 모두 a1이 만든 힙 영역을 가리키게 된다.
         * 참조 변수가 무려 3개
         */
        Console.WriteLine(a2[0]); // 10

        int n1 = 1;
        object o2 = n1;
        /*
         * Heap에 복사본을 만들고,
         * 그 다음 o2 참조 변수가 만들어진 영역을 가리킨다.
         * 이러한 방법을 Boxing
         */
        n1 = 10;
        int n2 = (int)o2;
        /*
         * Heap에 있는 영역이 Stack 영역으로 내려와서 객체가 되는 것
         * 이러한 방법을 UnBoxing
         */
        Console.WriteLine($"{n1}, {n2}");
    }
}
```

## 객체의 크기를 비교하는 방법
`관계 연산자(<,>)` : 수치 관련 타입 <br>
`CompareTo()` : 크기 비교가 가능한 대부분의 타입을 지원한다.

```C#
class Program
{
    static void Main()
    {
        Console.WriteLine(10 < 20);          // true
        Console.WriteLine(10.CompareTo(20)); // -1
        Console.WriteLine(10.CompareTo(10)); // 0
        Console.WriteLine(10.CompareTo(5));  // 1

        string s1 = "AAA";
        string s2 = "BBB";
        //Console.WriteLine(s1 < s2); // error
        Console.WriteLine(s1.CompareTo(s2)); // -1 (s1이 s2보다 앞에 있기 때문에)
    }
}
```

`A.CompareTo(B)`
- A > B : 0보다 큰 값
- A == B : 0
- A < B : 0보다 작은 값

`IComparable 인터페이스`
- `CompareTo` 메소드에 대한 규칙을 담은 인터페이스
- 크기 비교가 가능한 타입은 `IComparable` 인터페이스를 구현해야 한다.
- C# 은 대부분의 메소드의 규칙을 인터페이스로 제공하고 있다.

`IComparable` vs `IComparable<T>`
- `IComparable`
  * C# 1.0 인터페이스
  * 메소드 인자로 object 를 사용
  * Boxing/Unboxing 이 발생 => 성능 이슈

- `IComparable<T>`
  * C# 2.0 인터페이스 (C# 3.0 에서는 람다식 등장)
  * Generic 사용
  * Boxing/Unboxing 이 발생하지 않는다.

권장은 `IComparable` 과 `IComparable<T>` 인터페이스 모두 구현하는 것이 좋다. <br>
서로 대응이 가능하기 때문에 또, 박싱/언박싱을 막을 수 있다.

```C#
struct Point : IComparable<Point>, IComparable
{
    int x;
    int y;
    public Point(int x, int y) { this.x = x; this.y = y; }
    public int CompareTo(Point pt)
    {
        if (x > pt.x) return 1;
        else if (x == pt.x) return 0;
        return -1;
    }
    public int CompareTo(object obj)
    {
        Point pt = (Point)obj; //
        if (x > pt.x) return 1;
        else if (x == pt.x) return 0;
        else return -1;
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(1, 1);
        Point p2 = new Point(2, 2);
        // p2 인자가 Point 일 때 -> IComparable<Point>
        Console.WriteLine(p1.CompareTo(p2));

        // p2 인자가 object 일 때 -> IComparable
        Object obj = new Point(3, 3);
        Console.WriteLine(p1.CompareTo(obj));
    }
}
```

## Equals
`Equals` : object, `IEquatable<T>`
- object 클래스가 제공
- 모든 타입에 존재

`CompareTo()` : IComparable, `IComparable<T>`
- IComparable or `IComparable<T>` 인터페이스를 구현한 타입에만 존재

권장 : `Equals()` 제공할 때, object 메소드만 재정의하지 말고, IEquatable<T> 인터페이스도 구현하는 것이 좋다. <br>
이유 : 박싱/언박싱 해결
```C#
struct Point : IEquatable<Point>
{
    int x;
    int y;
    public Point(int x, int y) { this.x = x; this.y = y; }

    public bool Equals(Point pt) // 인터페이스에 있는거라 override x
    {
        Console.WriteLine("Point");
        return pt.x == x && pt.y == y;
    }
    public override bool Equals(object obj) // 가상함수라 override
    {
        Console.WriteLine("object");
        Point pt = (Point)obj;
        return pt.x == x && pt.y == y;
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(1, 1);
        Point p2 = new Point(1, 1);

        Console.WriteLine(p1.Equals(p2));

        object p3 = new Point(1, 1);
        Console.WriteLine(p1.Equals(p3));
    }
}  
```
