using BasicOrleansExample.Actors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("-----BasicOrleansExample.Client-----");

using var host = new HostBuilder()
        .UseOrleansClient(clientBuilder => clientBuilder.UseLocalhostClustering())
        .Build();

await host.StartAsync();
Console.WriteLine("Host is running.");

var grainFactory = host.Services.GetRequiredService<IGrainFactory>();

for (var i = 0; i < 10; i++)
{
        var friend = grainFactory.GetGrain<IGreeterGrain>($"console-friend-{i}");

        var personalisedGreeting = await friend.GetGreetingFor("Dima");
        Console.WriteLine("{0}", personalisedGreeting);

        var globalGreeting = await friend.GetGreeting();
        Console.WriteLine("{0}", globalGreeting);
        await Task.Delay(1000);
}

Console.WriteLine("Host is stopping...");
await host.StopAsync();
Console.WriteLine("-----BasicOrleansExample.Client-----");
