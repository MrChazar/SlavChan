using SlavChanAPP.DataBaseContext;
using SlavChanAPP.Models;
using System.Linq;

namespace SlavChanAPP.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly DatabaseContext _databasecontext;

        public BoardRepository(DatabaseContext databasecontext)
        {
            _databasecontext = databasecontext;
        }

        public IEnumerable<Board> GetAll()
        {
            IEnumerable<Board> boards = _databasecontext.Boards;
            return boards.ToList();
        }

        public Board GetById(int id)
        {
            Board boards = _databasecontext.Boards.FirstOrDefault(v => v.Id == id);
            return boards;
        }
    }
}
