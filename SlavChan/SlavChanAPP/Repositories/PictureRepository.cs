using SlavChanAPP.Models;
using System.Threading;

namespace SlavChanAPP.Repositories
{
    public class PictureRepository : IPictureRepository
    {

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public PictureRepository(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }   

        public void Save(IFormFile Image, ref string SubjectImage)
        {
            try
            {
                if (Image != null && Image.Length > 0 && ((Path.GetExtension(Image.FileName) == ".png") 
                    || (Path.GetExtension(Image.FileName) == ".jpg") || (Path.GetExtension(Image.FileName) == ".gif")))
                {
                    Console.WriteLine($"udało się {Path.GetExtension(Image.FileName)}");
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    string uniqueFileName = SubjectImage + Path.GetExtension(Image.FileName);
                    SubjectImage += Path.GetExtension(Image.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Save file on server
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }
                }
                else 
                {
                    SubjectImage = null;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
