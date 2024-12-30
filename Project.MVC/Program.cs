using Microsoft.EntityFrameworkCore;
using Project.MVC;

var builder = WebApplication.CreateBuilder(args);

// Veri taban� ba�lant�s�:
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

// A��l��ta otomatik a��lmas� i�in:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ogrenci}/{action=Index}/{id?}"
);

app.Run();
