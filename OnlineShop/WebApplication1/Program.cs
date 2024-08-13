
using FluentMigrator.Runner;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Records;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            var a = builder.Configuration.GetConnectionString("SvitlanaL");

            var datAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(x => x.GetName().Name == "OnlineShop.Data");

            //builder.Services.AddTransient<SuppliersService>(x => new SuppliersService(new DapperContext(), new ActivityLogService()));
            builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb.AddSqlServer2012()
                    .WithGlobalConnectionString(a)
                    .ScanIn(datAssembly).For.Migrations());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            //app.Use(async (context, func) => 
            //{
            //    await func();
            //    await context.Response.WriteAsync("Hello1");

            //});

            //app.Use(async (context, func) =>
            //{
            //    await context.Response.WriteAsync("Hello2");
            //    await func();
            //    await context.Response.WriteAsync("Hello3");

            //});

            app.MapGet("/get", () => "Hello World!");

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from 2nd delegate.");
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from 1 delegate.");
            //});

            app.Run();
        }
    }
}
