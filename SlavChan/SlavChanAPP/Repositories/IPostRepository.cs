using SlavChanAPP.Models;

namespace SlavChanAPP.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
    }
}
