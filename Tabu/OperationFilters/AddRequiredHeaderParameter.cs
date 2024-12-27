using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Tabu.OperationFilters
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters =
            [
                new OpenApiParameter
                {
                    Name = "lang",
                    In = ParameterLocation.Header,
                    Description = "Language",
                    Required = true                    
                },
            ];
        }
    }
}
