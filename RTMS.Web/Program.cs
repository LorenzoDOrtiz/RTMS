using MudBlazor.Services;
using RTMS.Plugins.InMemory;
using RTMS.Services;
using RTMS.Services.Interfaces;
using RTMS.UseCases.ActiveWorkouts;
using RTMS.UseCases.ActiveWorkouts.Interfaces;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts;
using RTMS.UseCases.Workouts.Interfaces;
using RTMS.UseCases.WorkoutTemplates;
using RTMS.UseCases.WorkoutTemplates.Interfaces;
using RTMS.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddSingleton<IWorkoutTemplateRepository, WorkoutTemplateRepository>();
builder.Services.AddSingleton<IWorkoutRepository, WorkoutRepository>();

builder.Services.AddScoped<IActiveWorkoutService, ActiveWorkoutService>();

builder.Services.AddTransient<IAddWorkoutTemplateUseCase, AddWorkoutTemplateUseCase>();
builder.Services.AddTransient<IEditWorkoutTemplateUseCase, EditWorkoutTemplateUseCase>();
builder.Services.AddTransient<IViewWorkoutTemplatesByUserIdUseCase, ViewWorkoutTemplatesByUserIdUseCase>();
builder.Services.AddTransient<IViewWorkoutTemplateUseCase, ViewWorkoutTemplateByIdUseCase>();
builder.Services.AddTransient<IDeleteWorkoutTemplateUseCase, DeleteWorkoutTemplateUseCase>();

builder.Services.AddTransient<IAddActiveWorkoutUseCase, AddActiveWorkoutUseCase>();
builder.Services.AddTransient<IViewActiveWorkoutByIdUseCase, ViewActiveWorkoutByIdUseCase>();
builder.Services.AddTransient<IEndActiveWorkoutUseCase, EndActiveWorkoutUseCase>();
builder.Services.AddTransient<IViewWorkoutHistoryByUserIdUseCase, ViewWorkoutHistoryByUserIdUseCase>();

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
