using IndustrialContoroler.Models;
//using IndustrialContoroler.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using IndustrialContoroler.permission;
using IndustrialContoroler.IRepository;
using IndustrialContoroler.Models.Repositories;
using IndustrialContoroler.Seeds;
using IndustrialContoroler.IRepository.RequestRepository;
using IndustrialContoroler.IRepository.AttachmentRepository;
using IndustrialContoroler.Models.Repositories.GenericRepositry;
using IndustrialContoroler.IRepository.RepositoryFildform;
using IndustrialContoroler.IRepository.RepositoryFildform.GenericRepositry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IndustrialContorolerDatabaseContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbconnection"))
    );
//Add identity
builder.Services.AddIdentity<AppUsers, IdentityRole>(options =>
{
    //this handel the password for accept number just or....
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<IndustrialContorolerDatabaseContext>();

//this the defult path for AccessDenied
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddControllersWithViews();


//if you make any edit in permission when you ran the applicatiion the edit not apple but this commmed will coreect it
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.Zero;
});

//Add session
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(80);
    //options.Cookie.HttpOnly = true;
    //options.Cookie.IsEssential = true;
});

//-------------------------------------------------------------


//Add Repository 

builder.Services.AddScoped<IServicesRepositoryLogRequeist<RequestTraffic>, ServiceGenericLogRequest>();
builder.Services.AddScoped<IServiceREpositoryRequest<Request>, ServicesRequest>();
builder.Services.AddScoped<IServiceRepositoryFieldVisitForms<Facility>, ServicesFieldVisitForms>();
builder.Services.AddScoped<IServicesRepositoryLogFieldVisitForms<LogFieldVisitForms>, ServiceLogFieldVisitFoems>();



builder.Services.AddScoped<IRepository<Temporary>, GenericRepositry<Temporary>>();
builder.Services.AddScoped<IRepository<Facility>, GenericRepositry<Facility>>();
builder.Services.AddScoped<IRepository<Building>, GenericRepositry<Building>>();
builder.Services.AddScoped<IRepository<Worker>, GenericRepositry<Worker>>();
builder.Services.AddScoped<IRepository<Machine>, GenericRepositry<Machine>>();
builder.Services.AddScoped<IRepository<RowMaterial>, GenericRepositry<RowMaterial>>();
builder.Services.AddScoped<IRepository<HelpMaterial>, GenericRepositry<HelpMaterial>>();
builder.Services.AddScoped<IRepository<Transportation>, GenericRepositry<Transportation>>();
builder.Services.AddScoped<IRepository<AgentsPoint>, GenericRepositry<AgentsPoint>>();
builder.Services.AddScoped<IRepository<ProCapacity>, GenericRepositry<ProCapacity>>();
builder.Services.AddScoped<IRepository<SafetySecurity>, GenericRepositry<SafetySecurity>>();
builder.Services.AddScoped<IRepository<RelevantDoc>, GenericRepositry<RelevantDoc>>();
builder.Services.AddScoped<IRepository<CastDatum>, GenericRepositry<CastDatum>>();
builder.Services.AddScoped<IRepository<VisitsTraffic>, GenericRepositry<VisitsTraffic>>();
builder.Services.AddScoped<IRepository<SiteReason>, GenericRepositry<SiteReason>>();
builder.Services.AddScoped<IRepository<SecondaryAct>, GenericRepositry<SecondaryAct>>();

builder.Services.AddScoped<IRequestRepository<Request>, RequestRepository<Request>>();
builder.Services.AddScoped<IAttachmentRepository<Attachment>, AttachmentRepository<Attachment>>();
builder.Services.AddScoped<IRepository<AttachmentType>, GenericRepositry<AttachmentType>>();


//this for permission
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");
//make the notification as Read
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "notification",
        pattern: "notification/{action=Index}/{id?}",
        defaults: new { controller = "Notification" });

    endpoints.MapControllerRoute(
        name: "MarkAsRead",
        pattern: "notification/MarkAsRead/{id}",
        defaults: new { controller = "Notification", action = "MarkAsRead" });
});
//make all filesRequstAndRejctIs read
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "Request",
//        pattern: "Request/{action=Index}/{id?}",
//        defaults: new { controller = "Request" });

//    endpoints.MapControllerRoute(
//        name: "MarkAsRead",
//        pattern: "Request/MarkRejectAndAcceptAsRead/{id}",
//        defaults: new { controller = "Request", action = "MarkRejectAndAcceptAsRead" });
//});


//make the Requst as done
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Request",
        pattern: "Request/{action=Index}/{id?}",
        defaults: new { controller = "Request" });

    endpoints.MapControllerRoute(
        name: "MarkAsRead",
        pattern: "Request/MarkAsRead/{id}",
        defaults: new { controller = "Request", action = "MarkAsRead" });
});
//=================================================
//make the Requst as done
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "FieldVisitForms",
        pattern: "FieldVisitForms/{action=Index}/{id?}",
        defaults: new { controller = "FieldVisitForms" });

    endpoints.MapControllerRoute(
        name: "MarkAsRead",
        pattern: "FieldVisitForms/MarkAsRead/{id}",
        defaults: new { controller = "FieldVisitForms", action = "MarkAsRead" });
});
//=================================================
using (var scope = app.Services.CreateScope())
{

    //this for defult user
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<AppUsers>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefultRole.SeedAsync(roleManager);
       // await DefaultUser.SeedProgrammerAsync(userManager, roleManager);

    }
    catch (Exception) { throw; }

    app.Run();
}