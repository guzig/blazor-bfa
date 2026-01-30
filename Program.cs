using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBFA;
using BlazorBFA.ViewModels;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Radzen services
builder.Services.AddRadzenComponents();

// ViewModels
builder.Services.AddScoped<TestimonialsViewModel>();
builder.Services.AddScoped<ProjectsViewModel>();
builder.Services.AddScoped<FooterViewModel>();
builder.Services.AddScoped<FeaturesViewModel>();
builder.Services.AddScoped<ServicesViewModel>();
builder.Services.AddScoped<AboutViewModel>();
builder.Services.AddScoped<HeroViewModel>();
builder.Services.AddScoped<NavbarViewModel>();
builder.Services.AddScoped<ContactViewModel>();

// Add services here if needed
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
