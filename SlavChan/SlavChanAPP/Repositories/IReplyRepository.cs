using SlavChanAPP.Models;

namespace SlavChanAPP.Repositories
{
    public interface IReplyRepository
    {
        IEnumerable<Reply> GetAll(Guid SubjectId);

        void Save(Reply reply);

    }
}
