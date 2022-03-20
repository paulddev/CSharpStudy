using System;
using System.Collections;

/*
 * 컬렉션 초기화
 * 
 * ArrayList : 배열의 도움 없이 직접 컬렉션 초기자를 이용해서 초기화 가능
 * 
 * Stack, Queue 는 컬렉션 초기자를 사용할 수 없다.
 * 
 * Hashtable 은 딕션너리 초기자를 이용한다. (컬렉션 초기자도 사용할 수 있다.)
 */

namespace _10_9_InitializingCollections
{
    class Program
    {
        static void Main()
        {
            int[] arr = { 123, 456, 789 };

            ArrayList list = new ArrayList(arr);
            foreach(object o in list)
            {
                Console.Write($"{o} ");
            }
            Console.WriteLine();

            Stack stack = new Stack(arr);
            foreach(object o in stack)
            {
                Console.Write($"{o} ");
            }
            Console.WriteLine();

            Queue queue = new Queue(arr);
            foreach(object o in queue)
            {
                Console.Write($"{o} ");
            }
            Console.WriteLine();

            ArrayList list2 = new ArrayList() { 10, 20, 30 };
            foreach(object o in list2)
            {
                Console.Write($"{o} ");
            }
            Console.WriteLine();

            Hashtable ht = new Hashtable()
            {
                ["one"] = 1,
                ["two"] = 2,
                ["three"] = 3
            };
        }
    }
}
