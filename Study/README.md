# C#에서 놓칠 수 있는 것들을 정리하는 곳

## C# 클래스 기본 문법 정리
1. 접근 지정자는 모든 멤버에 `개별적`으로 표기한다.
2. 상속은 `:` 연산자를 사용한다.
3. 객체 생성시에는 `()`가 있어야 한다. Java도 비슷함. (C++은 디폴트 생성자할 때 없어도 된다.)
4. 기반 클래스에 있는 멤버와 동일한 이름의 필드 또는 메소드를 만들 때에는 `new` 를 표기 (C#의 특수한 문법)

## 메소드 종류
`Java` : 모든 메소드(멤버 함수)가 가상 메소드 <br>
`C++`  : 가상함수도 있고 가상이 아닌 함수도 있다. <br>
```cpp
void Func() {}
virtual void Func() {}
```
`C#`   : 가상 메소드도 있고, 가상이 아닌 함수도 있다. <br>
가상이 아닌 메소드를 재정의 할 때는 컴파일러 경고를 제거하려면 `new`를 사용하면 된다.

```c#
class Base
{
  public virtual void Func() {}
}

class Derived : Base
{
  public override void Func() {}
  public new void Func() {}
}

override : 가상 메소드 재정의
Base b = new Derived();
b.Func(); // Derived() 호출

new : 새로운 메소드 Func() 만든 걸 호출
Base b = new Derived();
b.Func(); // Base Func() 호출 why? Func() 을 재정의한게 아니기 때문에 b는 Base에서 가리키는 것이므로 Base 쪽에서 호출하게 된다.
```

## 인터페이스
1. 일관된 형태의 라이브러리를 만들기 위해 "클래스들이 사용하는 메소드의 이름을 약속할 때
2. 클래스를 만드는 사람과 사용하는 사람 사이의 규칙(메소드 이름, 시그니쳐)를 정의하는 것
3. C# 핵심
  - 다양한 인터페이스를 먼저 설계하고
  - 대부분의 클래스는 특정 인터페이스를 구현하는 방식으로 메소드를 제공
  - 대부분의 Collection 클래스는 `ICollection` 인터페이스를 구현한다. => List에는 Clear() 메소드가 있다는 의미

- Interface 선언
  * 메소드 앞에 public 등의 접근 지정자를 표기하지 않는다.
  * C# 8.0부터는 가능.
  * 메소드 구현시 `override` 표기하지 않는다.
  * 다만 `virtual`은 가능하다. (이렇게 하면 가상 메소드로 만든것, 파생 클래스에서 영향을 받을 수 있다.)

## Type
1. 초기화 되지 않은 변수는 사용할 수 없다!
2. var (C++ auto)와 같다.

C# 에서 `모든 것은 객체`다. => 10, 3.4, "AA" 모두 `객체` (멤버를 가지고 있음)

C#의 타입과 .net framework 
- `int`    | `System.Int32`
- `double`  | `System.Double`
- `char`    | `System.Character`
- `string`  | `System.String`
- `object`  | `System.Object`

## System.Object
핵심 : 모든 타입은 `System.Object`로부터 파생된다.
```C#
class Program : System.Object(보이지 않는 것일뿐)
```
C# 언어의 모든 타입은 `공통의 특징(System.Object 가 제공하는)`을 가지고 있다.
```C#
2개의 static Method
3개의 virtual Method
1개의 non-virtual instance method
1개의 protected instance method

public class Object
{
  public Object();
  ~Object();
  
  public static bool Equals(Object objA, Object objB);
  public static bool ReferenceEquals(Object objA, Object objB);
  public virtual bool Equals(Object obj);
  public virtual int GetHashCode();
  public Type GetType();
  public virtual string ToString();
  protected Object MemberwiseClone();
}
```

`ToString()`
- 객체를 문자열로 변경하는 메소드
- System.Object 기본 구현 : `객체의 타입 이름을 문자열로 반환`
- 일반적으로 객체의 상태를 나타내도록 재정의한다.

## Value Type vs Reference Type
1. 메모리 구조와 객체의 위치
```cpp
struct Point
{
  int x = 1;
  int y = 1;
}

int main()
{
  Point pt1;
  Point pt2 = pt1; // 깊은 복사 (객체 자체가 2개)
  
  Point* p1 = new Point; // 얕은 복사 (객체 자체는 1개인데 그걸 가리키는 포인터가 2개)
  Point* p2 = p1;
  
  delete p1;
}

크기가 작은 객체는 스택에 보통 만들고, 크기가 큰 객체는 힙에 만든다.
```
### struct vs class
`struct` : 객체가 스택에 생성된다 (Value type) <br>
`class`  : 객체가 힙에 생성된다 (Reference type) <br>
```c#
struct SPoint
{
    public int x;
    public int y;
    public SPoint(int x, int y) { this.x = x; this.y = y; }
}

class CPoint
{
    public int x;
    public int y;
    public CPoint(int x, int y) { this.x = x; this.y = y; }
}

class Program
{
    static void Main()
    {
        SPoint sPoint = new SPoint(1, 1); // 스택 영역에 sPoint 객체가 만들어진다.
        CPoint cPoint = new CPoint(1, 1); // 힙 영역에 메모리를 할당하고 (1,1)을 넣고 cPoint 참조 변수가 해당 영역을 가리킨다.

        SPoint sPoint2 = sPoint; // 깊은 복사 (객체가 2개가 된다. sPoint와 sPoint2) => 객체 자체를 복사
        CPoint cPoint2 = cPoint; // 얕은 복사 (객체는 1개고 cPoint2 참조 변수는 cPoint가 가리키는 곳을 가리키게 된다.) => 주소 복사(참조 복사)
    }
}
```

`arr(System.Array)` : 배열은 `참조`타입이다. <br>
`string(System.String)` : 문자열은 `참조`타입이다. <br>

- `불변 객체(immutable, 상태를 변경할 수 없는)` (한 번 만들게 되면 그걸 수정할 수 없다.)
- 그래서 `s1 = "world"` 의 의미는 `s1 = new String("world");` 가 된다.
- value type : `struct(int, double)`, `enum(모든 수치 관련 타입)`
- reference type : `class(object, string, array)`, `interface(.net framework)`, `delegate(클래스 라이브러리들)`
- `string` 와 `String` 은 같은 의미다.

## Type 을 조사하는 방법
```C#
class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3 };
        Type t = arr.GetType();
        Console.WriteLine(t.IsValueType); // False

        int n = 1;
        t = n.GetType();
        Console.WriteLine(t.IsValueType); // True
    }
}
```

## Equality (자주 실수하는 부분)
- 객체의 동등성을 조사할 때 사용
  * `==`연산자 사용
  * `Equals()` 가상 메소드 사용

`참조 타입의 Equality` 를 살펴보자.
- `==` 연산자
  * 참조(주소)가 동일한가?
  * 연산자 재정의 문법으로 기본 동작 변경이 가능하고, 기반 클래스 타입의 참조를 사용할 경우 문제가 발생.
- `Equals()` 연산자
  * 참조(주소)가 동일한가?
  * 재정의하면 `객체의 상태 동일 여부`로 구현하는 경우가 많다. (두 객체의 정보가 모두 같은지?)
```C#
class Point
{
    int x = 0;
    int y = 0;
    public Point(int x, int y) { this.x = x; this.y = y; }

    public override bool Equals(object obj) // 사용자가 재정의해서 바꿀 수 있다.
    {
        Point pt = (Point)obj; // 먼저 캐스팅해주고,

        return pt.x == x && pt.y == y;
    }

    // == 역시 연산자 재정의를 사용해서 바꿀 수 있다.
    // 단, static으로 만들고 == 를 만들면 반드시 != 도 같이 재정의해줘야 한다.
    public static bool operator==(Point p1, Point p2)
    {
        return p1.x == p2.x && p1.y == p2.y;
    }

    public static bool operator!=(Point p1, Point p2)
    {
        return !(p1 == p2);
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(1, 1);
        Point p2 = p1;
        Point p3 = new Point(1, 1);

        // 1. == 사용할 때
        // 기본 동작 : 참조(주소)가 동일한가?
        Console.WriteLine(p1 == p2); // true (연산자 재정의하면 : true)
        Console.WriteLine(p1 == p3); // false(연산자 재정의하면 : true)

        // 2. Equals() 가상함수 사용
        // 기본 동작 : 참조(주소)가 동일한가?
        Console.WriteLine(p1.Equals(p2)); // true (오버라이딩했을 시 : true)
        Console.WriteLine(p1.Equals(p3)); // false(오버라이딩했을 시 : true)
        Console.WriteLine();

        // 만약에 object 타입으로 한다면?
        // object 버전의 연산자가 불리게 된다.
        object op1 = new Point(1, 1);
        object op2 = op1;
        object op3 = new Point(1, 1);

        Console.WriteLine(op1 == op2); // true
        Console.WriteLine(op1 == op3); // false
        Console.WriteLine(op1.Equals(op2)); // true (오브젝트라 하더라도 가상메서드이기 때문에 내가 정의한 메서드가 호출된다.)
        Console.WriteLine(op1.Equals(op3)); // true
    }
}
```

`값 타입의 Equality` 를 살펴보자.
- `==` 연산자
  * 제공 되지 않음
  * 연산자 재정의 문법으로 제공가능!
- `Equals()` 가상 메소드
  * 기본 동작 : 메모리 내용을 비교
  * 재정의 해서 `비교 정책` 변경이 가능하다.
