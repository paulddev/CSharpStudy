## CLR에 대해서 알아보자.

CLR은 .NET Framework의 기본이자 .NET Framework의 VM(virtual machine, 가상머신)이다.

작성한 소스 코드를 OS위에 있는 .NET Framework에서 작동하게 해주는 것이라고 보면 된다.

아래의 표는 CLR이 포함된 전체적인 구조를 보여준다.

<p>Application(C#, C++, VB, NET) etc..</p>
<hr>
<p>CLR(Common Language Runtime)</p>
<hr>
<p> .NET Framework </p>
<hr>
<p> OS(Windows, Linux, OS X ...) </p>
<hr>
<p> Hardware (x86/x64, ARM...) </p>

CLR의 내부 구조는 다음과 같다.

`Base Class Library Support`: CLR은 Base Class Library(BCL)를 지원한다. (Collections, I/O, XML, DataType definition 등) <br>
`Thread Support`: Multiple threads(다중 스레드)의 병렬 실행을 관리하기 위한 threads 지원을 제공한다. <br>
`Com Marshaller`: C#에 없는 것을 가져다 쓰게 해준다? <br>
Com(Component Object Model) Component 규약을 따르는 Microsoft 사가 주체가 되어 만든 표준이며, 어떤 프로그램이나 시스템을 이루는 컴포넌트랑 상호 통신을 할 수 있도록 하는 메커니즘이다. <br>

`Type Checker`: CLR안의 CTS(Common Type System)과 CLS(Common Language Specification)를 사용하여 형식 검사한다. <br>
`Exception Manager`: .NET Language에 상관없이 예외를 처리한다. <br>
`Security Engine`: .NET Framework에서 제공되는 툴을 이용하여 code, folder, machine level 단위로 보안 사용 권한을 처리한다.<br>

`Debug Engine`: 응용 프로그램은 Debug Engine을 통하여 런타임동안 디버그가 가능하다. 이와 관련되어 Code 관리 및 추적에 편한 ICorDebug 인터페이스가 있다.<br>
`JIT Compiler`: CLR의 JIT 컴파일러는 마이크로소프트 중간언어(Microsoft Intermediate Language, MSIL)를 JIT 컴파일러가 실행되는 컴퓨터 환경에 특정한 기계 코드로 변환한다. <br>
`JIT(Just-In-Time) 그순간` 컴파일된 MSIL은 필요한 경우 후속 호출에 사용할 수 있도록 저장된다. <br>

`Code Manager`: CLR의 코드 매니저는 .NET Framework에서 개발된 코드, managed code를 관리한다. <br>
`Managed Code`: 언어별 컴파일러에 의해 중간 언어로 변환된 후 JIT Compiler에 의해 중간 언어가 기계 코드로 변환된다. <br>

`Garbage Collector`: CLR에서 Garbage Collector를 사용하여 자동 메모리 관리가 가능하다. 가비지 수집기는 더 이상 필요하지 않은 메모리 공간을 자동으로 해제하여 재할당이 가능하도록 한다.<br>

`CLR Loader`: 다양한 Modules, Resources, Assembiles 등은 CLR Loader에 의해 로드된다. 이 로더는 프로그램 초기화 시간이 더 빠르고 소모되는 자원이 덜하도록 실제로 필요한 경우 모듈을 온디맨드 방식으로 로드한다.<br>
`OnDemand`: 요구가 있을 때는 언제든지라는 뜻을 가지고 있다. <br>

CLR은 단순히 C#이나 기타 언어들을 동작시키는 환경 기능 외에도, 프로그램의 오류(예외 등)가 발생했을 때 이를 처리하도록 도와주는 기능, 언어간의 상속 지원, COM과의 상호 운영성 지원, 자동 메모리 관리 기능을 제공한다.

## CLR의 동작 원리
1. C# 소스 코드를 작성하면 C# Compiler가 IL(Intermediate Language) 중간 언어로 작성된 실행 파일을 만들어준다.
2. 마지막으로 사용자가 이 파일을 실행하게 되면 CLR이 IL을 읽어 하드웨어가 이해할 수 있는 NativeCode로 컴파일(JIT Compiler 이용)한 후 실행시킨다.

장점은 바로 플랫폼에 최적화된 코드를 만들어 낸다는 것이다. <br>
단점은 실행 시에 이루어지는 컴파일 비용의 부담이다. <br>

`Source Code` -> `Language Compiler` -> `MSIL Code, Meta data` -> `Just-In-Time Compiler` -> `Native Code`
