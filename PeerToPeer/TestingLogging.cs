public interface ITestingLogging
{
    void Runiteration();
}

public class TestingLogging : ITestingLogging
{
    private readonly ILogger<TestingLogging> _log;
    private readonly IConfiguration _config;

    public TestingLogging(ILogger<TestingLogging> log , IConfiguration config)
    {
        _log = log;
        _config = config;
 
    }

    public void Runiteration()
    {
        for (int i = 0; i < _config.GetValue<int>("loopIterations",10); i++)
        {
            Console.WriteLine($"Number {i}");
            _log.LogInformation("Loop Lumber {Iteration}",i);
        }
    }

   
}