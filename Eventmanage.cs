using System;
//using System.Collections.Generic;
//using System.Text;

//namespace LinqMasteryPractice
namespace Delegate
{
    public class Eventmanage
    {
        public delegate void delgName<T>(T m);
        public void Display<Type>(Type msg)
        {
            Console.WriteLine(msg);
        }
        public void Run()
        {
            delgName<String> a = Display;
            a("hello");
        }
    }
}
