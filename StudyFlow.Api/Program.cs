using Microsoft.EntityFrameworkCore;
using StudyFlow.Api.Data;
using StudyFlow.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StudyFlowContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudyFlowConnection")));

builder.Services.AddScoped<MateriaService>();
builder.Services.AddScoped<TarefaService>();
builder.Services.AddScoped<SessaoEstudoService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//ADICIONEI ESSE SERVIÇO, PRA PERMITIR A COMUNICAÇÃO ENTRO O BACK E O FRONT JÁ QUE AS PORTAS SÃO DIFERENTES E ESTA DANDO CONFLITO
//AddCors: REGISTRA O SERVIÇO CORS
//AddPolicy(): Cria uma politica para o Angular
//WithOrigins(): DEFINI AS ORIGENS PERMITIDAS PARA ACESSO
//AllowAnyHeader(): Permite diferentes cabeçados do HTTP
//AllowAnyMethod(): Permite os métodos do HTTP
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularLocal", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//ADICIONA O MIDDLEWARE QUE APLICA A NOVA POLITICA AS REQUISIÇÕES
app.UseCors("AngularLocal");

app.UseAuthorization();

app.MapControllers();

app.Run();
