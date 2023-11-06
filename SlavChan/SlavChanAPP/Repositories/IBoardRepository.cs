using SlavChanAPP.Models;

namespace SlavChanAPP.Repositories
{
    public interface IBoardRepository
    {
        IEnumerable<Board> GetAll();
        
        Board GetById(int id);

    }
}
