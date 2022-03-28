# 메소드의 특징들

## params
1. 메소드의 인자 개수를 가변 길이로 하는 방법
- 배열을 사용해서 전달
- 가변길이 매개 변수(variable length parameter) 사용
```C#
class Program
{
    public static int Sum(int a, int b) => a + b;
    public static int Sum(params int[] arr)
    {
        int result = 0;
        foreach (int n in arr)
            result += n;
        return result;
    }
    static void Main()
    {
        int s1 = Sum(1, 2);
        int s2 = Sum(new int[] { 1, 2, 3 });
        int s3 = Sum(1, 2, 3, 4, 5); // param이면 이렇게 편하게 넘길 수 있다.
        Console.WriteLine(s1);
        Console.WriteLine(s2);
        Console.WriteLine(s3);
    }
}
```
2. `서로 다른 타입 여러 개를 인자로 받고 싶다면`
- object 타입으로 받는다.

3. `params`는 반드시 마지막 인자에만 사용할 수 있다.
4. 성능의 문제 => 배열을 힙에 생성하게 되므로 성능 저하가 있다. 또 박싱/언박싱 문제도 있다.
5. 그래서 자주 사용하는 버전의 메소드는 별도로 제공하는 것이 좋다. ex) Console.WriteLine 클래스
```C#
class Program
{
    public static void f1(params object[] arr)
    {
        foreach(object o in arr)
            Console.WriteLine(o.ToString());
    }
    public static int Sum(int a, int b) => a + b;
    public static int Sum(int a, int b, int c) => a + b + c;
    public static int Sum(int a, int b, int c, int d) => a + b + c + d;
    public static int Sum(params int[] arr)
    {
        int result = 0;
        foreach (int n in arr)
            result += n;
        return result;
    }
    static void Main()
    {
        f1(1, 3.4, "Hi");

        int s1 = Sum(1, 2);
        int s2 = Sum(1, 2, 3);
        int s3 = Sum(1, 2, 3, 4);
        int s4 = Sum(1, 2, 3, 4, 5); // -> new int[]{1,2,3,4,5} 와 같다. (배열을 힙에 생성하게 되므로 성능 저하 발생)
    }
}
```
## Named Parameter (명명된 매개 변수)
- 메소드에 인자 전달 시 `인자 이름`을 사용하는 방법
- 코딩의 양이 증가하지만 `가독성`을 높일 수 있음
- 인자의 순서를 변경할 수 도 있음
```C#
class Program
{
    public static void SetRect(int x, int y, int width, int height)
    {
        Console.WriteLine($"{x}, {y}, {width}, {height}");
    }
    static void Main()
    {
        SetRect(10, 20, 30, 40);
        SetRect(x: 10, y: 20, width: 30, height: 40);
        SetRect(x: 10, width: 30, y: 30, height: 40);
    }
}
```
## Optional Parameter (선택적 매개 변수) = 디폴트 매개 변수
- 메소드의 `매개 변수에 기본값을 지정`하는 문법
- C++ 에서는 이것을 `default parameter`라고 함
- `마지막 인자부터 차례대로 지정`해야 한다.
- `컴파일 시간`에 알 수 있는 상수만 초기값으로 사용할 수 있다.
```C#
class Program
{
    public static void f(int x = 0, int y = 0, int z = 0)
    {
        Console.WriteLine($"{x}, {y}, {z}");
    }
    //public static void f1(DateTime dt = DateTime.Now) { } error
    public static void f2(DateTime dt = default(DateTime)) { }
    static void Main()
    {
        f(1, 2, 3);     // 1, 2, 3
        f(1, 2);        // 1, 2, 0
        f(1);           // 1, 0, 0
        f();            // 0, 0, 0
        f(y: 5, z: 10); // 0, 5, 10
    }
}
```
## extension method (확장 메소드)
`식 본문 메소드 (expression - bodied method)
- 메소드의 구현이 단순한 경우 블록을 생략하고 `=>` 뒤에 반환 값을 표기
- 식 본문 속성 (expression - boided property) 도 가능하다.
```C#
public static int Square(int a) => a * a; // 식 본문 메소드(expression - bodied method)
```

`확장 메소드 (extension method)`
- 기존 클래스를 수정하지 않고 `새로운 메소드를 추가하는 문법`
- `static class` 의 `static method` 로 제공
- 기존 코드를 수정하지 않고 새로운 기능을 추가할 수 있다.
- `Linq`가 extension method 를 사용해서 기능을 제공한다.
```C#
class Car
{
    public void Go() { Console.WriteLine("Go"); }
}

static class CarExtension
{
    public static void Stop(this Car c)
    {
        Console.WriteLine("Stop");
    }

    public static void Func(this Car c, int gas)
    {
        Console.WriteLine($"gas : {gas}");
    }
}
class Program
{
    public static int Square(int a) => a * a; // 식 본문 메소드(expression - bodied method)
    static void Main()
    {
        Car c = new Car();
        c.Go();
        c.Stop(); // 확장 해서 사용
        c.Func(100);
    }
}
```

