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
                    BoardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shortcut = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.BoardId);
                });

            migrationBuilder.CreateTable(
                name: "Threads",
                columns: table => new
                {
                    ThreadID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSinceLastPost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threads", x => x.ThreadID);
                    table.ForeignKey(
                        name: "FK_Threads_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "BoardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    ReplyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplyUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ThreadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ReplyId);
                    table.ForeignKey(
                        name: "FK_Replies_Threads_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "Threads",
                        principalColumn: "ThreadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Name", "Shortcut" },
                values: new object[,]
                {
                    { 1, "Ogólna", "ABC" },
                    { 2, "Technologia", "XYZ" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "ReplyId", "Content", "Image", "ReplyUserId", "ThreadId", "UserId" },
                values: new object[] { new Guid("9195b5de-0812-47fa-83bc-c6bce6465a44"), "Treść odpowiedzi", null, new Guid("165333a2-c85d-42f1-9891-cc8734dd9a56"), new Guid("5ed7e3a6-0293-4ccf-b2e5-ec7a913c4d38"), new Guid("47737281-ffb4-4667-b58a-5f3631827f60") });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "BoardId", "Content", "Image", "Name", "PostDate", "TimeSinceLastPost", "UserId", "UserName" },
                values: new object[,]
                {
                    { new Guid("4cd6f8f0-93f7-4238-8c85-1be47253f757"), 2, "Treść drugiego wątku", null, "Drugi wątek", new DateTime(2023, 10, 29, 20, 36, 18, 610, DateTimeKind.Local).AddTicks(8960), new DateTime(2023, 10, 29, 20, 36, 18, 610, DateTimeKind.Local).AddTicks(8962), new Guid("c3451a6b-a591-415d-8687-49e46a7e70b9"), "User2" },
                    { new Guid("abce1b55-659b-40aa-b106-c0e3b421d6ba"), 1, "Treść pierwszego wątku", null, "Pierwszy wątek", new DateTime(2023, 10, 29, 20, 36, 18, 610, DateTimeKind.Local).AddTicks(8914), new DateTime(2023, 10, 29, 20, 36, 18, 610, DateTimeKind.Local).AddTicks(8955), new Guid("226a45f6-4fdd-456d-b5dc-919ce58f5429"), "User1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Replies_ThreadId",
                table: "Replies",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_Threads_BoardId",
                table: "Threads",
                column: "BoardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Threads");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
