using imobiliaria.Data;
using imobiliaria.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ProprietarioService>();
builder.Services.AddScoped<InquilinoService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<ImovelService>();
builder.Services.AddScoped<ContratoService>();

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseMySql(builder.Configuration.GetConnectionString("ImobiliariaConnection"), new MySqlServerVersion(new Version(8,0))));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
