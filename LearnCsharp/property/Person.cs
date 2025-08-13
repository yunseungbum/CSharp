namespace LearnCsharp
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            init
            {
                _name = value;
            }
        }
    }
}
