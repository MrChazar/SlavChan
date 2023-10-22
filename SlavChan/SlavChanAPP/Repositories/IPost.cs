using SlavChanAPP.Models;

namespace SlavChanAPP.Repositories
{
    public interface IPost
    {
        IEnumerable<Post> GetAll();
    }
}
