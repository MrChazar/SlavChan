namespace SlavChanAPP.Repositories
{
    public interface IPictureRepository
    {
        void Save(IFormFile Image, ref string SubjectImage);
    }
}
