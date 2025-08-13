namespace LearnCsharp
{
    public class TestOut
    {

        public TestOut()
        {
            string text = "1";
            bool success;
            int result;
            success = int.TryParse(text, out result);

            if (success)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write("변환에 실패하였습니다.");
            }
        }


    }
}
