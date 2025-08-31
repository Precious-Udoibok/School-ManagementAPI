using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

// 1️⃣ Create the OperationFilter
public class AuthorizeCheckOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Check if the endpoint or controller has [Authorize]
        var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttribute<Microsoft.AspNetCore.Authorization.AuthorizeAttribute>() != null
                           || context.MethodInfo.GetCustomAttribute<Microsoft.AspNetCore.Authorization.AuthorizeAttribute>() != null;

        if (!hasAuthorize) return;

        // Add JWT bearer security to this operation
        operation.Security = new List<OpenApiSecurityRequirement>
        {
            new OpenApiSecurityRequirement
            {
                [ new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    }
                ] = new string[]{}
            }
        };
    }
}