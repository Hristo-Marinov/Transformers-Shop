using Microsoft.AspNetCore.Mvc;
using TransformersShop.Models;

namespace TransformersShop.Services
{
    public class ErrorHandlingService
    {
        public IActionResult HandleError(string message)
        {
            var errorViewModel = new ErrorViewModel
            {
                ExceptionMessage = message
            };
            return new ViewResult
            {
                ViewName = "Error",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ErrorViewModel>(
                    new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(),
                    new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
                {
                    Model = errorViewModel
                }
            };
        }
    }
}
