using System;
using System.Collections.Generic;
using System.Collections;

/*
 * foreach 를 사용할 수 있는 일반화 클래스 구현
 * 
 * 일반화 클래스도 IEnumerable 인터페이스를 상속하면 일단은 foreach를 통해 순회할 수 있지만,
 * 요소를 순회할 때마다 형식 변환을 수행하는 오버로드가 발생한다는 문제점이 있다.
 * 
 * 따라서 IEnumerable 의 일반화 버전인 IEnumerable<T> 인터페이스를 상속하면 형식 변환으로
 * 인한 성능 저하가 없으면서도 foreach 순회가 가능한 클래스를 작성할 수 있게 된다.
 * 
 * IEnumerable<T> 인터페이스의 메소드
 * IEnumerator GetEnumerator()    : IEnumerator 형식의 객체를 반환
 * IEnumerator<T> GetEnumerator() : IEnumerator<T> 형식의 객체를 반환
 * => IEnumerable<T> 인터페이스는 IEnumerator 인터페이스로부터 상속을 받았기 때문에 2개를 모두 구현해줘야 한다.
 * 
 * IEnumerator<T> 인터페이스의 메소드와 프로퍼티
 * boolean MoveNext()
 * void Reset()
 * Object Current { get; } : 컬렉션의 현재 요소를 반환한다. (IEnumerator로부터 상속받은 프로퍼티)
 * T Current { get; } : 컬렉션의 현재 요소를 반환한다.
 * => IEnumerator<T> 역시 IEnumerator 로부터 상속을 받았기 때문에 모두 구현해줘야 한다.
 */

namespace _7_EnumerableGeneric
{
    class MyList<T> : IEnumerable<T>, IEnumerator<T>
    {
        private T[] array;
        int position = -1;

        public MyList()
        {
            array = new T[3];
        }

        public MyList(int size)
        {
            array = new T[size];
        }

        public T this[int index]
        {
            get { return array[index]; }
            set
            {
                if(index >= array.Length)
                {
                    Array.Resize(ref array, index + 1);
                    Console.WriteLine($"Array Resized : {array.Length}");
                }

                array[index] = value;
            }
        }

        public int Length { get { return array.Length; } }

        public IEnumerator<T> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => this;

        public T Current { get { return array[position]; } }
        object IEnumerator.Current { get { return array[position]; } }

        public bool MoveNext()
        {
            if(position == array.Length - 1)
            {
                Reset();
                return false;
            }

            ++position;
            return position < array.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose() { }
    }

    class Program
    {
        static void Main()
        {
            MyList<string> myList = new MyList<string>();
            MyList<string> str_list = new MyList<string>(4);
            str_list[0] = "abc";
            str_list[1] = "def";
            str_list[2] = "ghi";
            str_list[3] = "mno";

            foreach (string str in str_list)
                Console.WriteLine(str);

            Console.WriteLine();
        }
    }
}
