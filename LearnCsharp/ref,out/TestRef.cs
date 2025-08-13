using System;

namespace LearnCsharp
{
    public class TestRef
    {
        private void Test(ref string a)
        {
            a = "b";
            Console.WriteLine($"메서드 내 a: {a}");
        }
        public void Run()
        {
            string a = "a";
            Test(ref a);
            Console.WriteLine(a);
        }
    }
}
