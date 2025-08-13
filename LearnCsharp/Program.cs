using System;
using LearnCsharp;

class Program
{
    static void Main()
    {
        //TestRef testRef = new TestRef();
        //testRef.Run();

        //TestOut textOut = new TestOut();

        //Person person = new Person("홍킬동");
        //Console.WriteLine(person.Name);

        //가비지 컬렉터
        /*void Test()
        {
            for (int i = 0; i < 1000000; i++)
            {
                //클래스 객체가 생성할 때 힙 메모리에 할당
                //클래스 객체가 소멸할 때 소멸자가 호출되어 힙 메모리에서 해제
                //가비지 컬렉터가 소멸자를 호출할 때까지 객체를 소멸하지 않음
                MyClass myClass = new MyClass(i);
            }
        }

        Test();*/
        
        //정적 메서드
        //TestStatic.Print();

        //상속
        Animal dog = new Dog();
        dog.Eat();

        Animal cat = new Cat();
        cat.Eat();

        //접근제어자
        cat.Eat();
        cat.Eat();
        cat.Eat();
        Console.WriteLine($"Cat Hp: {cat.Hp}");
        
        Console.ReadKey();

    }
}