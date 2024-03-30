using RazorPageOidcClient;
using Yarp.ReverseProxy.Transforms;
using Yarp.ReverseProxy.Transforms.Builder;

namespace BffOpenIddict.Server.ApiClient;

public class JwtTransformProvider : ITransformProvider
{
    private readonly ApiService _apiService;

    public JwtTransformProvider(ApiService apiService)
    {
        _apiService = apiService;
    }

    public void Apply(TransformBuilderContext context)
    {
        if(context.Route.RouteId == "downstreamapiroute") 
        {
            _apiService.
            context.AddRequestTransform(transformContext =>
            {
                transformContext.ProxyRequest
                    .Options
                    .Set(new HttpRequestOptionsKey<string>("CustomMetadata"), value);

                return default;
            });
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
