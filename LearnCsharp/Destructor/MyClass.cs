namespace LearnCsharp
{
    public class MyClass
    {
        private readonly int index;

        public MyClass(int index)
        {
            this.index = index;
        }
        ~MyClass() 
        {
            Console.WriteLine(index);
        }
    }
    
}
