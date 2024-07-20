using api.Data;
using api.Interfaces;
using api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers().AddNewtonsoftJson(
    options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    }
);
//SQLCOnnections
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRespository, TeacherRespository>();
builder.Services.AddScoped<IStreamRepository, StreamRepository>();
builder.Services.AddScoped<ISubjectRespository, SubjectRespository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

