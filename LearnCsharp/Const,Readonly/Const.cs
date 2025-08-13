namespace LearnCsharp
{
    //const로 선언된 변수는 컴파일 시점에 같이 결정
    //const 변수는 기본형이나 불변 객체에서만 사용할 수 있다.

    //readonly변수는 런타임 시점에 같이 설정
    //readonly변수는 객체를 포함한 모든 타입에서 사용 가능
    //생성자나 초기화 시에 할당 가능 그 외에는 불가능

    public class Const
    {
        const double PI = 3.14159;
        readonly double pi = 3.14159;
        public Const()
        {
            //컴파일 오류
            //PI = 3.14;
            pi = 3.14;
        }

        void MeMethod()
        {
            //컴파일 오류
            //PI = 3.14;
            //pi = 3.14;
        }
    }
}
