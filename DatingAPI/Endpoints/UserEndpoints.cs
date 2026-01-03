using DatingAPI.Data;
using DatingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapGet("/api/users", async (AppDatabaseContext db) =>
                await db.Users.ToListAsync());

            app.MapGet("/api/users/{id:int}", async (int id, AppDatabaseContext db) =>
            {
                var user = await db.Users.FindAsync(id);
                return user is not null ? Results.Ok(user) : Results.NotFound();
            });

            app.MapPost("/api/users", async (User user, AppDatabaseContext db) =>
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return Results.Created($"/api/users/{user.Id}", user);
            });

            app.MapPut("/api/users/{id:int}", async (int id, User updatedUser, AppDatabaseContext db) =>
            {
                var user = await db.Users.FindAsync(id);
                if (user is null) 
                    return Results.NotFound();

                user.Name = updatedUser.Name;
                user.Description = updatedUser.Description;
                user.Age = updatedUser.Age;
                user.Latitude = updatedUser.Latitude;
                user.Longitude = updatedUser.Longitude;

                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            app.MapDelete("/api/users/{id:int}", async (int id, AppDatabaseContext db) =>
            {
                var user = await db.Users.FindAsync(id);
                if (user is null) 
                    return Results.NotFound();

                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}