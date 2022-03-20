using System;
using System.Collections;

/*
 * foreach 가능한 객체 만들기
 * 
 * foreach문은 배열이나 리스트 같은 컬렉션에서만 사용이 가능하지만,
 * IEnumerable을 상속한다면 지원할 수 있게 된다.
 * 
 * foreach문을 이용해서 요소를 순회가 가능하게 한다.
 * 
 * IEnumerable 인터페이스가 갖고 있는 메소드는 한 개
 * IEnumerator GetEnumerator() : IEnumerator 형식의 객체를 반환한다.
 * 
 * IEnumerator 인터페이스가 갖고 있는 메소드와 프로퍼티
 * boolean MoveNext() : 다음 요소로 이동한다. 컬렉션의 끝을 지나는 경우에는 false, 이동이 성공하는 경우에는 true
 * void Reset() : 컬렉션의 첫 번째 위치의 "앞"으로 이동, 0인 경우 Reset()을 호출하면 -1번으로 이동
 *                첫 번째 위치로의 이동은 MoveNext()를 호출한 다음에 이루어진다.
 * Object Current { get; } : 컬렉션의 현재 요소를 반환한다.
 */

namespace _10_12_Enumerable
{
    class MyList : IEnumerable, IEnumerator
    {
        private int[] array;
        int position = -1;

        public MyList()
        {
            array = new int[3];
        }

        public int this[int index]
        {
            get { return array[index]; }
            set
            {
                if (index >= array.Length)
                {
                    Array.Resize(ref array, index + 1);
                    Console.WriteLine($"Array Resized : {array.Length}");
                }

                array[index] = value;
            }
        }

        // IEnumerator 멤버 : 현재 위치의 요소를 반환한다.
        public object Current { get { return array[position]; } }
        // IEnumerator 멤버 : 다음 위치의 요소로이동한다.
        public bool MoveNext()
        {
            if (position == array.Length - 1)
            {
                Reset();
                return false;
            }

            ++position;
            return position < array.Length;
        }
        // IEnumerator 멤버 : 요소의 위치를 첫 요소의 "앞"으로 옮긴다.
        public void Reset()
        {
            position = -1;
        }

        // IEnumerable 멤버
        public IEnumerator GetEnumerator()
        {
            return this; // array.GetEnumerator(); array 자체 내에 구현이 되어있긴하다.
        }
    }

    class Program
    {
        static void Main()
        {
            MyList list = new MyList();
            for (int i = 0; i < 5; i++)
                list[i] = i;

            // 순회 방법1
            foreach (int e in list)
                Console.WriteLine(e);

            Console.WriteLine();

            // 순회 방법2
            IEnumerator enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            /*
             * 1. GetEnumerator()로 IEnumerator를 받은 후,
             * 2. MoveNext()를 호출해서 확인한다.
             * 3. Current 프로퍼티를 통해 값을 읽어와 출력한다.
             * 다시 2와 3의 과정을 반복하면서 순회하다가 더 이상 이동하지 못하면 끝낸다.
             */
        }
    }
}
