using DotNetEnv;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.ConfigureHttpJsonOptions(options =>
{
    
});
builder.Services.AddOcelot();
Env.Load("../../SolutionItems/.env");
var app = builder.Build();
app.UseOcelot().Wait();
app.Run();
