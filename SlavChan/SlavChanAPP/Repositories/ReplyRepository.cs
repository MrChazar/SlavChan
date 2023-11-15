using SlavChanAPP.DataBaseContext;
using SlavChanAPP.Models;

namespace SlavChanAPP.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly DatabaseContext _context;

        public ReplyRepository(DatabaseContext context) 
        {
            _context = context;
        }

        public IEnumerable<Reply> GetAll(Guid SubjectId)
        {
            return _context.Replies.Where(x => x.SubjectId == SubjectId).OrderBy(x => x.ReplyDate).ToList();
        }

        public void Save(Reply reply) 
        {
            _context.Replies.Add(reply);
        }

    }
}
