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

        public Subject Get(int subjectId)
        {
            return _context.Subjects.FirstOrDefault(x => x.Id == subjectId);
        }

        public IEnumerable<Subject> GetAll(int boardId)
        {
           return _context.Subjects.Include(o => o.Board).Include(o => o.Replies).Where(x => x.BoardId == boardId).ToList();
        }

        public void Save(Subject subject, string? name, string? userName) 
        {
            Reply reply = new Reply();
            reply.Name = name;
            reply.UserName = userName;
            reply.SubjectId = subject.Id;
            reply.Content = subject.Content;
            reply.UserId = subject.UserId;
            reply.ReplyImage = subject.SubjectImage;
            reply.ReplyDate = subject.PostDate;
            subject.Replies.Add(reply);
            _context.Subjects.Add(subject);
            _context.Replies.Add(reply);
            _context.SaveChanges();
        }
        
        public void Delete() 
        {
            IEnumerable<Subject> subjects = _context.Subjects.Where(x => x.TimeSinceLastPost > 300000);
            foreach( var a in subjects) 
            {
                _context.Subjects.Remove(a);
            }
            _context.SaveChanges();
        }

        public void UpdateAllTime() 
        {
            IQueryable<Subject> subjects = _context.Subjects;

            foreach (var subject in subjects)
            {
                
                subject.TimeSinceLastPost += 60000;
            }

            _context.SaveChanges();
        }

        public void UpdateTimeById(int subjectId)
        {
            Subject subject = _context.Subjects.FirstOrDefault(x => x.Id == subjectId);
            if (subject != null)
            {
                subject.TimeSinceLastPost = 0;
                
            }
            _context.SaveChanges();
        }

    }
}
