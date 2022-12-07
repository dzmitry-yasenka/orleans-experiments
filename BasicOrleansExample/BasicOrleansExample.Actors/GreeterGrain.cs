using Microsoft.Extensions.Logging;

namespace BasicOrleansExample.Actors;

public class GreeterGrain : Grain, IGreeterGrain
{
    private int _numberOfCallsOfGeneralisedGreetings = 0;
    private int _numberOfCallsOfPersonalisedGreetings = 0;

    private readonly ILogger<GreeterGrain> _logger;

    public GreeterGrain(ILogger<GreeterGrain> logger)
    {
        _logger = logger;
    }

    public Task<string> GetGreeting()
    {
        _numberOfCallsOfGeneralisedGreetings++;
        _logger.LogInformation("'GetGreeting' was called at {Timestamp}", DateTime.UtcNow);
        return Task.FromResult($"{IdentityString}: Hello, World! (called {_numberOfCallsOfGeneralisedGreetings} times)");
    }

    public Task<string> GetGreetingFor(string name)
    {
        _numberOfCallsOfPersonalisedGreetings++;
        _logger.LogInformation("'GetGreetingFor' was called at {Timestamp}", DateTime.UtcNow);
        return Task.FromResult($"{IdentityString}: Hello, {name}! (called {_numberOfCallsOfPersonalisedGreetings} times)");
    }
}