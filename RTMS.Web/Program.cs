using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using RTMS.Plugins.PostgreEFCore;
using RTMS.UseCases.ActiveWorkouts;
using RTMS.UseCases.ActiveWorkouts.Interfaces;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts;
using RTMS.UseCases.Workouts.Interfaces;
using RTMS.UseCases.WorkoutTemplates;
using RTMS.UseCases.WorkoutTemplates.Interfaces;
using RTMS.Web.Components;
using RTMS.Web.MappingProfiles;
using RTMS.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
});

builder.Services.AddDbContextFactory<RTMSDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("RTMSDB"));
});

builder.Services.AddSingleton<IWorkoutTemplateRepository, WorkoutTemplateRepositoryPostgreEFCore>();
builder.Services.AddSingleton<IWorkoutHistoryRepository, WorkoutHistoryRepositoryPostgreEFCore>();

builder.Services.AddTransient<IAddWorkoutTemplateUseCase, AddWorkoutTemplateUseCase>();
builder.Services.AddTransient<IEditWorkoutTemplateUseCase, EditWorkoutTemplateUseCase>();
builder.Services.AddTransient<IViewWorkoutTemplatesByUserIdUseCase, ViewWorkoutTemplatesByUserIdUseCase>();
builder.Services.AddTransient<IViewWorkoutTemplateUseCase, ViewWorkoutTemplateByIdUseCase>();
builder.Services.AddTransient<IDeleteWorkoutTemplateUseCase, DeleteWorkoutTemplateUseCase>();

builder.Services.AddTransient<IAddWorkoutUseCase, AddWorkoutUseCase>();
builder.Services.AddTransient<IViewActiveWorkoutByIdUseCase, ViewActiveWorkoutByIdUseCase>();
builder.Services.AddTransient<IEndWorkoutUseCase, EndWorkoutUseCase>();
builder.Services.AddTransient<IViewWorkoutHistoryByUserIdUseCase, ViewWorkoutHistoryByUserIdUseCase>();

builder.Services.AddSingleton<UserContextService>();

// Configure AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<WorkoutTemplateToWorkoutTemplateViewModelMappingProfile>();
    cfg.AddProfile<WorkoutTemplateViewModelToWorkoutTemplateMappingProfile>();
});

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

app.MapGet("/Account/Login", async (HttpContext httpContext, string returnUrl = "/") =>
{
    var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(returnUrl)
            .Build();

    await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("/Account/Logout", async (HttpContext httpContext) =>
{
    var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
            .WithRedirectUri("/")
            .Build();

    await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();