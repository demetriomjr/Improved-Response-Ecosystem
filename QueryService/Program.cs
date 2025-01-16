using DotNetEnv;
using Microsoft.AspNetCore.Mvc;
using Application;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddInternalRepositories();
var app = builder.Build();

var group = app.MapGroup("/people");
group.MapGet("/", async (HttpContext context) =>
{
    var result = await ApplicationController.ApiController.People.GetAsync(x => x is not null);
    return Results.Ok(result);
});
group.MapGet("/:id", async (HttpContext context, [FromRoute] uint id) =>
{
    var result = await ApplicationController.ApiController.People.GetAsync(id);
    return result is null ? Results.NotFound() : Results.Ok(result);
});

var env = Env.Load("../../SolutionItems/.env");
var host = env.FirstOrDefault(x => x.Key.Equals("QUERY_HOST")).Value;
int.TryParse(env.FirstOrDefault(x => x.Key.Equals("QUERY_HOST")).Value, out var port);
app.Run($"{host}:{port}");
