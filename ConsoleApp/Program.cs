using System;
using System.Linq;
using System.Reflection;

namespace ConsoleApp
{
    class Program
    {
        public class A
        {
            public int a = 1;
            public int b = 2;
            public int c = 3;
        }
        public class B
        {
            public int d = 4;
            public int e = 5;
            public int f = 6;
        }
        public static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            FieldInfo[] fia = typeof(A).GetFields();
            FieldInfo[] fib = typeof(B).GetFields();

            foreach (var p in fia)
                Console.WriteLine("{0} = {1}", p.Name, p.GetValue(a));

            for (int i = 0; i < fia.Count(); ++i)
                fia[i].SetValue(a, fib[i].GetValue(b));

            foreach (var p in fia)
                Console.WriteLine("{0} = {1}", p.Name, p.GetValue(a));
        }
    }
}
