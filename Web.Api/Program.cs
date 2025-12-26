using System.Reflection;
using Application.Mapper;
using Domain.Entity;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Configurations;
using Web.Api.MiddleWare;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services
    .AddDbConfiguration(builder.Configuration)
    .AddValidatorConfigurations()
    .AddAuthConfiguration(builder.Configuration)
    .AddSwaggerGen(opt =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        opt.IncludeXmlComments(xmlPath);
    });


builder.Services.AddControllers(options => { options.Filters.Add<ValidationModelFilter>(); });
builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });


var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();


using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

    foreach (Roles role in Enum.GetValues(typeof(Roles)))
    {
        var roleName = role.ToRoleName();
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new ApplicationRole { Name = roleName });
        }
    }
}

app.UseStaticFiles();
app.UseCors("All");

app.UseSwagger();
app.UseSwaggerUI(c => { c.InjectStylesheet("/swagger-custom.css"); });

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();