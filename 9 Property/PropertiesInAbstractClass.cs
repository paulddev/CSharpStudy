using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 추상 클래스의 프로퍼티
 * 
 * 추상 클래스는 클래스처럼 구현된 프로퍼티를 가질 수 있지만, 인터페이스처럼 구현되지 않은 프로퍼티도 가질 수 있다.
 * 이것을 추상 프로퍼티라고 한다.
 * 키워드 abstract 를 사용하면 추상 프로퍼티가 된다.
 */

namespace PropertiesInAbstractClass
{
    abstract class Product
    {
        private static int serial = 0;
        public string SerialID { get { return String.Format("{0:d5}", serial++); } }
        abstract public DateTime ProductDate { get; set; } // 추상 프로퍼티 -> 자동 구현 프로퍼티를 C# 컴파일러가 만들어 주지 않는다.
    }

    class MyProduct : Product
    {
        public override DateTime ProductDate { get; set; } // C# 컴파일러가 자동 구현 프로퍼티를 구현해준다.
    }

    class Program
    {
        static void Main()
        {
            Product product_1 = new MyProduct() { ProductDate = new DateTime(2022, 3, 8) };

            Console.WriteLine("Product:{0}, Product Date:{1}", product_1.SerialID, product_1.ProductDate);

            Product product_2 = new MyProduct() { ProductDate = new DateTime(2022, 3, 8) };

            Console.WriteLine("Product:{0}, Product Date:{1}", product_2.SerialID, product_2.ProductDate);
        }
    }
}
