using Microsoft.AspNetCore.Mvc;
using SlavChanAPP.Models;
using SlavChanAPP.Repositories;
using System.Diagnostics;
using Thread = SlavChanAPP.Models.Subject;

namespace SlavChanAPP.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IBoardRepository _boardRepository;
        private readonly ISubjectRepository _subjectRepository;

        public HomeController(IBoardRepository boardRepository, ISubjectRepository subjectRepository) 
        {
            _boardRepository = boardRepository;
            _subjectRepository = subjectRepository;
        }

        public IActionResult Index()
        {
            return View(_boardRepository.GetAll());
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

        public IActionResult Thread(int boardId) 
        {
            return View(_subjectRepository.GetAll(boardId));
        }

    }
}