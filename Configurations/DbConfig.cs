using Microsoft.EntityFrameworkCore;

namespace dotnetcoreWebAPI.Configurations;

public static class DbConfig
{
    public static void AddDb(this WebApplicationBuilder app)
    {
        var configSection = app.Configuration.GetRequiredSection("dbcontext");
        var dbOptions = configSection.Get<DbOptions>();

        if (dbOptions.isInMemory)
        {
            app.Services.AddDbContext<dotnetcoreWebAPI.infrastructure.BookDbContext>
                (options => options.UseInMemoryDatabase(nameof(infrastructure.BookDbContext)));
        }
        else
        {
            var encruptedConnectionString = Helper.Cryptography.Decrypt(dbOptions.connectionString);

            app.Services.AddDbContext<dotnetcoreWebAPI.infrastructure.BookDbContext>
            (db => db.UseSqlServer(encruptedConnectionString, sqlServerOptionsAction =>
            {
                sqlServerOptionsAction.EnableRetryOnFailure
                (
                    maxRetryCount: dbOptions.MaxRetryCount,
                    maxRetryDelay: dbOptions.MaxRetryDelay,
                    errorNumbersToAdd: null
                );
            }), ServiceLifetime.Scoped);
        }
    }
}
