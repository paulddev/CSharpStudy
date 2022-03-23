using System;
using System.Collections.Generic;

/*
 * 형식 매개변수 제약시키기
 * 
 * 형식 매개변수 T는 모든 데이터 형식을 대신할 수 있지만, 종종 특정 조건을 갖춘 형식에서만 대응할 수 있게 제약을 걸 수 있다.
 * 
 * where 형식 매개변수 : 제약조건
 * 
 * where T : struct (T는 값 형식)
 * where T : class  (T는 참조 형식)
 * where T : new()  (T는 반드시 매개변수가 없는 생성자가 있어야 한다.)
 * where T : 기반_클래스_이름 (T는 명시한 기반 클래스의 파생 클래스여야 한다.)
 * where T : 인터페이스_이름  (T는 명시한 인터페이스를 반드시 구현해야 한다. 인터페이스_이름에는 여러 개의 인터페이스를 명시할 수 있다.)
 * where T : U (T는 또 다른 형식 매개변수 U로부터 상속받은 클래스여야 한다.)
 */

namespace _2_ConstraintsOnTypeParameters
{
    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            Console.WriteLine($"StructArray(int {size})");
            Array = new T[size];
        }
    }

    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            Console.WriteLine($"RefArray(int {size})");
            Array = new T[size];
        }
    }

    class Base { }
    class Derived : Base { }
    class BaseArray<U> where U : Base
    {
        public U[] Array { get; set; }
        public BaseArray(int size)
        {
            Array = new U[size];
        }

        public void CopyArray<T>(T[] Source) where T : U
        {
            Source.CopyTo(Array, 0);
        }
    }

    class Program
    {
        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        static void Main()
        {
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0; // type : int
            a.Array[1] = 1;
            a.Array[2] = 2;

            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(4);
            b.Array[0] = new StructArray<double>(5); // type : StructArray<double>
            b.Array[1] = new StructArray<double>(6);

            BaseArray<Base> c = new BaseArray<Base>(7);
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreateInstance<Base>();

            BaseArray<Derived> d = new BaseArray<Derived>(9);
            d.Array[0] = new Derived(); // Base 형식은 여기에 할당할 수 없다.
            d.Array[1] = CreateInstance<Derived>();

            BaseArray<Derived> e = new BaseArray<Derived>(9);
            e.CopyArray<Derived>(d.Array);
        }
    }
}
