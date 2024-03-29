﻿using Microsoft.EntityFrameworkCore;
using SlavChanAPP.Models;
using System.Diagnostics;
using Subject = SlavChanAPP.Models.Subject;

namespace SlavChanAPP.DataBaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public int ThredId1 = 1;
        public int ThredId2 = 2;
        public Guid ThredPostingUser1 = Guid.NewGuid();
        public Guid ThredPostingUser2 = Guid.NewGuid();
        public Guid ReplyPostingUser1 = Guid.NewGuid();
        public Guid ReplyPostingUser2 = Guid.NewGuid();


        public DbSet<Board> Boards { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>()
            .HasOne<Board>(s => s.Board)
            .WithMany(g => g.Subjects)
            .HasForeignKey(s => s.BoardId);

            modelBuilder.Entity<Reply>()
            .HasOne<Subject>(s => s.Subject)
            .WithMany(g => g.Replies)
            .HasForeignKey(s => s.SubjectId);


            modelBuilder.Entity<Board>().HasData(
                new Board
                {
                    Id = 1,
                    Shortcut = "ABC",
                    Name = "Ogólna"
                },
                new Board
                {
                    Id = 2,
                    Shortcut = "XYZ",
                    Name = "Technologia"
                }
            );

            
            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = ThredId1,
                    Name = "Pierwszy wątek",
                    UserName = "User1",
                    Content = "Treść pierwszego wątku",
                    PostDate = DateTime.Now,
                    TimeSinceLastPost = DateTime.Now.Hour,
                    UserId = ThredPostingUser1, // Identyfikator użytkownika
                    BoardId = 1
                },
                new Subject
                {
                    Id = ThredId2,
                    Name = "Drugi wątek",
                    UserName = "User2",
                    Content = "Dokąd nocą tupta jeż ??",
                    PostDate = DateTime.Now,
                    TimeSinceLastPost = DateTime.Now.Hour,
                    UserId = ThredPostingUser2, // user identifier
                    BoardId = 2
                }
                // add more thread records
            );

            // seeding data 
            modelBuilder.Entity<Reply>().HasData(
                new Reply
                {
                    Id = 1,
                    UserId = ReplyPostingUser1, 
                    ReplyUserId = ThredPostingUser1, 
                    Content = "Hmmm naprawdę ciekawy temat",
                    ReplyDate = DateTime.Now.AddMinutes(12),
                    SubjectId = ThredId2 
                },
                new Reply 
                {
                    Id = 2,
                    UserId = ReplyPostingUser2,
                    ReplyUserId = ReplyPostingUser1,
                    Content = "Rzeczywiście daje wiele do myślenia",
                    ReplyDate = DateTime.Now.AddMinutes(23),
                    SubjectId = ThredId2

                },
                new Reply 
                {
                    Id = 3,
                    UserId = ReplyPostingUser2,
                    ReplyUserId = ReplyPostingUser1,
                    Content = "Rzeczywiście daje wiele do myślenia",
                    ReplyDate = DateTime.Now.AddMinutes(2137),
                    SubjectId = ThredId1
                }
                
            );
        }
    }
}
