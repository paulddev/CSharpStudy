using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 프로퍼티와 생성자
 * 
 * 객체를 생성할 때, 각 필드를 초기화하는 또 다른 방법이다.
 */

namespace ConstructorWithProperty
{
    class Box
    {
        public string Name { get; set; } = "Box";
        public int Size { get; set; } = 10;
    }

    class Book
    {
        public string Title { get; set; } = "Unknown";
        public int Price { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
    }

    class Program
    {
        static void Main()
        {
            Box box = new Box()
            {
                Name = "Single box",
                Size = 15
            };

            Console.WriteLine(box.Name);
            Console.WriteLine(box.Size);

            Book book = new Book()
            {
                Title = "톰과 제리",
                Price = 5000,
                //객체를 생성할 때 <프로퍼티 = 값> 목록에 객체의 모든 프로퍼티가 올 필요는 없다.
                //초기화하고 싶은 프로퍼티만 넣어서 초기화하면 된다.
                //Description = "권장 책"
            };

            Console.WriteLine($"책 이름 : {book.Title}");
            Console.WriteLine($"책 가격 : {book.Price}");
            Console.WriteLine($"책 설명 : {book.Description}");
        }
    }
}
