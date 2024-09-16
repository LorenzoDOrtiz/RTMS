using Auth0.AspNetCore.Authentication;
using Auth0.ManagementApi;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using RTMS.Plugins.PostgreEFCore;
using RTMS.UseCases.ActiveWorkouts;
using RTMS.UseCases.ActiveWorkouts.Interfaces;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Users;
using RTMS.UseCases.Users.Interfaces;
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
    options.Scope = "openid profile email"; // Add the email scope
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Admin", policy => policy.RequireRole("Admin"))
    .AddPolicy("Trainer", policy => policy.RequireRole("Trainer"))
    .AddPolicy("Client", policy => policy.RequireRole("Client"));

// Register HttpClient
builder.Services.AddHttpClient();

// Register ManagementApiClient
builder.Services.AddSingleton(sp =>
{
    var managementApiToken = builder.Configuration["Auth0:ManagementApiToken"];
    var managementApiUrl = new Uri("https://dev-njjrui7wcq7kliho.us.auth0.com/api/v2/");
    return new ManagementApiClient(managementApiToken, managementApiUrl);
});

// Register Auth0UserService
builder.Services.AddSingleton(sp =>
{
    var managementClient = sp.GetRequiredService<ManagementApiClient>();
    var httpClient = sp.GetRequiredService<HttpClient>();
    var auth0Domain = builder.Configuration["Auth0:Domain"];
    var clientId = builder.Configuration["Auth0:ClientId"];
    return new Auth0UserService(managementClient, httpClient, auth0Domain, clientId);
});

builder.Services.AddDbContextFactory<RTMSDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("RTMSDB"));
});

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<WorkoutTimerService>();
builder.Services.AddScoped<RestTimerService>();
builder.Services.AddSingleton<ActiveWorkoutService>();

builder.Services.AddSingleton<IWorkoutTemplateRepository, WorkoutTemplateRepositoryPostgreEFCore>();
builder.Services.AddSingleton<IWorkoutHistoryRepository, WorkoutHistoryRepositoryPostgreEFCore>();
builder.Services.AddSingleton<IUserRepositoryPostgreEFCore, UserRepositoryPostgreEFCore>();

builder.Services.AddTransient<IAddWorkoutTemplateUseCase, AddWorkoutTemplateUseCase>();
builder.Services.AddTransient<IEditWorkoutTemplateUseCase, EditWorkoutTemplateUseCase>();
builder.Services.AddTransient<IViewWorkoutTemplatesByUserIdUseCase, ViewWorkoutTemplatesByUserIdUseCase>();
builder.Services.AddTransient<IViewWorkoutTemplateByIdUseCase, ViewWorkoutTemplateByIdUseCase>();
builder.Services.AddTransient<IDeleteWorkoutTemplateUseCase, DeleteWorkoutTemplateUseCase>();

builder.Services.AddTransient<IAddWorkoutUseCase, AddWorkoutUseCase>();
builder.Services.AddTransient<IGetActiveWorkoutByUserIdUseCase, GetActiveWorkoutByUserIdUseCase>();
builder.Services.AddTransient<IViewActiveWorkoutByWorkoutAndUserIdUseCase, ViewActiveWorkoutByWorkoutAndUserIdUseCase>();
builder.Services.AddTransient<IEndWorkoutUseCase, EndWorkoutUseCase>();
builder.Services.AddTransient<IViewWorkoutHistoryByUserIdUseCase, ViewWorkoutHistoryByUserIdUseCase>();

builder.Services.AddTransient<IGetOrCreateUserUseCase, GetOrCreateUserUseCase>();

// Configure AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<WorkoutTemplateToWorkoutMappingProfile>();
    cfg.AddProfile<WorkoutTemplateToWorkoutTemplateViewModelMappingProfile>();
    cfg.AddProfile<WorkoutTemplateViewModelToWorkoutTemplateMappingProfile>();

    cfg.AddProfile<WorkoutToWorkoutTemplateMappingProfile>();
    cfg.AddProfile<WorkoutToWorkoutViewModelMappingProfile>();
    cfg.AddProfile<WorkoutViewModelToWorkoutMappingProfile>();
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