using BubberDinner.Api;
using BubberDinner.Application;
using BubberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    #region Architecture Layer
    {
        builder.Services.AddPresentation();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
    }
    #endregion
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    {
        #region Authorizatuion / Authentication Middleware
        app.UseAuthentication();
        app.UseAuthorization();
        #endregion
    }

    app.MapControllers();
    app.Run();

}