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
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public HomeController(IBoardRepository boardRepository, ISubjectRepository subjectRepository, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment ) 
        {
            _boardRepository = boardRepository;
            _subjectRepository = subjectRepository;
            _hostingEnvironment = hostingEnvironment;
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
            thread.SubjectImage = Guid.NewGuid();
            try 
            {
                if (Image != null && Image.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    string uniqueFileName = thread.SubjectImage.ToString() + "_" + Path.GetFileName(Image.FileName);

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Zapisz plik na dysku
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }
                }
            }
            catch (Exception ex)
    {
                // Zaloguj błąd lub zwróć odpowiedź z informacją o błędzie
                return BadRequest($"Wystąpił błąd: {ex.Message}");
            }

            _subjectRepository.Save(thread);

            IEnumerable<Subject> Threads = _subjectRepository.GetAll(thread.BoardId);
            return View("Thread", Threads);
        }


        private byte[] GetBytesFromStream(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }
}