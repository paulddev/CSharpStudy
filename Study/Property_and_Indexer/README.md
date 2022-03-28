# 프로퍼티와 인덱서

## Property
`public` 필드의 문제점
- 외부에서 잘못된 사용으로 객체의 상태가 잘못될 수 있다.
- 필드 접근 시 `추가적인 기능(스레드 동기화, logging등)`을 수행 할 수 없다.

`캡슐화(Encapsulation)`
- 필드는 private 하고, setter 와 getter 메소드를 사용해서 접근한다.

`Property`
- setter 와 getter 메소드를 자동으로 생성하는 문법
- 필드와 동일한 방법으로 접근한다.
```C#
class People
{
    private int age = 0;
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    //public int getAge() { return age; }
    //public void setAge(int value) { age = value; }
}
```

`Property 원리`
- 컴파일러가 setter 와 getter 메소드를 자동으로 생성해주는 것.
- 메소드 이름 : set_Age / get_Age => `ildasm 으로 확인 가능`

`setter / getter` 의 접근 권한을 변경할 수 있다.
- getter 만 있으면 `읽기 전용`
- setter 만 있으면 `쓰기 전용`

`Backing Field`가 없는 속성을 만들 수 도 있다.

`자동 속성(automatic property)`
- Backing Field, set, get 의 구현을 자동으로 제공한다.
```C#
public int Age { get; set; } = 0;
```

- 객체 생성시 프로퍼티 값을 초기화 하는 표기법
- 무명 형식(Anonymous type) : 읽기 전용으로 프로퍼티를 생성한다. (Linq 에서 많이 사용된다.)
```C#
class Point
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;
}
class Program
{
    static void Main()
    {
        Point p1 = new Point();
        Point p2 = new Point() { X = 10, Y = 20 };
        Point p3 = new Point { X = 10, Y = 20 };
        Point p4 = new Point { Y = 100 };

        // 무명 형식(Anonymous type) => 읽기 전용 프로퍼티 생성
        var p = new { Name = "dev", Age = 28 };
    }
}
```

## Indexer (인덱서)
- 객체를 배열처럼 사용할 수 있게 하는 문법 (C++ 에서는 `[]연산자 재정의`)
- 속성(Property) 와 유사한 방법
```C#
class Sentence
{
    private string[] words = null;
    public Sentence(string s) { words = s.Split(' '); }

    public string this[int index]
    {
        get { return words[index]; }
        set { words[index] = value; }
    }

    public override string ToString()
    {
        return String.Join(" ", words);
    }
}
class Program
{
    static void Main()
    {
        Sentence s = new Sentence("Dog is Animal");

        s[0] = "Cat";
        Console.WriteLine(s[0]); // Cat
        Console.WriteLine(s);    // Cat is Animal
    }
}
```

`Propety vs Indexer`
- ![image](https://user-images.githubusercontent.com/31722512/160447198-cb2559a2-bf38-413f-8cb2-48f0c7da048b.png)
- 인덱서는 매개 변수를 가지는 속성이다.

`인덱서의 주의사항`
- Index 타입이 반드시 정수일 필요는 없다.
- 2개 이상의 index 값도 가질 수 있다.
