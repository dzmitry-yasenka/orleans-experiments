using BasicOrleansExample.Actors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

Console.WriteLine("-----BasicOrleansExample.Server-----");
using var host = new HostBuilder()
    .UseOrleans(siloBuilder =>
    {
        siloBuilder.UseLocalhostClustering();
        siloBuilder.ConfigureLogging(loggingBuilder =>
        {
            loggingBuilder.AddConsole();
        });
    })
    .Build();

await host.StartAsync();
Console.WriteLine("Orleans is running.");

// Get the grain factory
var grainFactory = host.Services.GetRequiredService<IGrainFactory>();
var friend = grainFactory.GetGrain<IGreeterGrain>("friend");

var personalisedGreeting = await friend.GetGreetingFor("Dima");
Console.WriteLine("{0}", personalisedGreeting);

var globalGreeting = await friend.GetGreeting();
Console.WriteLine("{0}", globalGreeting);

Console.WriteLine("Press Enter to terminate...");
Console.ReadLine();
Console.WriteLine("Orleans is stopping...");

await host.StopAsync();
Console.WriteLine("-----BasicOrleansExample.Server-----");