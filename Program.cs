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


var app = builder.Build();

// var optionsBuilder = new DbContextOptionsBuilder();
// optionsBuilder.UseNpgsql(
//     builder.Configuration.GetConnectionString("DefaultConnection"),
//     npgsqlOptions => npgsqlOptions.SetPostgresVersion(17, 2)
// );
// var loader = new DBResourceLoader2(optionsBuilder.Options);
// loader.LoadInitialCharData();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
