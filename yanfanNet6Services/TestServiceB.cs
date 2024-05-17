using yanfanNet6Interfaces;

namespace yanfanNet6Services;
public class TestServiceB : ITestServiceB
{
    public ITestServiceA _TestServiceA;
    public TestServiceB(ITestServiceA testServiceA)
    {
        _TestServiceA = testServiceA;
        Console.WriteLine($"{GetType().Name} 被构招");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string ShowB()
    {
        return $"this is from {GetType().FullName} ShowB 调用{_TestServiceA.ShowA()}" ;
    }

}

