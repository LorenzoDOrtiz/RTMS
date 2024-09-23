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
using RTMS.UseCases.Reports;
using RTMS.UseCases.Reports.Interfaces;
using RTMS.UseCases.Users;
using RTMS.UseCases.Users.Interfaces;
using RTMS.UseCases.WorkoutHistory;
using RTMS.UseCases.WorkoutHistory.Interfaces;
using RTMS.UseCases.Workouts;
using RTMS.UseCases.Workouts.Interfaces;
using RTMS.UseCases.WorkoutTemplates;
using RTMS.UseCases.WorkoutTemplates.Interfaces;
using RTMS.Web.Components;
using RTMS.Web.MappingProfiles;
using RTMS.Web.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables();

    builder.Services.AddHttpsRedirection(options =>
    {
        options.HttpsPort = 443;
    });
}

builder.Services.AddRazorComponents()
.AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0__Domain"];
    options.ClientId = builder.Configuration["Auth0__ClientId"];
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
    var managementApiToken = builder.Configuration["Auth0__ManagementApiToken"];
    var managementApiUrl = new Uri("https://dev-njjrui7wcq7kliho.us.auth0.com/api/v2/");
    return new ManagementApiClient(managementApiToken, managementApiUrl);
});

// Register Auth0UserService
builder.Services.AddSingleton(sp =>
{
    var managementClient = sp.GetRequiredService<ManagementApiClient>();
    var httpClient = sp.GetRequiredService<HttpClient>();
    var getOrCreateUserUseCase = sp.GetRequiredService<IGetOrCreateUserUseCase>();
    var auth0Domain = builder.Configuration["Auth0__Domain"];
    var clientId = builder.Configuration["Auth0__ClientId"];
    return new Auth0UserService(managementClient, httpClient, getOrCreateUserUseCase, auth0Domain, clientId);
});

builder.Services.AddDbContextFactory<RTMSDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration["AZURE__POSTGRESQL__CONNECTIONSTRING"]);
});

builder.Services.AddBlazoredLocalStorage();

// Logging 
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/rtms.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

// Services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<WorkoutTimerService>();
builder.Services.AddScoped<RestTimerService>();
builder.Services.AddSingleton<ActiveWorkoutService>();

// Repositories
builder.Services.AddSingleton<IWorkoutTemplateRepository, WorkoutTemplateRepositoryPostgreEFCore>();
builder.Services.AddSingleton<IWorkoutHistoryRepository, WorkoutHistoryRepositoryPostgreEFCore>();
builder.Services.AddSingleton<IUserRepositoryPostgreEFCore, UserRepositoryPostgreEFCore>();

// Templates
builder.Services.AddTransient<IAddWorkoutTemplateUseCase, AddWorkoutTemplateUseCase>();
builder.Services.AddTransient<IEditWorkoutTemplateUseCase, EditWorkoutTemplateUseCase>();
builder.Services.AddTransient<IViewWorkoutTemplatesByUserIdUseCase, ViewWorkoutTemplatesByUserIdUseCase>();
builder.Services.AddTransient<IViewWorkoutTemplateByIdUseCase, ViewWorkoutTemplateByIdUseCase>();
builder.Services.AddTransient<IDeleteWorkoutTemplateUseCase, DeleteWorkoutTemplateUseCase>();
builder.Services.AddTransient<IAddClientWorkoutTemplateUseCase, AddClientWorkoutTemplateUseCase>();
builder.Services.AddTransient<IViewClientWorkoutTemplatesUseCase, ViewClientWorkoutTemplatesUseCase>();
builder.Services.AddTransient<IRemoveTrainerTemplateFromClientUseCase, RemoveTrainerTemplateFromClientUseCase>();
builder.Services.AddTransient<IGetWorkoutTemplatesWithAtLeastTwoWorkoutsUseCase, GetWorkoutTemplatesWithAtLeastTwoWorkoutsUseCase>();

// Active Workouts
builder.Services.AddTransient<IAddWorkoutUseCase, AddWorkoutUseCase>();
builder.Services.AddTransient<IGetActiveWorkoutByUserIdUseCase, GetActiveWorkoutByUserIdUseCase>();
builder.Services.AddTransient<IViewActiveWorkoutByWorkoutAndUserIdUseCase, ViewActiveWorkoutByWorkoutAndUserIdUseCase>();
builder.Services.AddTransient<IEndWorkoutUseCase, EndWorkoutUseCase>();

// Workout History
builder.Services.AddTransient<IViewWorkoutHistoryByUserIdUseCase, ViewWorkoutHistoryByUserIdUseCase>();
builder.Services.AddTransient<IGetDetailedWorkoutHistoryByWorkoutIdUseCase, GetDetailedWorkoutHistoryByWorkoutIdUseCase>();
builder.Services.AddTransient<IGetDetailedWorkoutHistoryByTemplateIdUseCase, GetDetailedWorkoutHistoryByTemplateIdUseCase>();
builder.Services.AddTransient<IGetDetailedExerciseHistoryByTemplateIdUseCase, GetDetailedExerciseHistoryByTemplateIdUseCase>();
builder.Services.AddTransient<IGetExerciseTemplatesWithAtLeastTwoExercisesUseCase, GetExerciseTemplatesWithAtLeastTwoExercisesUseCase>();

// User
builder.Services.AddTransient<IGetOrCreateUserUseCase, GetOrCreateUserUseCase>();
builder.Services.AddTransient<IAddTrainerClientRelationshipUseCase, AddTrainerClientRelationshipUseCase>();
builder.Services.AddTransient<IGetUserIdByAuth0IdUseCase, GetUserIdByAuth0IdUseCase>();
builder.Services.AddTransient<IGetUserIdsByAuth0IdsUseCase, GetUserIdsByAuth0IdsUseCase>();
builder.Services.AddTransient<IGetAuth0UserIdsByUserIdsUseCase, GetAuth0UserIdsByUserIdsUseCase>();
builder.Services.AddTransient<IGetTrainerIdsByUserIdUseCase, GetTrainerIdsByUserIdUseCase>();
builder.Services.AddTransient<IUpdateClientTrainersUseCase, UpdateClientTrainersUseCase>();
builder.Services.AddTransient<IGetClientsAssignedToTrainerUseCase, GetClientsAssignedToTrainerUseCase>();
builder.Services.AddTransient<IRemoveClientFromTrainerUseCase, RemoveClientFromTrainerUseCase>();
builder.Services.AddTransient<IDeleteUserUseCase, DeleteUserUseCase>();

// Reports 
builder.Services.AddTransient<IGetAllDetailedWorkoutDataByUserId, GetAllDetailedWorkoutDataByUserId>();

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

app.MapGet("/Account/Login", async (HttpContext httpContext, string returnUrl = "/dashboard") =>
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