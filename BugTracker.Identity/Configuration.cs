using IdentityServer4.Models;
using IdentityServer4;
using IdentityModel;

namespace BugTracker.Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("BugTrackerWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("BugTrackerWebAPI", "Web API", new []
                    { JwtClaimTypes.Name })
                {
                    Scopes = {"BugTrackerWebAPI"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "bugtracker-web-api",
                    ClientName = "BugTracker Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "https://.../singin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://..."
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://.../signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "BugTrackerWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
