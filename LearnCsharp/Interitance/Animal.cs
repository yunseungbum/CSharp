namespace LearnCsharp
{

    //접근제어자와 상속
    //public: 모든 클래스에서 접근 가능
    //protected: 해당 클래스와 자식 클래스에서만 접근 가능
    //private: 해당 클래스에서만 접근 가능
    //internal: 같은 어셈블리 내에서 접근 가능
    //protected internal: 같은 어셈블리 또는 자식 클래스에서 접근 가능
    //private protected: 같은 어셈블리의 자식 클래스에서만 접근 가능

    public class Animal
    {
        protected int _hp = 100;

        public int Hp => _hp;

        //메서드 오버라이딩
        //자식클래스에서 부모 클래스의 메서드를 재정의 하려면 virtual과 override 키워드 사용
        public virtual void Eat()
        {
            Console.WriteLine("먹습니다.");
        }
    }

    class Cat : Animal
    {
        public override void Eat()
        {
            _hp += 10;
            Console.WriteLine("고양이가 먹습니다.");
        }
    }

    class Dog : Animal
    {
        public override void Eat()
        {
            _hp += 15;

            //base: 자식 클래스에서 부모 클래스의 멤버에 접근할 떄 사용
            //base.Eat();
            Console.WriteLine("개가 먹습니다.");
        }

    }
}
