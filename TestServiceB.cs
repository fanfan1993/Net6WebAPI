using yanfanNet6Interfaces；

namespace yanfanNet6Services
{
	public class TestServiceA : ITestServiceB
    {
		public TestServiceB()
		{
			Console.WriteLine($"{ GetType().Name } 被供找")
		}

		public string ShowB()
		{
			return $"this is from {GetType().FullName} ShowB"
		}
	}
}

