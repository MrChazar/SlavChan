using SlavChanAPP.Models;

namespace SlavChanAPP.Repositories
{
    public interface IReplyRepository
    {
        IEnumerable<Reply> GetAll(int SubjectId);

        void Save(Reply reply);

    }
}
