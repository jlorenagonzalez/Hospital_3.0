using Hospital_2._0.Context;
using Hospital_2._0.Repositories;
using Hospital_2._0.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration.GetConnectionString("ConnectionBD");
builder.Services.AddDbContext<PatientDbContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<OccupationContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<DoctorContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<ResourceContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<TreatmentContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<BedContext>(Options => Options.UseSqlServer(ConnectionString));


#region Repositories
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IOccupationRepository, OccupationRepository>();
builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<IBedRepository, BedsRepository>();
#endregion


#region Service
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IOccupationService, OccupationService>();
builder.Services.AddScoped<ITreatmentService, TreatmentService>();
builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddScoped<IBedService, BedService>();
#endregion


// Add services to the container.

builder.Services.AddControllers();
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
