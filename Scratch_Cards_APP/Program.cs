using Scratch_Cards_APP.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// builder.Services.AddScoped<ScratchCardsService>();
builder.Services.AddHttpClient<ScratchCardsService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7163/api");

    // client.BaseAddress = new Uri(builder.Configuration.GetSection("ScratchCardsSettings:BaseUrl").Value!);
});

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
