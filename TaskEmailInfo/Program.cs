using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Refit;
using TaskEmailInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => 
    options.AddPolicy("AllowAll", policy => 
        policy.AllowAnyOrigin()
        .WithMethods("Get", "Post")
        .AllowAnyHeader()
    )
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/email_info", () =>
{
    EmailInfo emailInfo = new()
    {
        RegisteredMail = "abdullahiyusuf182@gmail.com", 
        CurrentDate = DateTime.UtcNow.ToString("o"), 
        GitHubUrl = ""
    };
    return Results.Ok(emailInfo);
})
.WithName("GetEmailInfo")
.WithOpenApi();

app.Run();

