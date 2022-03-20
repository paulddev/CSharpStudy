using System;
using System.Collections;

/*
 * public abstract  class Array : ICloneable, IList, ICollection,  IEnumerable
 * 
 * 배열과 닮은 컬렉션
 * 용량을 미리 지정할 필요 없이 필요에 따라 자동으로 그 용량이 늘어나거나 줄어든다.
 * 
 * Add()      : 가장 마지막에 있는 요소 뒤에 새 요소를 추가
 * RemoveAt() : 특정 인덱스에 있는 요소를 제거
 * Insert()   : 원하는 위치에 새 요소를 삽입
 * 
 * ArrayList는 다양한 형식을 담을 수 있는 이유 : Object 타입이기 때문(모든 형식은 Object를 상속하기 때문에)
 * => 문제점 : 박싱/언박싱 빈번함 (성능상에 좋지 않다.)
 * => 해결책 : 일반화 컬렉션 이용
 */

namespace _10_4_ArrayList
{
    class Program
    {
        static void Main()
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach (object o in list)
                Console.Write($"{o} ");
            Console.WriteLine();

            list.RemoveAt(2);

            foreach (object o in list)
                Console.Write($"{o} ");
            Console.WriteLine();

            list.Insert(2, 707);

            foreach (object o in list)
                Console.Write($"{o} ");
            Console.WriteLine();

            list.Add("ME");
            list.Add("HI");

            foreach (object o in list)
                Console.Write($"{o} ");
            Console.WriteLine();
        }
    }
}
