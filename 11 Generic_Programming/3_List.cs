using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 일반화 컬렉션
 * 
 * 기존에 컬렉션들은 object 형식에 기반하고 있기 때문에 태생적으로 성능 문제를 가지고 있다.
 * 컬렉션의 요소에 접근할 때마다 형식 변환이 일어나기 때문에(박싱/언박싱)
 * 
 * 일반화 컬렉션은 object 형식 기반의 컬렉션이 갖고 있는 문제를 말끔히 해결해준다.
 * 말 그대로 일반화에 기반해서 만들어졌기 때문에 컴파일할 때 컬렉션에서 사용할 형식이 결정되고,
 * 쓸데없는 형식 변환을 일으키지 않는다.
 */

namespace _3_List
{
    class Program
    {
        static void Main()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach (int element in list)
                Console.Write($"{element} ");
            Console.WriteLine();

            list.RemoveAt(2);

            foreach (int element in list)
                Console.Write($"{element} ");
            Console.WriteLine();

            list.Insert(2, 2);

            foreach (int element in list)
                Console.Write($"{element} ");
            Console.WriteLine();
        }
    }
}
