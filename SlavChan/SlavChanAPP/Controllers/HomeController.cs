using Microsoft.AspNetCore.Mvc;
using SlavChanAPP.Models;
using SlavChanAPP.Repositories;
using System.Diagnostics;

namespace SlavChanAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepository;
        public HomeController(ILogger<HomeController> logger, IPostRepository postRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Feed() 
        {

            return View(_postRepository.GetAll());
        }
    }
}