using CreditCalculator.Services.Calculator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddSingleton<CalculatorService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}");
});
app.Run();