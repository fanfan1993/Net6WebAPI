using yanfanNet6Interfaces;

namespace yanfanNet6Services;
public class TestServiceA : ITestServiceA
{
    public TestServiceA()
    {
        Console.WriteLine($"{GetType().Name} 被供找");
        }

    public string ShowA()
    {
        return $"this is from {GetType().FullName} ShowA";
        }

}

