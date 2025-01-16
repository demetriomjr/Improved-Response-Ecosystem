using DotNetEnv;
using Microsoft.AspNetCore.Mvc;
using Application;
using Models.People;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddInternalRepositories();
var app = builder.Build();

var group = app.MapGroup("/people");
group.MapPost("/", async ([FromBody] Person? item) =>
{
if (item is null)
    return Results.BadRequest(new { error = $"The object is not a {nameof(Person)} type." });

    var result = await ApplicationController.ApiController.People.Post(item);

    if (result is null)
        return Results.BadRequest(new { error = $"An error has occurred while trying to save the object." });

    return Results.Created($"/people/{result.Id}", result);
});
group.MapPut("/:id", async ([FromBody] Person? item, [FromRoute] uint? id) =>
{
    if(item is null)
        return Results.BadRequest(new { error = $"The object is not a {nameof(Person)} type." });

    id ??= item?.Id;

    if (!id.HasValue || id <= 0)
        return Results.BadRequest(new { error = $"No ID was passed as parameter nor was found in the object." });

    var result = await ApplicationController.ApiController.People.Put(id.Value, item);

    return result ? Results.Ok(result) : Results.NotFound(new { error = $"the ID {id} was not found in the records" });
});
group.MapDelete("/:id", async ([FromRoute] uint? id) =>
{
    if (!id.HasValue)
        return Results.BadRequest(new { error = $"An id has to be declared in the url in order to delete a record."});

    var result = await ApplicationController.ApiController.People.Delete(id.Value);

    return result ? Results.Ok(result) : Results.NotFound(new { error = $"The object with the ID {id} was no found in this route." });
});

var env = Env.Load("../../SolutionItems/.env");
var host = env.FirstOrDefault(x => x.Key.Equals("COMMAND_HOST")).Value;
int.TryParse(env.FirstOrDefault(x => x.Key.Equals("COMMAND_HOST")).Value, out var port);
app.Run($"{host}:{port}");
