# 매개변수 전달방식
`ref` or `out`이 없는 경우 : 복사본 생성 (원본 변수에 접근 할 수 없다.) <br>
`ref` : 원본 변수를 `Read/Write` 모두 가능. `초기화된` 변수만 전달할 수 있다. <br>
`out` : 원본 변수에 `Write`만 가능. `초기화 되지 않은` 변수를 전달할 수 있고, 메소드에서 `2개 이상의 결과를 반환`받고 싶을 때 주로 사용한다.

## ref (value type일 때)
Large Size 의 struct type 을 넘길 때 유용하다.
```C#
class Program
{
    public static void func1(ref int m) // ref int m = ref n
    {
        // m -> n의 주소를 가리킨다.
        m++;
    }
    static void Main()
    {
        int n = 10;
        Console.WriteLine(n);
        func1(ref n);
        Console.WriteLine(n);
    }
}
```

## out (value type일 때)
```C#
class Program
{
    public static void func(out int r1, out int r2)
    {
        r1 = 1 + 2;
        r2 = 2 + 3;
    }
    static void Main()
    {
        int r1;
        int r2;
        // 초기화 되지 않은 변수를 출력하면 error
        func(out r1, out r2);
        Console.WriteLine($"{r1}, {r2}");
    }
}
```

## reference type 일 때 (주의!)
기본적으로 참조를 전달할 때는 넘긴 인자가 수정이 반영된다. <br>
그렇지만 `ref` 를 붙이면 말이 달라지게 된다.

`핵심`
- 참조 타입을 `값`으로 전달하면 객체의 상태를 변경할 수 있지만, 새로운 객체를 담아 올 수 는 없다.
- 참조 타입을 `ref`로 전달하면 객체의 상태를 변경할 수 있고, 새로운 객체도 담아 올 수 있게 된다.

`참조 타입을 값으로 전달할 때`
- ![image](https://user-images.githubusercontent.com/31722512/160436128-b3f348d6-8fe7-41a9-a386-57bdaa7fa6d3.png)
- ![image](https://user-images.githubusercontent.com/31722512/160436226-5c80f236-ad21-4eab-a0f4-c15511a384dc.png)

`참조 타입을 ref로 전달할 때`
- ![image](https://user-images.githubusercontent.com/31722512/160435372-a8f2595f-9883-4298-8b9d-e4f35e74e4ed.png)
- ![image](https://user-images.githubusercontent.com/31722512/160435523-1b9070e8-1c25-42ed-b9b9-3b6c9544f651.png)

```C#
class Point
{
    public int x = 0;
    public int y = 0;
    public Point(int a, int b) { x = a; y = b; }
}

class Program
{
    public static void f1(Point p)
    {
        p.x = 2;
    }
    public static void f2(ref Point p)
    {
        p.x = 2;
        Console.WriteLine($"{p.x}, {p.y}"); // 2, 1
        p = new Point(5, 5);
    }
    static void Main()
    {
        Point p1 = new Point(1, 1);
        Console.WriteLine($"{p1.x}, {p1.y}"); // 1, 1
        f2(ref p1);
        Console.WriteLine($"{p1.x}, {p1.y}"); // 5, 5
    }
}
```



