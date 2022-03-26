using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace _4_CallerInfo
{
    public static class Trace
    {
        public static void WriteLine(string message,
            [CallerFilePath] string file = "", // 현재 메소드를 호출한 메소드 또는 프로퍼티의 이름
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string member = "")
        {
            Console.WriteLine($"{file}(Line:{line}) {member}: {message}");
        }
    }

    class Program
    {
        static void Main()
        {
            Trace.WriteLine("test!");
        }
    }
}
