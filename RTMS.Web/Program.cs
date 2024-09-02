using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using RTMS.Plugins.SqlServer;
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
using RTMS.Web.Components.Account;
using RTMS.Web.Data;
using RTMS.Web.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

var identityConnectionString = builder.Configuration.GetConnectionString("RTMSIdentity") ?? throw new InvalidOperationException("Connection string 'RTMSIdentity' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(identityConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddMudServices();

builder.Services.AddAutoMapper(typeof(WorkoutTemplateViewModelToWorkoutTemplateMappingProfile),
    typeof(WorkoutTemplateToWorkoutTemplateViewModelMappingProfile));

string rtmsConnectionString = builder.Configuration.GetConnectionString("RTMS") ?? throw new InvalidOperationException("Connection string 'RTMS' not found.");
builder.Services.AddSingleton(new SqlConnectionFactory(rtmsConnectionString));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<IWorkoutTemplateRepository, WorkoutTemplateRepositorySqlServer>();
    builder.Services.AddSingleton<IActiveWorkoutRepository, ActiveWorkoutRepositorySqlServer>();
    builder.Services.AddSingleton<IWorkoutHistoryRepository, WorkoutHistoryRepositorySqlServer>();
}

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

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
