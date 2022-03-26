# Null 과 Casting 요약본

## Nullable<T>
`Reference type`
- `null`을 사용하면 객체 없음 상태를 표현할 수 있다.

`value type`
- `null`을 표현할 방법이 없다.
  
`Nullable<T>`
- `value type`에 `null`을 추가한 것
- Nullable<int> = int + bool
- null 을 사용할 수 있게 되었다.

```c#
Nullable<int> n1 = 10;
Nullable<int> n2 = null;

int? => Nullable<int>의 단축 표기법
  
int? n = 10;
int? = int (대입 연산자 가능)
int = int? (불가능)
```
  
## ?. ?? 연산자(헷갈리는 것 중 하나)
`Elvis operator (?. ?[)`
- 널 조건부 연산자(null conditional operator)
- elvis operator(?가 elvis를 닮았다 해서 붙여진 이름)
- `좌변이 null 인 경우 좌변은 수행하지 않고 null 반환`

```C#
class Car 
{
    public int Color { get; set; } = 10;
    public void Go() { Console.WriteLine("GO"); }
}
class Program
{
    public static Car CreateCar(int speed)
    {
        if (speed > 200) return null;

        return new Car();
    }

    public static void Main()
    {
        Car c = CreateCar(100);

        //if(c != null)
        //{
        //    c.Go();
        //}
        c?.Go();

        // c가 null 이면 죽게 되기 때문에
        // 널 조건부 연산자를 사용해서 처리한다.
        int? n = c?.Color;

        // 배열의 참조 타입도 마찬가지
        // 배열 자체도 null일 수 있기 때문에
        // 널 조건부 연산자를 사용해서 처리한다.
        int[] arr = null;
        int? n2 = arr?[0];
    }
}
```
  
`널 접합 연산자`
- null coalescing operator
- 좌변이 null 인 경우 우변 값 반환

```C#
class Program
{
    public static Car CreateCar(int speed)
    {
        if (speed > 200) return null;

        return new Car();
    }

    public static void Main()
    {
        // 좌변이 null 인 경우 우변 값 반환
        Car c = CreateCar(100) ?? new Car();

        // 응용
        int? n1 = 10;
        int n2 = n1 ?? 100;
    }
}
```
  
## Casting  
```C#
class Program
{
    public static void Main()
    {
        int n = 3;
        double d = 3.5;

        d = n; // int -> double 데이터 손실 없음
        n = (int)d; // double -> int 데이터 손실 발생 (반드시 명시적 캐스팅이 필요함)
    }
}
```

`is` 연산자
- 참조 변수가 가리키는 실제 타입을 조사할 때 사용한다.
- `is`는 캐스팅이 아니고 조사하는 연산자
  
`as` 캐스팅 2가지 방법
- `Dog d = (Dog)obj;` 실패시 예외 발생
- `Dog d = obj as Dog;` 실패시 null 반환

```C#
class Animal { }
class Dog : Animal
{
    public void Cry() { Console.WriteLine("Dog Cry"); }
}
class Program
{
    public static void foo(Animal a)
    {
        //a.Cry();

        // 1번 해결책
        // Animal 참조 타입을 Dog 참조타입으로 캐스팅 => 다운 캐스팅
        //Dog d = (Dog)a;
        //d.Cry();

        // 2번 해결책
        if (a is Dog) // a가 가리키고 있는 객체가 실제로 Dog라면?
        {
            Dog d = (Dog)a;
            d.Cry();
        }

        // 2번 다른 해결책
        // a를 Dog로 캐스팅하는데 혹시 Dog가 아니라면 null 을 반환
        // Dog d2 = (Dog)a; // 실패시 예외 -> try - catch로 예외 처리(그러나 비용이 만만치않음..)
        Dog d2 = a as Dog;  // 실패시 null 반환
        if (null != d2)
        {
            d2.Cry();
        }
    }
    public static void Main()
    {
        foo(new Dog());    // 1
        foo(new Animal()); // 2
  
        // 주의
        int? n = obj as int; // 값 타입의 경우 nullable을 이용해서 받자.
    }
}
```

## 변환 연산자
신기한 문법
  
```C#
class Point
{
    int x;
    int y;
    public Point(int x, int y) { this.x = x; this.y = y; }

    public override string ToString()
    {
        return String.Format($"{x}, {y}");
    }

    // Point 인자로 받아서 int로 꺼내주겠다는 뜻
    // explicit : 명시적으로 선언해야된다.
    public static explicit operator int(Point pt)
    {
        return pt.x;
    }

    public static explicit operator Point(int pt)
    {
        return new Point(pt, pt);
    }
}
class Program
{
    static void Main()
    {
        double d = 3.4;
        int n = (int)d;

        Point pt = new Point(1, 2);
        int n2 = (int)pt; // Point => int
        Console.WriteLine(n2);

        Point pt2 = (Point)n2; // int => Point
        Console.WriteLine(pt2); // pt2.ToString()

        //Point pt3 = n2 as Point; // as 연산자 사용시 변환연산자가 호출되지 않는다.
    }
}
```
