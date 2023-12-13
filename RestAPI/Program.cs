using Microsoft.AspNetCore.Hosting;
using RestAPI.Models;
using RestAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDBService>();
builder.Services.AddLogging();


 

    
  builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders(); // Clear other logging providers
    logging.AddConsole(); // Add the console logging provider
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
     app.UseDeveloperExceptionPage();
 }
        else 
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
app.Use(async (context, next) =>
{
    // Log request information
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
    logger.LogInformation($"Request: {context.Request.Path} {context.Request.Method}");

    // Call the next middleware in the pipeline
    await next.Invoke();
});
app.UseCors(options =>
{
     options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
