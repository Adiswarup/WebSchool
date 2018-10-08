using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebCat7.Data;

namespace WebCat7.Auth
{
    public class SubTeacherHandler : AuthorizationHandler<SubTeacherRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SubTeacherRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                return Task.CompletedTask;
            }

            var subjectTeacher =  context.User.FindFirst(c => c.Type == ClaimTypes.Name).Value;

            if (subjectTeacher == requirement.subjectTeach)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}