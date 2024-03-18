using RainfallApi.Controllers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient<RainfallApiClient>(client =>
{
    client.BaseAddress = new Uri("https://environment.data.gov.uk/");
});
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rainfall API"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();