public interface ITestingLogging
{
    /*
     recommended way of doing thing as using the interface gives you the flexibility of changing a specific implementation
     without making changes to the main code
     */
    void Runiteration();
}

public class TestingLogging : ITestingLogging
{
    // in injecting the logger in the code by the way of dependency injection and constructor initialization
    private readonly ILogger<TestingLogging> _log;

    // adding a injecting a reference of the IConfiguration as the Host has been mapped to a file which implements this
    // refer the Configuration builder in the program.cs
    private readonly IConfiguration _config;

    public TestingLogging(ILogger<TestingLogging> log, IConfiguration config)
    {
        // construction inilization
        _log = log;
        _config = config;
    }

    public void Runiteration()
    {
        // This method is called when this class is loaded and this function is called explicitly .
        // refer the code flow in the program.cs ... 
        for (int i = 0; i < _config.GetValue<int>("loopIterations", 10); i++)
        {
            Console.WriteLine($"Number {i}");
            _log.LogInformation("Loop Lumber {Iteration}", i);
        }
    }
}