using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SlavChanAPP.Migrations
{
    /// <inheritdoc />
    public partial class innit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shortcut = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSinceLastPost = table.Column<float>(type: "real", nullable: false),
                    SubjectImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplyUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplyImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name", "Shortcut" },
                values: new object[,]
                {
                    { 1, "Ogólna", "ABC" },
                    { 2, "Technologia", "XYZ" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "BoardId", "Content", "Name", "PostDate", "SubjectImage", "TimeSinceLastPost", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, 1, "Treść pierwszego wątku", "Pierwszy wątek", new DateTime(2023, 11, 18, 22, 19, 27, 476, DateTimeKind.Local).AddTicks(5873), null, 22f, new Guid("3f6901b2-cbc2-40c7-ba5a-e328a11b4e1a"), "User1" },
                    { 2, 2, "Dokąd nocą tupta jeż ??", "Drugi wątek", new DateTime(2023, 11, 18, 22, 19, 27, 476, DateTimeKind.Local).AddTicks(5917), null, 22f, new Guid("25338d9d-33bf-4aa1-a6ee-4bab4872efe5"), "User2" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Content", "ReplyDate", "ReplyImage", "ReplyUserId", "SubjectId", "UserId" },
                values: new object[,]
                {
                    { 1, "Hmmm naprawdę ciekawy temat", new DateTime(2023, 11, 18, 22, 31, 27, 476, DateTimeKind.Local).AddTicks(5935), null, new Guid("3f6901b2-cbc2-40c7-ba5a-e328a11b4e1a"), 2, new Guid("c81510bb-4bd9-4157-8b28-dedc2eeb8440") },
                    { 2, "Rzeczywiście daje wiele do myślenia", new DateTime(2023, 11, 18, 22, 42, 27, 476, DateTimeKind.Local).AddTicks(5940), null, new Guid("c81510bb-4bd9-4157-8b28-dedc2eeb8440"), 2, new Guid("0624ced6-4927-449f-863f-8c6e526b7a2e") },
                    { 3, "Rzeczywiście daje wiele do myślenia", new DateTime(2023, 11, 20, 9, 56, 27, 476, DateTimeKind.Local).AddTicks(5943), null, new Guid("c81510bb-4bd9-4157-8b28-dedc2eeb8440"), 1, new Guid("0624ced6-4927-449f-863f-8c6e526b7a2e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Replies_SubjectId",
                table: "Replies",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_BoardId",
                table: "Subjects",
                column: "BoardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
