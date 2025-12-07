using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

namespace Api;

internal static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        services.AddAuthentication()
            .AddJwtBearer("Bearer", options =>
            {
                options.Audience = "rs_dataEventRecordsApi";
                options.Authority = "https://localhost:44318/";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudiences = ["rs_dataEventRecordsApi"],
                    ValidIssuers = ["https://localhost:44318/"],
                };
            });

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "DownstreamApi", Version = "v1" });
        });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();
        // Do not add to deployments, for debug reasons
        IdentityModelEventSource.ShowPII = true;

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LegacyApi v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();
        app.UseAuthentication();

        app.MapControllers();

        return app;
    }
}