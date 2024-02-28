using PeerToPeer.Services;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// creating a custom configuration builder of type IConfiguration
// which basically sets all the necessary configuration like filepath  very critically important step
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json"
        , optional: true
        ,reloadOnChange: true)
    .Build();

// This basically sets te=he logger in motion ....it reads the configuration from the above written code
// and finally creates the logger object 
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

// Use Serilog declaration of the serilog
builder.Host.UseSerilog();

//testing line for the serilog Ilogger
Log.Logger.Information("Application configured");
// Add services to the container. all the self built classes dependency injection will be done here
builder.Services.AddGrpc();
//example of the self made class <TestingLogging> which is injected as a singleton class .
builder.Services.AddSingleton<TestingLogging>();

/*builder.Services.AddTransient<ITestingLogging, TestingLogging>();
This is the recommended implementation*/

// after all the things are configured this line is called and build
// this signifies all the dependency are compiled and ready to be deployed
var app = builder.Build();

// initializing and resolving the instance of the interface  of the said class using ite interface as a <T> parameter
var testingLoggingService = app.Services.GetRequiredService<TestingLogging>();

// Execute the function which is written in the class ..imagine a case of connection class
testingLoggingService.Runiteration();


// Configure the HTTP request pipeline ..here we add the services of the gRPC service classes
app.MapGrpcService<GreeterService>();


app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client." +
        "To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

// this is the final command which runs the entire container which is built in the first line of the class
app.Run();


/*
 * ***********************      appsettings.json , appsettings.Development,json     ************************
 *
 * NOTES [comments cannot be written in json files]
 *
 *
 *
 * 
 */