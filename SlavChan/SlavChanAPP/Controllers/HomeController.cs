using Microsoft.AspNetCore.Http;
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
            HttpContext.Session.SetString("UserId", Guid.NewGuid().ToString());
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

        public IActionResult ShowThread() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateThread([Bind("Name,UserName,Content,Image,BoardId")] Subject thread) 
        {
            thread.PostDate = DateTime.Now;
            thread.Replies = new List<Reply>();
            thread.TimeSinceLastPost = 0;
            thread.UserId = Guid.Parse(HttpContext.Session.GetString("UserId"));
            _subjectRepository.Save(thread);

            IEnumerable<Subject> Threads = _subjectRepository.GetAll(thread.BoardId);
            return View("Thread",Threads);
        }

    }
}