using RiverBooks.Books;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add module Services 
builder.Services.AddBookServices(builder.Configuration);
builder.Services.AddFastEndpoints();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


//MapModuleEndPoints
app.MapBookEndpoints();
app.UseFastEndpoints();

app.Run();
