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

