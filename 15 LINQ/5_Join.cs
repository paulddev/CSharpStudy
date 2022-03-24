using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Join
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    class Product
    {
        public string Title { get; set; }
        public string Star { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Profile[] arrProfile =
            {
                new Profile() {Name = "정우성", Height = 186},
                new Profile() {Name = "김태희", Height = 158},
                new Profile() {Name = "고현정", Height = 172},
                new Profile() {Name = "이문세", Height = 178},
                new Profile() {Name = "하하", Height = 171},
            };

            Product[] arrProduct =
            {
                new Product() {Title = "비트", Star = "정우성"},
                new Product() {Title = "CF 다수", Star = "김태희"},
                new Product() {Title = "아이리스", Star = "김태희"},
                new Product() {Title = "모래시계", Star = "고현정"},
                new Product() {Title = "Solo 예찬", Star = "이문세"},
            };
            
            /*
             * 내부 조인(inner join) : 교집합 (일치하는 데이터들만 연결한 후 반환)
             * 기준은 첫 번째 원본 데이터
             * 조인 조건은 동등만 허용된다. (equals)
             */
            var listProfile = from profile in arrProfile
                              join product in arrProduct on profile.Name equals product.Star
                              select new { Name = profile.Name, Work = product.Title, Height = profile.Height };

            Console.WriteLine("--- 내부 조인 결과 ---");
            foreach(var profile in listProfile)
            {
                Console.WriteLine("이름:{0}, 작품:{1}, 키:{2}cm", profile.Name, profile.Work, profile.Height);
            }

            /*
             * 외부 조인(outer join) : 합집합 (원본이 모두 포함된다는 점)
             * 외부 조인이 기준이 되는 데이터의 원본의 모든 데이터를 조인 결과에 반드시 포함시키는 특징
             * 기준 데이터의 원본 데이터와 일치하는 데이터가 없다면 그 부분은 빈 값으로 결과를 채운다.
             * 
             * join 절을 이용해서 조인을 수행한 후 그 결과를 임시 컬렉션에 저장하고, 이 임시 컬렉션에 대해서 DefaultIfEmpty 연산을 수행해서
             * 비어 있는 조인 결과에 빈 값을 채워 넣는다.
             */
            listProfile = from profile in arrProfile
                          join product in arrProduct on profile.Name equals product.Star into ps
                          from temp in ps.DefaultIfEmpty(new Product() { Title = "empty" })
                          select new { Name = profile.Name, Work = temp.Title, Height = profile.Height };

            Console.WriteLine("\n--- 외부 조인 결과 ---");
            foreach(var profile in listProfile)
            {
                Console.WriteLine("이름:{0}, 작품:{1}, 키:{2}cm", profile.Name, profile.Work, profile.Height);
            }
        }
    }
}
