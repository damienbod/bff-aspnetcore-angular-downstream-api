# BFF secured ASP.NET Core application using downstream API and an OAuth client credentials JWT

__OpenID Connect confidential client code flow with PKCE__

__downstream API with OAuth client credentials flow__

https://damienbod.com/2024/04/08/bff-secured-asp-net-core-application-using-downstream-api-and-an-oauth-client-credentials-jwt/

[![.NET and npm build](https://github.com/damienbod/bff-aspnetcore-angular-downstream-api/actions/workflows/dotnet.yml/badge.svg)](https://github.com/damienbod/bff-aspnetcore-angular-downstream-api/actions/workflows/dotnet.yml) [![License](https://img.shields.io/badge/license-Apache%20License%202.0-blue.svg)](https://github.com/damienbod/bff-openiddict-aspnetcore-angular/blob/main/bff/LICENSE)

![image.png](images/context.svg)

## Debugging

Start the Angular project from the **ui** folder

```
nx serve --ssl
```

Start the ASP.NET Core projects from the **server** folder and the **identityProvider**

```
dotnet run
```

Or just open Visual Studio and run the solution.

## Credits and used libraries

- NetEscapades.AspNetCore.SecurityHeaders
- Yarp.ReverseProxy
- OpenIddict
- ASP.NET Core
- Angular 
- Nx
- OpenIddict

## History

- 2024-09-05 Updated packages
- 2024-04-08 Updated API
- 2024-03-24 Updated packages
- 2024-01-22 Updated packages
- 2023-12-30 Open Redirect protection for login
- 2023-11-16 .NET 8 updates

## Links

https://github.com/damienbod/bff-aspnetcore-angular

https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core

https://nx.dev/getting-started/intro

https://github.com/isolutionsag/aspnet-react-bff-proxy-example

https://github.com/openiddict

https://github.com/damienbod/bff-auth0-aspnetcore-angular

https://github.com/damienbod/bff-azureadb2c-aspnetcore-angular

https://github.com/damienbod/bff-aspnetcore-vuejs

https://github.com/damienbod/bff-MicrosoftEntraExternalID-aspnetcore-angular

https://microsoft.github.io/reverse-proxy/articles/transforms.html

https://github.com/microsoft/reverse-proxy/tree/main/samples/ReverseProxy.Transforms.Sample