using System;
using Microsoft.AspNetCore.Authorization;

namespace synnex_mvc_app_1.AutorizationRequirements
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            var ageClaim = context.User.FindFirst(
                c => c.Type == "Age");

            if (ageClaim is null)
            {
                return Task.CompletedTask;
            }

            var age = Convert.ToInt32(ageClaim.Value);
            

            if (age >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

