using Microsoft.EntityFrameworkCore;
using SlavChanAPP.Models;
using System.Diagnostics;
using Thread = SlavChanAPP.Models.Thread;

namespace SlavChanAPP.DataBaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<Thread> Threads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thread>()
            .HasOne<Board>(s => s.Board)
            .WithMany(g => g.Threads)
            .HasForeignKey(s => s.BoardId);

            modelBuilder.Entity<Reply>()
            .HasOne<Thread>(s => s.Thread)
            .WithMany(g => g.Replies)
            .HasForeignKey(s => s.ThreadId);


            modelBuilder.Entity<Board>().HasData(
                new Board
                {
                    BoardId = 1,
                    Shortcut = "ABC",
                    Name = "Ogólna",
                },
                new Board
                {
                    BoardId = 2,
                    Shortcut = "XYZ",
                    Name = "Technologia",
                }
            );

            
            modelBuilder.Entity<Thread>().HasData(
                new Thread
                {
                    ThreadID = Guid.NewGuid(),
                    Name = "Pierwszy wątek",
                    UserName = "User1",
                    Content = "Treść pierwszego wątku",
                    PostDate = DateTime.Now,
                    TimeSinceLastPost = DateTime.Now,
                    UserId = Guid.NewGuid(), // Identyfikator użytkownika
                    BoardId = 1,
                },
                new Thread
                {
                    ThreadID = Guid.NewGuid(),
                    Name = "Drugi wątek",
                    UserName = "User2",
                    Content = "Treść drugiego wątku",
                    PostDate = DateTime.Now,
                    TimeSinceLastPost = DateTime.Now,
                    UserId = Guid.NewGuid(), // Identyfikator użytkownika
                    BoardId = 2,
                }
                // Dodaj więcej rekordów Thread według potrzeb
            );

            // Seedowanie danych dla modelu Reply
            modelBuilder.Entity<Reply>().HasData(
                new Reply
                {
                    ReplyId = Guid.NewGuid(),
                    UserId = Guid.NewGuid(), // Identyfikator użytkownika
                    ReplyUserId = Guid.NewGuid(), // Identyfikator użytkownika
                    Content = "Treść odpowiedzi",
                    ThreadId = Guid.NewGuid(), // Identyfikator wątku
                }
                // Dodaj więcej rekordów Reply według potrzeb
            );
        }
    }
}
