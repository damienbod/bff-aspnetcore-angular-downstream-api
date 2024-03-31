using System.Net.Http.Headers;
using Yarp.ReverseProxy.Transforms;
using Yarp.ReverseProxy.Transforms.Builder;

namespace BffOpenIddict.Server.ApiClient;

public class JwtTransformProvider : ITransformProvider
{
    private readonly ApiTokenCacheClient _apiTokenClient;

    public JwtTransformProvider(ApiTokenCacheClient apiTokenClient)
    {
        _apiTokenClient = apiTokenClient;
    }

    public void Apply(TransformBuilderContext context)
    {
        if (context.Route.RouteId == "downstreamapiroute")
        {
            context.AddRequestTransform(async transformContext =>
            {
                var access_token = await _apiTokenClient.GetApiToken(
                    "CC",
                    "dataEventRecords",
                    "cc_secret");

                transformContext.ProxyRequest.Headers.Authorization
                    = new AuthenticationHeaderValue("Bearer", access_token);
            });
        }
    }

    public void ValidateCluster(TransformClusterValidationContext context)
    {
        var route = context.Cluster;
    }

    public void ValidateRoute(TransformRouteValidationContext context)
    {
        var route = context.Route;
    }
}
