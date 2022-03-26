using System;
using System.Reflection;

namespace DynamicInstance
{
    class Profile
    {
        private string name;
        private string phone;
        public Profile() { name = ""; phone = ""; }
        public Profile(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }

        public void Print() => Console.WriteLine($"{name} {phone}");
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set =>phone = value; }
    }

    class Program
    {
        static void Main()
        {
            Type type = Type.GetType("DynamicInstance.Profile");
            MethodInfo methodInfo = type.GetMethod("Print");
            PropertyInfo nameProperty = type.GetProperty("Name");
            PropertyInfo phoneProperty = type.GetProperty("Phone");

            object profile = Activator.CreateInstance(type, "박상현", "012-3456");
            methodInfo.Invoke(profile, null); // 인수가 없으므로 null

            profile = Activator.CreateInstance(type);
            nameProperty.SetValue(profile, "박찬호", null);
            phoneProperty.SetValue(profile, "123-4567", null); // 마지막 null 은 인덱서가 없기 때문에 null

            Console.WriteLine("{0} {1}", nameProperty.GetValue(profile, null), phoneProperty.GetValue(profile, null));
        }
    }
}
