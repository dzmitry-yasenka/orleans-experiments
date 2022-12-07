namespace BasicOrleansExample.Actors;

public interface IGreeterGrain : IGrainWithStringKey
{
    Task<string> GetGreeting();
    Task<string> GetGreetingFor(string name);
}