using SlavChanAPP.Models;

namespace SlavChanAPP.Repositories
{
    public class FakePost : IPost
    {

        private static readonly ICollection<Post> _posts = new List<Post>()
        {
            new Post
            {
                Id = 1,
                Name = "John",
                Title = "Pierwszy post",
                Description = "To jest pierwszy post na moim blogu.",
                File = "post1.txt"
            },
            new Post
            {
                Id = 2,
                Name = "Alice",
                Title = "Nowy post",
                Description = "Oto mój nowy post na blogu.",
                File = "post2.txt"
            },
            new Post
            {
                Id = 3,
                Name = "Bob",
                Title = "Ważne ogłoszenie",
                Description = "To jest ważne ogłoszenie dla wszystkich czytelników.",
                File = "post3.txt"
            },
            new Post
            {
                Id = 4,
                Name = "Emily",
                Title = "Inspirujący wpis",
                Description = "Chcę podzielić się inspirującą historią z mojego życia.",
                File = "post4.txt"
            },
            new Post
            {
                Id = 5,
                Name = "David",
                Title = "Nowe zdjęcie",
                Description = "Dziś wrzucam nowe zdjęcie z mojej podróży.",
                File = "post5.txt"
            }
        };


        public IEnumerable<Post> GetAll()
        {
            return _posts.ToList();
        }
    }
}
