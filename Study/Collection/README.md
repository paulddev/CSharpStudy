# Collecion
- 동일 타입의 객체를 여러 개 보관 할 수 있는 클래스
- 배열, Linked List, Tree, Hash Table 등의 자료구조를 구현한 클래스
- 언어에 따라 Java, C#은 Collection, C++은 Container
- 다양한 타입에 대한 컬렉션이 필요

`System.Object` 를 저장하는 컬렉션
- `System.Collections;`
- 타입 안정성이 좋지 않고, 값을 꺼낼 때 캐스팅이 필요
- Generic 개념이 추가 되기 전에 사용하던 컬렉션

`특정 타입만 저장하는 컬렉션` : `System.Collections.Speciallized;`

`Generic 컬렉션` : `System.Collections.Generic;`

`Thread safe 컬렉션` : `System.Collections.Concurrent;`

## 번외편, Concurrency 하다 (동시성이란 무엇일까?)
애플리케이션이 실행될 때 한 개의 프로세스가 만들어지고, 그 프로세스가 어떠한 일을 할 때 컴퓨터의 자원을 최대한으로 활용하기 위해서는 병렬적으로 일을 처리해야 한다. <br>
Thread를 이용해서 컴퓨터가 놀고 있는 자원들을 최대한으로 사용하게 만드는 것이 `Multi-Thread Programming`의 영역이다. <br>
I/O를 기다리게 하지 않고 다른 일을 하거나, 놀고 있는 여분의 CPU 코어들을 최대한 사용하게 하는 것이 핵심이다. <br>

그래서 각 언어에서는 Threading을 편리하게 사용할 수 있게 `API`를 제공하기는 하지만 thread를 사용하다 보면 join, detach 등의 시점들을 설계하고, <br>
`mutex_lock`, `mutex_unlock`으로 리소스들을 락킹하고 해제하고, 필요하면 `세마포어`도 구현해서 최적의 퍼포먼스를 낼 수 있도록 해주는 일은 <br>
애플리케이션이 무거워지고 커질수록 간단한 일이 아니게 된다. 이러한 일들은 한 두번 쯤 `데드락`이 발생되어 여러가지 문제점과 어려움이 동반된다.

Language 에서 Parallelism 이라고 불리는 대표적인 예가 바로 `thread`. <br>
스레드야 말로 동시에 평행적으로 실행이 된다. 그래서 그만큼 효율적으로 일을 해낸다.

`Concurrency` 는 `Parallelism` 의 난해함을 풀어낸 방법이다. 대표적으로 `Coroutine`이 있다. <br>
유니티에서 코루틴은 서브루틴의 일종으로 진입 시점이 여러개인 서브 루틴을 말한다.

이 코루틴은 thread 와 달리 평행하게 일을 수행하지 않는다. 한 개의 Process 가 Coroutine 에 설정된 조건에 따라서 일반 서브루틴들과 왔다갔다 하면서 Task를 처리하는 방식이다. <br>
그럼에도 불구하고 특정 라인이 수행된 다음 차근차근 수행되는 Sync 방식이 아니라 Async 하게 코드를 실행시키고, 결과 값이 오거나 혹은 필요한 때에 다음 루틴을 실행 시키게 할 수 있어서 효율적으로 자원을 활용할 수 있다. <br>
thread 로 구현했을 때보다 훨씬 깔끔하고 Locking/UnLocking 메커니즘을 싹 걷어낼 수 있다.

Concurrency 는 기존에 C 나 C++ 에서 다뤘던 멀티쓰레드와 자원 관리의 복잡함으로부터 개발자들을 해방시키는 역할을 해준다. <br>
동시에 멀티쓰레드로 해냈던 수준의 Async하고 Parallel한 작업들을 흉내내거나 손쉽게 수행할 수 있도록 해준다.

