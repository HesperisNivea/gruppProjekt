using DataAccess;
using Microsoft.EntityFrameworkCore;
using Övning.API.extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    "Data Source=DX13_IR\\SQL_DEV; Database= Bokstore; Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

builder.Services.AddSingleton<BookService>();
builder.Services.AddSingleton<AuthorService>();


builder.Services.AddDbContext<BooksDBContext>(
    options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapBookEndpoints();
app.MapAuthorEndpoints();

app.Run();

