using VF.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDependencyInjection(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
//app.UseHttpsRedirection();
app.Run("http://0.0.0.0:5000");