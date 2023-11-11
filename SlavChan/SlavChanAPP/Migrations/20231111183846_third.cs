using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SlavChanAPP.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Threads_ThreadId",
                table: "Replies");

            migrationBuilder.DropTable(
                name: "Threads");

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("7afc26f1-0896-40a3-b5e9-bc818c948b22"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("d96497ef-7e4d-4801-8ecc-0b9e381b3d81"));

            migrationBuilder.RenameColumn(
                name: "ThreadId",
                table: "Replies",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_ThreadId",
                table: "Replies",
                newName: "IX_Replies_SubjectId");

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
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "BoardId", "Content", "Image", "Name", "PostDate", "TimeSinceLastPost", "UserId", "UserName" },
                values: new object[,]
                {
                    { new Guid("9bd51624-d70a-47a7-a41b-325000b1e9ee"), 1, "Treść pierwszego wątku", null, "Pierwszy wątek", new DateTime(2023, 11, 11, 19, 38, 46, 529, DateTimeKind.Local).AddTicks(8595), 19f, new Guid("dc28023b-3366-4d8d-a19d-ffae7d0d83a0"), "User1" },
                    { new Guid("c0dca3bb-2d04-4f2f-9489-d3c50ff40ad3"), 2, "Treść drugiego wątku", null, "Drugi wątek", new DateTime(2023, 11, 11, 19, 38, 46, 529, DateTimeKind.Local).AddTicks(8652), 19f, new Guid("928bb112-4603-4c0f-8a4c-18a1ae4da3da"), "User2" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Content", "Image", "ReplyDate", "ReplyUserId", "SubjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("69e45305-a1de-4894-94fd-a3e129d3ea35"), "Jebać pis", null, new DateTime(2023, 11, 11, 20, 1, 46, 529, DateTimeKind.Local).AddTicks(8723), new Guid("b84c6457-b5f8-444e-9be3-c379d450c330"), new Guid("c0dca3bb-2d04-4f2f-9489-d3c50ff40ad3"), new Guid("52e7e672-d1d6-4424-8331-06a81df2d67a") },
                    { new Guid("bc60a72b-ff07-41cd-9f86-a4e39f409f66"), "Treść odpowiedzi", null, new DateTime(2023, 11, 11, 19, 50, 46, 529, DateTimeKind.Local).AddTicks(8717), new Guid("dc28023b-3366-4d8d-a19d-ffae7d0d83a0"), new Guid("c0dca3bb-2d04-4f2f-9489-d3c50ff40ad3"), new Guid("b84c6457-b5f8-444e-9be3-c379d450c330") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_BoardId",
                table: "Subjects",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Subjects_SubjectId",
                table: "Replies",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Subjects_SubjectId",
                table: "Replies");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("69e45305-a1de-4894-94fd-a3e129d3ea35"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("bc60a72b-ff07-41cd-9f86-a4e39f409f66"));

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Replies",
                newName: "ThreadId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_SubjectId",
                table: "Replies",
                newName: "IX_Replies_ThreadId");

            migrationBuilder.CreateTable(
                name: "Threads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSinceLastPost = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threads_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "Id", "BoardId", "Content", "Image", "Name", "PostDate", "TimeSinceLastPost", "UserId", "UserName" },
                values: new object[,]
                {
                    { new Guid("685f58f1-3c97-4190-a8d5-e1ca395a7a21"), 2, "Treść drugiego wątku", null, "Drugi wątek", new DateTime(2023, 10, 30, 11, 18, 31, 905, DateTimeKind.Local).AddTicks(8643), 11f, new Guid("e06cc998-fbcc-4c41-bb84-ddd718efe235"), "User2" },
                    { new Guid("e2906f0e-cecf-4c2f-9b12-9d3d1ad0765e"), 1, "Treść pierwszego wątku", null, "Pierwszy wątek", new DateTime(2023, 10, 30, 11, 18, 31, 905, DateTimeKind.Local).AddTicks(8601), 11f, new Guid("6f0386e4-449c-48de-90e9-bafecdb73c7a"), "User1" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Content", "Image", "ReplyDate", "ReplyUserId", "ThreadId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7afc26f1-0896-40a3-b5e9-bc818c948b22"), "Treść odpowiedzi", null, new DateTime(2023, 10, 30, 11, 30, 31, 905, DateTimeKind.Local).AddTicks(8692), new Guid("6f0386e4-449c-48de-90e9-bafecdb73c7a"), new Guid("685f58f1-3c97-4190-a8d5-e1ca395a7a21"), new Guid("0c6856f6-aa7a-4267-a585-21cf66b633eb") },
                    { new Guid("d96497ef-7e4d-4801-8ecc-0b9e381b3d81"), "Jebać pis", null, new DateTime(2023, 10, 30, 11, 41, 31, 905, DateTimeKind.Local).AddTicks(8698), new Guid("0c6856f6-aa7a-4267-a585-21cf66b633eb"), new Guid("685f58f1-3c97-4190-a8d5-e1ca395a7a21"), new Guid("faf63b16-76b7-49cf-8fdc-b7a660c47d49") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Threads_BoardId",
                table: "Threads",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Threads_ThreadId",
                table: "Replies",
                column: "ThreadId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
