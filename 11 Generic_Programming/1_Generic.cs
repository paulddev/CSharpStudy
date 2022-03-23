using System;
using System.Collections.Generic;

/*
 * 일반화(제너릭)에 대해서 알아보자.
 * 
 * 일반화할 형식이 들어갈 자리에는 구체적인 형식의 이름 대신에 형식 매개변수(Type parameter)가 들어간다.
 * 
 * 일반화 메소드, 일반화 클래스, 일반화 컬렉션 다 가능하다!!!
 * 
 * 사용하는 경우(데이터형만 다르고 모든게 같을 때)=> 우리는 일반화할 수 있게 된다.
 * 
 * 매개변수 T는 객체를 생성할 때 입력받은 형식으로 치환하여 컴파일 된다.
 */

namespace _1_Generic
{
    class MyList<T>
    {
        private T[] array;

        public MyList()
        {
            array = new T[3];
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
    }

    class Program
    {
        static void Main()
        {
            MyList<string> str_list = new MyList<string>();
            for(int i = 0; i < 5; i++)
            {
                str_list[i] = $"{i} string";
            }

            for(int i = 0; i <str_list.Length; i++)
            {
                Console.WriteLine(str_list[i]);
            }
            Console.WriteLine();
        }
    }
}
