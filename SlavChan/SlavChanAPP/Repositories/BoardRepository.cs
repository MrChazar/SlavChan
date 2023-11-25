using SlavChanAPP.DataBaseContext;
using SlavChanAPP.Models;
using System.Linq;

namespace SlavChanAPP.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly DatabaseContext _context;

        public BoardRepository(DatabaseContext databasecontext)
        {
            _context = databasecontext;
        }

        public IEnumerable<Board> GetAll()
        {
            IEnumerable<Board> boards = _context.Boards;
            return boards.ToList();
        }

        public Board GetById(int id)
        {
            Board boards = _context.Boards.FirstOrDefault(v => v.Id == id);
            return boards;
        }
    }
}
