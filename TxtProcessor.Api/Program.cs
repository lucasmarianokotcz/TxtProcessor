using Microsoft.AspNetCore.Mvc;
using TxtProcessor.Core.Processing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/analyze", ([FromBody] TextRequest request) =>
{
    var result = TextAnalyzer.AnalyzeText(request.Text);
    return Results.Ok(result);
});

app.Run();

internal record TextRequest(string Text);