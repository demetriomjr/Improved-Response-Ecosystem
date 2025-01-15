using DotNetEnv;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.ConfigureHttpJsonOptions(options =>
{
   
});
var app = builder.Build();

var group = app.MapGroup("/people");
group.MapPost("/", (HttpContext context) =>
{

});
group.MapPut("/:id", (HttpContext context, [FromRoute] uint id) =>
{

});
group.MapDelete("/:id", (HttpContext context, [FromRoute] uint id) =>
{

});

var env = Env.Load("../../SolutionItems/.env");
var host = env.FirstOrDefault(x => x.Key.Equals("COMMAND_HOST")).Value;
int.TryParse(env.FirstOrDefault(x => x.Key.Equals("COMMAND_HOST")).Value, out var port);
app.Run($"{host}:{port}");
