using Microsoft.AspNetCore.Mvc;

namespace CreditCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}