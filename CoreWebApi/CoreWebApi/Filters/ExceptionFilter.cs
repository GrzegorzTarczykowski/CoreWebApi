using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;

namespace CoreWebApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IModelMetadataProvider modelMetadataProvider;

        public ExceptionFilter(IWebHostEnvironment webHostEnvironment
            , IModelMetadataProvider modelMetadataProvider)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            if (!webHostEnvironment.IsDevelopment())
            {
                return;
            }
            //TODO
        }
    }
}
