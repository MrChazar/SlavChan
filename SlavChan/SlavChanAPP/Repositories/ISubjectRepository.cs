using SlavChanAPP.Models;
using System;

namespace SlavChanAPP.Repositories
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll(int boardId);

        Subject Get(Guid subjectId);
    }
}
