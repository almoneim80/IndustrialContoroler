using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using IndustrialContoroler.Models;
using IndustrialContoroler.permissions;

namespace IndustrialContoroler.permission
{
    public class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider FallbackPplicyProvier { get;  }
        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            FallbackPplicyProvier=new DefaultAuthorizationPolicyProvider(options);
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
           return  FallbackPplicyProvier.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        {
           return FallbackPplicyProvier.GetFallbackPolicyAsync();
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if(policyName.StartsWith(Helper.Permission, System.StringComparison.OrdinalIgnoreCase))
            {
                var Policy = new AuthorizationPolicyBuilder();
                Policy.AddRequirements(new PermissionRequirement(policyName));
                return Task.FromResult(Policy.Build());
            }
            return FallbackPplicyProvier.GetPolicyAsync(policyName);
        }
    }
}
