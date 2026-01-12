using Iyde.Attendance.Variant3.Data;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Iyde.Attendance.Variant3.Repositories.Implementations;
using Iyde.Attendance.Variant3.Services.Interfaces;
using Iyde.Attendance.Variant3.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Iyde.Attendance.Variant3.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null
            );
        }
    ));

// repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IWorkDayRepository, WorkDayRepository>();
builder.Services.AddScoped<IAttendanceEarlyAttemptRepository, AttendanceEarlyAttemptRepository>();



// services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
builder.Services.AddScoped<IAttendanceEarlyAttemptService,AttendanceEarlyAttemptService>();
builder.Services.AddScoped<IWorkDayService, WorkDayService>();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();