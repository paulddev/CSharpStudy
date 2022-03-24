using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Linq (Language INtegrated Query) 시작
 * 
 * LINQ 쿼리식은 반드시 from 절로 시작하게 되는데,
 * from은 IEnumerable<T>를 상속하는 형식이어야만 한다.
 */

namespace ConsoleApp4._15_LINQ
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };

            // LINQ 범위 변수와 foreach 문의 반복 변수의 차이점
            // foreach : 데이터 원본으로부터 데이터를 담아낸다.
            // 범위 변수(n) : 실제로 데이터를 담지는 않는다.
            // 범위 변수는 오로지 Linq 질의 안에서만 통용된다.

            // 쿼리식의 대상이 될 데이터 원본과 데이터 원본 안에 들어 있는
            // 각 요소 데이터를 나타내는 범위 변수를 from에서 지정해줘야 한다.
            var result = from n in numbers
                         where n % 2 == 0 // 필터 역할
                         orderby n        // 데이터의 정렬을 수행하는 연산자(정렬의 기준이 될 항목을 인수로 입력) descending 입력하면 내림차순
                         select n;        // 최종결과를 추출하는 쿼리식의 마침표

            // LINQ 질의 결과는 IEnumerable<T>로 변환되는데
            // 이때 형식 매개변수 T는 select 문에 의해 결정된다.
            // 무명 형식(새로운 형식)을 즉슥에서 만들어낼 수도 있다.
            // select new {Name = profile.Name, InchHeight = profile.Height * 0.393 }; 

            foreach (int n in result)
                Console.WriteLine(n);
        }
    }
}
