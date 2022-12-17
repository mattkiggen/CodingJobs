using Microsoft.AspNetCore.Authorization;

namespace CodingJobs.Api.Authorization;

public static class ConfigurePolicies
{
    public static void AddCustomPolicies(this AuthorizationOptions options, IConfiguration config)
    {
        options.AddPolicy(
            "create:companies", 
            p => p.Requirements.Add(
                new HasScopeRequirement("create:companies", config["Auth0:Domain"])
            )
        );
        
        options.AddPolicy("create:jobs", 
            p => p.Requirements.Add(new HasScopeRequirement("create:jobs", config["Auth0:Domain"])));
    }
}