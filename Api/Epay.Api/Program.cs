using Framework.AssemblyHelper;
using Framework.DependencyInjection;
using Framework.ExceptionHandling;
using Framework.Facade;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


var assemblyHelper = new AssemblyHelper(nameof(Epay));
var mvcBuilder = builder.Services.AddMvc(option =>
{
    option.EnableEndpointRouting = false;
})
.AddNewtonsoftJson(o =>
{
    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
Registrar(builder.Services, assemblyHelper);
AddControllers(assemblyHelper, mvcBuilder);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Epay API", Version = "v1" });

    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Description =
                "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey
        });

    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.DescribeAllParametersInCamelCase();
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"},
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                }
    );
    //c.SchemaFilter<RequireValueTypePropertiesSchemaFilter>(true);
});
builder.Services.AddCors(o => o.AddPolicy("CrossDomainPolicy",
                builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.ConfigureErrorHandlingMiddleware();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("CrossDomainPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddControllers(AssemblyHelper assemblyHelper, IMvcBuilder mvcBuilder)
{
    var controllerAssemblies = assemblyHelper.GetAssemblies(typeof(FacadeCommandBase)).Distinct();

    foreach (var apiControllerAssembly in controllerAssemblies)
        mvcBuilder.AddApplicationPart(apiControllerAssembly);

    controllerAssemblies = assemblyHelper.GetAssemblies(typeof(FacadeQueryBase)).Distinct();
    foreach (var apiControllerAssembly in controllerAssemblies)
        mvcBuilder.AddApplicationPart(apiControllerAssembly);
}
void Registrar(IServiceCollection services, AssemblyHelper assemblyHelper)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var registrars = assemblyHelper.GetInstanceByInterface(typeof(IRegistrar));
    foreach (IRegistrar registrar in registrars)
        registrar.Register(services, connectionString);
}