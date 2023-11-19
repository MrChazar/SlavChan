using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SlavChanAPP.BackgroundServices;
using SlavChanAPP.DataBaseContext;
using SlavChanAPP.Repositories;
using Thread = SlavChanAPP.Models.Subject;

//using SlavChanAPP.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container for Dependency Inversion
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IPictureRepository, PictureRepository>();
builder.Services.AddScoped<IReplyRepository, ReplyRepository>();

builder.Services.AddTransient<ISubjectRepository, SubjectRepository>();
builder.Services.AddTransient<IReplyRepository, ReplyRepository>();

builder.Services.AddHostedService<DataBackground>();



// Setting up file size limits for our form
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = int.MaxValue;
    options.ValueLengthLimit = int.MaxValue;
    options.MemoryBufferThreshold = int.MaxValue;
});

// Add Database
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SlavChanDBContext")));

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
