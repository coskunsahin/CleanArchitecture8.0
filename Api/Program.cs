using Serilog;
using System.Diagnostics;
using System.Configuration;
using Serilog.Sinks.MSSqlServer;
using Serilog.Formatting.Json;
using Kephas.Configuration;
using Serilog.Events;
using Serilog.Formatting.Compact;
namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        Log.Information("Starting web host");
        Log.Logger = new LoggerConfiguration()
     .WriteTo.Console(new JsonFormatter())
       .WriteTo.File(new JsonFormatter(), "log.txt")
       .MinimumLevel.Information().MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
       .Enrich.WithProcessName().Enrich.WithProcessName().Enrich.WithMachineName().Enrich.WithEnvironmentName().Enrich.WithThreadName().Enrich.WithThreadId()
       .WriteTo.Console(new CompactJsonFormatter())
     .WriteTo.MSSqlServer("Server=(localdb)\\coskun;Database=CleanArchitecdb;Trusted_Connection=True;MultipleActiveResultSets=true",
                          new MSSqlServerSinkOptions
                          {
                              TableName = "Logs",
                              SchemaName = "dbo",
                              AutoCreateSqlTable = true
                          })
     .CreateLogger();
        Log.Logger.Information("LOOGING  IS WORKING FINE");
        try
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration.WriteTo.Console();
                loggerConfiguration.ReadFrom.Configuration(context.Configuration);
            });


            builder.Services.AddRazorPages();

            

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddWebServices();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient("ApiService1", client =>
            {
                client.BaseAddress = new Uri("https://www.mhc.ab.ca/");
                // Diðer yapýlandýrma seçenekleri
            });

            builder.Services.AddHttpClient("ApiService2", client =>
            {
                client.BaseAddress = new Uri("https://www.mhc.ab.ca/");
                // Diðer yapýlandýrma seçenekleri
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //await app.InitialiseDatabaseAsync();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

           
            app.UseHsts();
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("https://www.mhc.ab.ca");
            //});


            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.MapFallbackToFile("index.html");

            app.UseExceptionHandler(options => { });



            app.UseSerilogRequestLogging();


            app.Run();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "server terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }

    }
}