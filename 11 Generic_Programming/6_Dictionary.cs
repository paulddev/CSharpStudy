using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Dictionary
{
    class Program
    {
        static void Main()
        {
            // Hashtable 의 일반화 버전
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic["one"] = "1";
            dic["two"] = "2";
            dic["three"] = "3";
            dic["four"] = "4";
            dic["five"] = "5";

            Console.WriteLine(dic["one"]);
            Console.WriteLine(dic["five"]);
        }
    }
}
