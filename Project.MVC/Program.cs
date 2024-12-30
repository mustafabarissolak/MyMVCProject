using Microsoft.EntityFrameworkCore;
using Project.MVC;

var builder = WebApplication.CreateBuilder(args);

// Veri tabaný baðlantýsý:
builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Açýlýþta otomatik açýlmasý için:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ogrenci}/{action=Index}/{id?}"
);

app.Run();
