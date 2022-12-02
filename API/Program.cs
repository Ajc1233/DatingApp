using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//The opt are the options we receive from the DataContext method, we will then use the lambda expression to create an
//anonymous function
//*The type DataContext comes from the class we created that holds the getter and setter for the user (id, name)
builder.Services.AddDbContext<DataContext>(opt =>
{
    //The DefaultConnection comes from the appsettings development json file 
    //*"DefaultConnection": "Data source=datingapp.db "
    //The string is the connection String
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();

var app = builder.Build();

//configure the HTTP request pipeline
app.UseCors((builder) => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));


// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
