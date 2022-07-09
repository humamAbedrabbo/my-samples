using Microsoft.AspNetCore.Authorization;

namespace AuthApp.Authorization
{
    public class HRManagerRequirement : IAuthorizationRequirement
    {
        public readonly int PeriodInMonths = 0;

        public HRManagerRequirement(int periodInMonths)
        {
            this.PeriodInMonths = periodInMonths;
        }
    }

    public class HRManagerRequirementHandler : AuthorizationHandler<HRManagerRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRManagerRequirement requirement)
        {
            if (!context.User.HasClaim(x => x.Type == "EmploymentDate"))
                return Task.CompletedTask;
            var empDate = DateTime.Parse(context.User.FindFirst("EmploymentDate").Value);
            var period = DateTime.Now - empDate;
            if(period.Days > 30 * requirement.PeriodInMonths)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
