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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplyUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    { new Guid("278ef9e2-396d-4a86-b29a-4f2d7e18df19"), 2, "Treść drugiego wątku", "Drugi wątek", new DateTime(2023, 11, 15, 12, 6, 24, 699, DateTimeKind.Local).AddTicks(3469), null, 12f, new Guid("61b427b5-9369-4c14-b1c9-730cb5d51ded"), "User2" },
                    { new Guid("ec076636-6a0d-4ba6-9d6d-fc5f08e01365"), 1, "Treść pierwszego wątku", "Pierwszy wątek", new DateTime(2023, 11, 15, 12, 6, 24, 699, DateTimeKind.Local).AddTicks(3431), null, 12f, new Guid("29fb6c5d-3b2a-4205-b5bd-18c3ff2d73f6"), "User1" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Content", "ReplyDate", "ReplyUserId", "SubjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("10f6a8a3-e8e2-4c0f-baf4-06e65acba60b"), "Jebać pis", new DateTime(2023, 11, 15, 12, 29, 24, 699, DateTimeKind.Local).AddTicks(3522), new Guid("5468d124-cc12-494a-9a29-b51b9d09be09"), new Guid("278ef9e2-396d-4a86-b29a-4f2d7e18df19"), new Guid("84384969-4450-46d8-ac9d-2d76a1975ea4") },
                    { new Guid("76b656b5-6917-4a84-9d7b-e1289e316e55"), "Treść odpowiedzi", new DateTime(2023, 11, 15, 12, 18, 24, 699, DateTimeKind.Local).AddTicks(3517), new Guid("29fb6c5d-3b2a-4205-b5bd-18c3ff2d73f6"), new Guid("278ef9e2-396d-4a86-b29a-4f2d7e18df19"), new Guid("5468d124-cc12-494a-9a29-b51b9d09be09") }
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
