using MudBlazor.Services;
using RTMS.Plugins.InMemory;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates;
using RTMS.UseCases.WorkoutTemplates.Interfaces;
using RTMS.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddSingleton<IWorkoutTemplateRepository, WorkoutTemplateRepository>();

builder.Services.AddTransient<IAddWorkoutTemplateUseCase, AddWorkoutTemplateUseCase>();
builder.Services.AddTransient<IEditWorkoutTemlateUseCase, EditWorkoutTemlateUseCase>();
builder.Services.AddTransient<IViewWorkoutTemplatesByUserIdUseCase, ViewWorkoutTemplatesByUserIdUseCase>();
builder.Services.AddTransient<IViewWorkoutTemplateUseCase, ViewWorkoutTemplateUseCase>();
builder.Services.AddTransient<IDeleteWorkoutTemplateUseCase, DeleteWorkoutTemplateUseCase>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
