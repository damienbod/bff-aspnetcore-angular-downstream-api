namespace BffOpenIddict.Server;

public static class SecurityHeadersDefinitions
{
    public static HeaderPolicyCollection GetHeaderPolicyCollection(bool isDev, string? idpHost)
    {
        if (idpHost == null)
        {
            throw new ArgumentNullException(nameof(idpHost));
        }

        var policy = new HeaderPolicyCollection()
            .AddFrameOptionsDeny()
            .AddContentTypeOptionsNoSniff()

            .AddReferrerPolicyStrictOriginWhenCrossOrigin()
            .AddCrossOriginOpenerPolicy(builder => builder.SameOrigin())
            .AddCrossOriginResourcePolicy(builder => builder.SameOrigin())
            // removed for vimeo, weak security...
            //.AddCrossOriginEmbedderPolicy(builder => builder.RequireCorp())

            .AddContentSecurityPolicy(builder =>
            {
                builder.AddObjectSrc().None();
                builder.AddBlockAllMixedContent();
                builder.AddImgSrc().Self().From("data:");
                builder.AddFormAction().Self().From(idpHost);
                builder.AddFontSrc().Self();
                builder.AddBaseUri().Self();

                builder.AddFrameAncestors()
                    .From("https://localhost:5001");

                builder.AddStyleSrc()
                    .Self()
                    .UnsafeInline();

                // disable for video stream, weak security...
                //builder.AddScriptSrc()
                //    .WithNonce()
                //    .UnsafeInline();
            })
            .RemoveServerHeader()
            .AddPermissionsPolicyWithDefaultSecureDirectives();

        if (!isDev)
        {
            // maxage = one year in seconds
            policy.AddStrictTransportSecurityMaxAgeIncludeSubDomains(maxAgeInSeconds: 60 * 60 * 24 * 365);
        }

        return policy;
    }
}
