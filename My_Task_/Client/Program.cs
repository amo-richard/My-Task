using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using My_Task_.Client;
using My_Task_.Client.Shared;
using My_Task_.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("My_Task_.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("My_Task_.ServerAPI"));
builder.Services.AddScoped<DatabaseContent>();
builder.Services.AddScoped<ShowAddTask>();
builder.Services.AddScoped<CreateTask>();
await builder.Build().RunAsync();
