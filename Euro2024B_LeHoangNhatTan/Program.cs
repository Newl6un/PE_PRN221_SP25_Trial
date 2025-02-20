using Euro2024B_LeHoangNhatTan.DataAccessObject;
using Euro2024B_LeHoangNhatTan.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<Euro2024BContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
});
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IGroupTeamRepository, GroupTeamRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.Run();
