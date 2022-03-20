using System;
using System.Collections;

namespace _10_11_Yield
{
    class MyEnumerator
    {
        int[] numbers = { 1, 2, 3, 4 };
        public IEnumerator GetEnumerator()
        {
            // yield문을 사용하면 IEnumerator를 상속하는 클래스를 따로 만들지 않아도
            // 컴파일러가 자동으로 해당 인터페이스를 구현한 클래스를 생성해준다.
            yield return numbers[0];
            yield return numbers[1]; // 실행을 일시 정지시켜놓고 호출자에게 결과를 반환한다.
            yield return numbers[2]; // 다시 호출되면 일시 정지된 실행을 복구하여 yield return or yield break문을 만날때까지 나머지 작업을 실행한다.
            yield break;
            yield return numbers[3];
        }
    }

    class Program
    {
        static void Main()
        {
            var obj = new MyEnumerator();
            foreach (int i in obj)
                Console.WriteLine(i);
        }
    }
}
