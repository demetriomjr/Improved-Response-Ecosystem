using DotNetEnv;
using Microsoft.AspNetCore.Mvc;
using Application;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.ConfigureHttpJsonOptions(options =>
{

});
builder.Services.AddInternalRepositories(); // Certifique-se de que este método está definido em algum lugar no seu projeto

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
