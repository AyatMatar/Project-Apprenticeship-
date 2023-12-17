using FinalProject.Data;
using FinalProject.Data.Entites;
using FinalProject.Repsitories.Abstract;
using FinalProject.Repsitories.AdmanStudent;
using FinalProject.Repsitories.ApprenticeshipRepsitories.Abstract;
using FinalProject.Repsitories.ApprenticeshipRepsitories.Implemintation;
using FinalProject.Repsitories.ApprenticObjectivecRepsitories.Abstract;
using FinalProject.Repsitories.CompanyRepsitories.Abstract;
using FinalProject.Repsitories.CompanyRepsitories.Implemintation;
using FinalProject.Repsitories.Implemintation;
using FinalProject.Repsitories.LeaderRepsitories;
using FinalProject.Repsitories.ObjectivecRepsitories.Abstract;
using FinalProject.Repsitories.ObjectivecRepsitories.Implemintation;
using FinalProject.Repsitories.StudentRepsitories.Abstract;
using FinalProject.Repsitories.StudentRepsitories.Implemintation;
using FinalProject.Repsitories.TeamLeaderRepsitories.Abstract;
using FinalProject.Repsitories.UniversitySupervisorRepsitories.Abstract;
using FinalProject.Repsitories.UniversitySupervisorRepsitories.Implemintation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Person>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = true,
    PositionClass = ToastPositions.TopRight,
    PreventDuplicates = true,
    CloseButton = true
});

builder.Services.AddTransient<IStudentRepsitories, StudentRepsitories>();
builder.Services.AddTransient<ICompanyRepsitories,CompanyRepsitories>();
builder.Services.AddTransient<ITeamLeaderRepsitories,TeamLeaderRepsitories>();
builder.Services.AddTransient<IUniversityRepsitories,UniversityRepsitories>();
builder.Services.AddTransient<ISupervisorRepsitories, SupervisorRepsitories>();
builder.Services.AddTransient<IApprenticeshipRepsitories, ApprenticeshipRepsitories>();
builder.Services.AddTransient<IObjectivecRepsitories,ObjectivecRepsitories>();
builder.Services.AddTransient<IApprenticObjectivecRepsitories, ApprenticObjectivecRepsitories>();
builder.Services.AddTransient<ILeaderRepsitories, LeaderRepsitories>();
builder.Services.AddTransient<IAdmanStudent, AdmanStudent>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
