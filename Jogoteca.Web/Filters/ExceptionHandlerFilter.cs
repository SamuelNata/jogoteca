using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Jogoteca.Models.Exceptions;
using Jogoteca.Web.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Jogoteca.Filters
{
    public class ExceptionHandlerFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public ExceptionHandlerFilter(
            IHostEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            if (!_hostingEnvironment.IsDevelopment())
            {
                return;
            }
            var result = new ViewResult {ViewName = "Views/Pages/Error.cshtml"};
            result.ViewData = new ViewDataDictionary(_modelMetadataProvider,
                                                        context.ModelState);
            if(typeof(UserFriendlyException).IsAssignableFrom(context.Exception.GetType())){
                result.ViewData.Add("ErrorMessage", context.Exception.Message);
            }
            else
            {
                result.ViewData.Add("ErrorMessage", "Erro inesperado, tente novamente mais tarde ou entre em contato com o suporte");
            }

            context.Result = result;
        }
    
        public async Task test()
        {
            // try{
            //     var resultContext = await next();
            // }
            // catch(Exception e){
            //     Controller controller = context.Controller as Controller;
            //     if(typeof(UserFriendlyException).IsAssignableFrom(e.GetType())){
            //         controller.ViewData["ErrorMessage"] = e.Message;
            //     }
            //     else
            //     {
            //         controller.ViewData["ErrorMessage"] = "Erro inesperado, tente novamente mais tarde ou entre em contato com o suporte";
            //     }
            //     context.Result = controller.RedirectToAction("Error", "Pages");
            // }
        }
    }
}