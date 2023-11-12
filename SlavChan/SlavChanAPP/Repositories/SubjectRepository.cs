using Microsoft.EntityFrameworkCore;
using SlavChanAPP.DataBaseContext;
using SlavChanAPP.Models;
using Subject = SlavChanAPP.Models.Subject;

namespace SlavChanAPP.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {   
        private readonly DatabaseContext _context;
        public SubjectRepository(DatabaseContext dbContext)
        {
            _context = dbContext;
        }

        public Subject Get(Guid subjectId)
        {
            return _context.Subjects.FirstOrDefault(x => x.Id == subjectId);
        }

        public IEnumerable<Subject> GetAll(int boardId)
        {
           return _context.Subjects.Include(o => o.Board).Include(o => o.Replies).Where(x => x.BoardId == boardId).ToList();
        }

        public void Save(Subject subject) 
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }
        
        
    }
}
