using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 배열의 힘!
 * 
 * Sort() : 배열을 정렬
 * BinarySearch<T>() 이진 탐색을 수행
 * 
 * IndexOf() 배열에서 찾고자 하는 특정 데이터의 인덱스를 반환한다.
 * FindIndex<T>() 배열에서 지정한 조건에 부합하는 첫 번째 요소의 인덱스를 반환, (지정한 조건에 바탕하여 값을 찾는다.)
 * 
 * TrueForAll<T>() 배열의 모든 요소가 지정한 조건에 부합하는지의 여부를 반환
 * 
 * Resize<T>() 배열의 크기 재조정
 * Clear() 배열의 모든 요소를 초기화(숫자 형식이면 0, 논리 형식이면 false, 참조 형식이면 null)
 * 
 * ForEach<T>() 배열의 모든 요소에 대해 동일한 작업을 수행하게 한다.
 * Copy<T>() 배열의 일부를 다른 배열에 복사한다. (깊은 복사)
 * 
 * GetLength() 배열에서 지정한 차원의 길이를 반환, 다차원 배열에서 유용
 * 
 * Length : 배열의 길이를 반환(프로퍼티)
 * Rank : 배열의 차원을 반환(프로퍼티)
 */

namespace _10_2_MoreOnArray
{
    class Program
    {
        private static bool CheckPassed(int score)
        {
            return score >= 60;
        }

        private static void Print(int value)
        {
            Console.Write($"{value} ");
        }

        static void Main()
        {
            int[] scores = new int[] { 80, 74, 81, 90, 34 };

            foreach (int score in scores)
                Console.Write($"{score} ");
            Console.WriteLine();

            // 1. Sort()
            Array.Sort(scores);

            foreach (int score in scores)
                Console.Write($"{score} ");
            Console.WriteLine();

            // 2. ForEach<T>()
            Array.ForEach(scores, new Action<int>(Print));
            Console.WriteLine();

            // 3. Rank
            Console.WriteLine($"Number of dimesions : {scores.Rank}");

            // 4. BinarySearch
            Console.WriteLine($"Binary Search : 81 is at " + $"{Array.BinarySearch<int>(scores, 81)}");

            // 5. LinearSearch
            Console.WriteLine($"Linear Search : 90 is at " + $"{Array.IndexOf(scores, 90)}");

            // 6. TrueForAll
            Console.WriteLine($"Everyone passed ? : " + $"{Array.TrueForAll<int>(scores, CheckPassed)}");

            // 7. FindIndex (람다식 이용)
            int index = Array.FindIndex<int>(scores, (score) => score < 60);
            scores[index] = 100;
            Console.WriteLine($"Everyone passed ? : " + $"{Array.TrueForAll<int>(scores, CheckPassed)}");

            Console.WriteLine(scores.GetLength(0));

            // 5 -> 10 용량 재조정
            Array.Resize<int>(ref scores, 10);
            Array.ForEach<int>(scores, new Action<int>(Print));
            Console.WriteLine();
            
            Array.Clear(scores, 3, 7);
            Array.ForEach<int>(scores, new Action<int>(Print));
            Console.WriteLine();

            int[] sliced = new int[3];
            Array.Copy(scores, 0, sliced, 0, 3);
            Array.ForEach<int>(sliced, new Action<int>(Print));
            Console.WriteLine();

            sliced[0] = 7000;
            Array.ForEach<int>(scores, new Action<int>(Print));
            Console.WriteLine();
        }
    }
}
