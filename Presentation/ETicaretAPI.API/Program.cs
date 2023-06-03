using ETicaretAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistanceServices();

// Cors Politikas�
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200" , "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Cors Politikas�n�n uygulamada middle ware olarak i�lemesini sa�l�yoruz
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
