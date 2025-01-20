using Microsoft.AspNetCore.Mvc;

namespace VideoGameAPI.Controllers
{
    public class VideoGameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
