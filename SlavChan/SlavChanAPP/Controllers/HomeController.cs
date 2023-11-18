using Microsoft.AspNetCore.Mvc;
using SlavChanAPP.Models;
using SlavChanAPP.Repositories;
using System.Diagnostics;

namespace SlavChanAPP.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IBoardRepository _boardRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IPictureRepository _pictureRepository;
        private readonly IReplyRepository _replyRepository;

        public HomeController(IBoardRepository boardRepository, ISubjectRepository subjectRepository, IPictureRepository pictureRepository, IReplyRepository replyRepository)
        {
            _boardRepository = boardRepository;
            _subjectRepository = subjectRepository;
            _pictureRepository = pictureRepository;
            _replyRepository = replyRepository;
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
        public IActionResult CreateThread(Subject thread, IFormFile Image)
        {
            thread.PostDate = DateTime.Now;
            thread.Replies = new List<Reply>();
            thread.TimeSinceLastPost = 0;
            thread.UserId = Guid.Parse(HttpContext.Session.GetString("UserId"));
            if( Image != null ) 
            {
                string temp = Guid.NewGuid().ToString();
                _pictureRepository.Save(Image, SubjectImage: ref temp);
                thread.SubjectImage = temp;
            }
            else 
            {
                thread.SubjectImage = null;
            }
            

            _subjectRepository.Save(thread);

            IEnumerable<Subject> Threads = _subjectRepository.GetAll(thread.BoardId);
            return View("Thread", Threads);
        }

        public IActionResult Post(int SubjectId) 
        {
            return View(_replyRepository.GetAll(SubjectId));
        }

        [HttpPost]
        public IActionResult CreateReply(string Content, IFormFile Image, Guid ReplyUserId, int SubjectId ) 
        {
            Reply reply = new Reply();
            reply.Content = Content;
            reply.ReplyDate = DateTime.Now;
            reply.UserId = Guid.Parse(HttpContext.Session.GetString("UserId"));
            reply.ReplyUserId = ReplyUserId;
            reply.SubjectId = SubjectId;
            _replyRepository.Save(reply);
            return RedirectToAction("Post", new { SubjectId = SubjectId });
        }

    }
}