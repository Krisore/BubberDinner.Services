using BubberDinner.Application;
using BubberDinner.Infrastructure;
var builder = WebApplication.CreateBuilder(args);
{
    #region Architecture Layer
    {
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
    }
    #endregion

    builder.Services.AddControllers();

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}