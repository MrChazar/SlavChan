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
                    ReplyUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    { new Guid("410761d6-dc1d-4c7d-834e-993d2eb6ec2f"), 2, "Dokąd nocą tupta jeż ??", "Drugi wątek", new DateTime(2023, 11, 18, 16, 4, 55, 301, DateTimeKind.Local).AddTicks(929), null, 16f, new Guid("9d979d71-e984-4206-8c38-bec205da3765"), "User2" },
                    { new Guid("d9ffdfa1-041c-48b0-8d11-2e12c9eb8efe"), 1, "Treść pierwszego wątku", "Pierwszy wątek", new DateTime(2023, 11, 18, 16, 4, 55, 301, DateTimeKind.Local).AddTicks(876), null, 16f, new Guid("ca57178a-0a44-464d-9ebc-ce0b926bd9a0"), "User1" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Content", "ReplyDate", "ReplyImage", "ReplyUserId", "SubjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("941c8ba3-ba57-4085-bdf7-2b2e21a223ec"), "Hmmm naprawdę ciekawy temat", new DateTime(2023, 11, 18, 16, 16, 55, 301, DateTimeKind.Local).AddTicks(983), null, new Guid("ca57178a-0a44-464d-9ebc-ce0b926bd9a0"), new Guid("410761d6-dc1d-4c7d-834e-993d2eb6ec2f"), new Guid("e19be7c0-55dc-4fb6-8c2f-255eef967957") },
                    { new Guid("9fbaa25c-5b30-4310-b801-7328658f8b1f"), "Rzeczywiście daje wiele do myślenia", new DateTime(2023, 11, 18, 16, 27, 55, 301, DateTimeKind.Local).AddTicks(988), null, new Guid("e19be7c0-55dc-4fb6-8c2f-255eef967957"), new Guid("410761d6-dc1d-4c7d-834e-993d2eb6ec2f"), new Guid("b3d37353-b295-45ac-b39c-1c5dddc31d3d") }
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
