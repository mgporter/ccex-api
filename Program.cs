using ccex_api.Data;
using ccex_api.Init;
using ccex_api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(optionsBuilder => {

    optionsBuilder
        .UseNpgsql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            npgsqlOptions => npgsqlOptions
                .SetPostgresVersion(17, 2)
                .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
        )
        .UseSeeding((context, _) => DBResourceLoader.LoadInitialCharData(context));

});

builder.Services.AddScoped<IChineseCharacterRepository, ChineseCharacterRepository>();
builder.Services.AddScoped<IPinyinRepository, PinyinRepository>();

string CORSPOLICY_AllowDevServer = "AllowDevServer";
builder.Services.AddCors(options => 
{
    options.AddPolicy(
        CORSPOLICY_AllowDevServer,
        policy => policy.WithOrigins(
            "http://localhost:5173", 
            "http://192.168.50.239:5173",
            "http://localhost:4173", 
            "http://192.168.50.239:4173"
        )
    );
});

// "Microsoft.EntityFrameworkCore.Database.Command": "Warning"

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}


app.UseMiddleware<RequestLoggingMiddleware>();

app.UseHttpsRedirection();



app.UseCors(CORSPOLICY_AllowDevServer);

app.MapControllers();

app.Run();
