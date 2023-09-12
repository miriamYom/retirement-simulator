using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]

public class ErrorsController : Controller
{
    // שיחרור הסלשים גורר שגיאה 
    // שלא נותנת להריץ את ה SWAGGER
    
    [Route("/error")]
    public ActionResult Error([FromServices] IHostEnvironment hostEnvironment)
    {
        //...
        return Problem();
    }

    [Route("/error-development")]
    public ActionResult DevelopmentError([FromServices] IHostEnvironment hostEnvironment)
    {
        //...
        return Problem();

    }

}
