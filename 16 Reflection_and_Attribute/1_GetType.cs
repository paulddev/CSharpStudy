using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/*
 * 리플렉션 : 객체의 형식(Type) 정보를 들여다보는 기능
 * 
 * Object는 모든 데이터의 조상
 * - Equals()
 * - GetHashCode()
 * - GetType() : Type 형식의 결과를 반환 (형식의 이름, 소속된 어셈블리 이름, 프로퍼티 목록 등등)
 * - ReferenceEquals()
 * - ToString()
 */

namespace _1_GetType
{
    class Program
    {
        static void PrintInterfaces(Type type)
        {
            Console.WriteLine("------ interfaces -----");

            Type[] interfaces = type.GetInterfaces();
            foreach(Type i in interfaces)
                Console.WriteLine("Name:{0}", i.Name);
            Console.WriteLine();
        }

        static void PrintFields(Type type)
        {
            Console.WriteLine("----- Fields -----");

            // 검색 옵션
            FieldInfo[] fields = type.GetFields(
                BindingFlags.NonPublic | 
                BindingFlags.Public | 
                BindingFlags.Static | 
                BindingFlags.Instance);
            
            foreach(FieldInfo field in fields)
            {
                string accessLevel = "protected";
                if (field.IsPublic) accessLevel = "public";
                else if (field.IsPrivate) accessLevel = "private";

                Console.WriteLine("Access:{0}, Type:{1}, Name:{2}", accessLevel, field.FieldType, field.Name);
            }

            Console.WriteLine();
        }

        static void PrintMethods(Type type)
        {
            Console.WriteLine("----- Methods -----");

            MethodInfo[] methods = type.GetMethods();
            foreach(MethodInfo method in methods)
            {
                Console.Write("Type:{0}, Name:{1}, Parameter:", method.ReturnType, method.Name);

                ParameterInfo[] args= method.GetParameters();
                for(int i = 0; i < args.Length; i++)
                {
                    Console.Write("{0}", args[i].ParameterType.Name);
                    if (i < args.Length - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintProperties(Type type)
        {
            Console.WriteLine("----- Properties -----");

            PropertyInfo[] properties = type.GetProperties();
            foreach(PropertyInfo property in properties)
            {
                Console.WriteLine("Type:{0}, Name:{1}", property.PropertyType.Name, property.Name);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            int a = 0;
            Type type = a.GetType();

            PrintInterfaces(type);
            PrintFields(type);
            PrintProperties(type);
            PrintMethods(type);
        }
    }
}
