using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Method_6
{
    internal class RefReturn
    {
        class Product
        {
            private int price = 100;

            public ref int GetPrice() { return ref price; }

            public void PrintPrice() { Console.WriteLine($"Price:{price}"); }
        }

        class Program
        {
            static void Main()
            {
                Product carrot = new Product();
                ref int ref_local_price = ref carrot.GetPrice(); // ref_local_price 수정하면 carrot.price도 변경된다.
                int normal_local_price = carrot.GetPrice();

                carrot.PrintPrice();
                Console.WriteLine($"Ref Local Price:{ref_local_price}");
                Console.WriteLine($"Normal Local Price:{normal_local_price}");

                ref_local_price = 200;

                carrot.PrintPrice();
                Console.WriteLine($"Ref Local Price:{ref_local_price}");
                Console.WriteLine($"Normal Local Price:{normal_local_price}");
            }
        }
    }
}
