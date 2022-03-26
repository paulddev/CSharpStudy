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


