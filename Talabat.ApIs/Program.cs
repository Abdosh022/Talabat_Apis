using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Talabat.Repository.Data;

namespace Talabat.ApIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //StoreContext dbcontext = new /*StoreContext();*/

            //await dbcontext.Database.MigrateAsync(); //ubdate database


            var builder = WebApplication.CreateBuilder(args);            


            #region Configure_Servies
            // Add services to the DI container.


            builder.Services.AddControllers();

            // register web apis servicies to the DI container.
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
            });   

            #endregion

            

            var app = builder.Build();

            using var scope = app.Services.CreateScope();

            var services= scope.ServiceProvider;

            var _dbcontext= services.GetRequiredService<StoreContext>();

            // ask clr for create an objext from dbcontext exiplictly
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbcontext.Database.MigrateAsync(); //update database

                 await StoreContextSeed.SeedAsync(_dbcontext);

            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error has been occured during apply migration");
            }
            


            #region Cofigure Kestral Web Middleares  
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
             
            app.UseAuthorization();

            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}