# Generic

## Generic Class
```C#
class Point<T>
{
    private T x;
    private T y;
    public Point(T x = default(T), T y = default(T))
    {
        this.x = x;
        this.y = y;
    }
}
class Program
{
    static void Main()
    {
        Point<int> pt = new Point<int>(1, 1);
        Point<double> pt2 = new Point<double>(1.1, 2.2);
        // 보통은 컬렉션에서 제너릭을 많이 쓴다.
        LinkedList<int> s = new LinkedList<int>();
    }
}
```
## Generic Method
- 타입을 명시적으로 전달할 때 : f<int>(3)
- 타입을 생략하는 경우 : f(3)
```C#
class Program
{
    public static T f1<T>(T a) => a;
    public static void f2<T>(T a, T b)
    {
        Type t = a.GetType();
        Console.WriteLine(t.FullName);

        Type t2 = typeof(T);
        Console.WriteLine(t2.FullName);
    }
    static void Main()
    {
        Console.WriteLine(f1<int>(3));
        Console.WriteLine(f1<double>(3.14));
        Console.WriteLine(f1(10));
        f2(3.14, 10);            // System.Double
        //f2("hello", 10);       // error
        f2<object>("hello", 10); // System.String(Object로 받지만 실제로 a의 실제 타입을 리턴)
                                 // T 타입을 알고 싶으면, typeof(T)로 직접 확인한다.
    }
}
```
## Generic Constraint
- where T : class (Reference type) class 는 꼭 앞쪽에 적어야함.
- where T : struct (Value type)
- where T : new() (Default Constructor 가 존재해야 함)
- where T : 인터페이스 (해당 인터페이스를 구현한 타입만 가능)
- where T : 클래스 이름 (특정 클래스로부터 파생된 타입만 가능)
```C#
class Program
{
    public static T Max<T>(T a, T b) where T : IComparable
    {
        return a.CompareTo(b) < 0 ? b : a;
    }
    static void Main()
    {
        Console.WriteLine(Max(10, 20));
        Console.WriteLine(Max("A", "B"));
    }
}
```
