using DataAccess;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MinimalApiUi.Extenstions
{
    public static class MapApis
    {
        public static void MapApi(this WebApplication app)
        {
            app.MapGet("/api/Person/", async (IPersonRepository personRepo) =>
            {
                var person = await personRepo.GetAll();
                return Results.Ok(person);
            });
            app.MapPost("/api/Person/", async (IPersonRepository personRepo, Person person) =>
            {
                var result = await personRepo.Add(person);
                if (result)
                    return Results.Ok("Save Successfully");
                return Results.Problem();
            });

            app.MapPut("/api/Person/", async (IPersonRepository personRepo, Person person) =>
            {
                var result = await personRepo.Update(person);
                if (result)
                    return Results.Ok("Update Successfully");
                return Results.Problem();
            });

            app.MapGet("/api/Person/{id}", async (IPersonRepository personRepo, int id) =>
            {
                var result = await personRepo.GetById(id);
                if (result is null)
                    return Results.NotFound();
                return Results.Ok(result);
            });


            app.MapDelete("/api/Person/{id}", async (IPersonRepository personRepo, int id) =>
            {
                var result = await personRepo.Delete(id);
                if (result)
                    return Results.Ok("Delete Successfully");
                return Results.Problem();
            });
        }
    }
}

