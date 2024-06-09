using Microsoft.AspNetCore.Mvc;

namespace TransformersShop.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            ViewBag.StatusCode = statusCode;
            ViewBag.ErrorMessage = statusCode switch
            {
                401 => "Unauthorized access.",
                404 => "The resource you requested could not be found.",
                405 => "The HTTP method used is not allowed for this resource.",
                _ => "An unexpected error occurred. Please try again later."
            };

            return View("Error");
        }

        [Route("Error/{statusCode}")]
        public IActionResult AccessDenied()
        {
            ViewBag.StatusCode = 403;
            ViewBag.ErrorMessage = "You do not have permission to access this resource.";
            return View("Error");
        }

        [Route("Error")]
        public IActionResult Error()
        {
            //ViewBag.StatusCode = 500;
            ViewBag.ErrorMessage = "An unexpected error occurred. Please try again later.";
            return View("Error");
        }
    }
}
