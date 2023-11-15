using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SlavChanAPP.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("10f6a8a3-e8e2-4c0f-baf4-06e65acba60b"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("76b656b5-6917-4a84-9d7b-e1289e316e55"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("ec076636-6a0d-4ba6-9d6d-fc5f08e01365"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("278ef9e2-396d-4a86-b29a-4f2d7e18df19"));

            migrationBuilder.AddColumn<string>(
                name: "ReplyImage",
                table: "Replies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "BoardId", "Content", "Name", "PostDate", "SubjectImage", "TimeSinceLastPost", "UserId", "UserName" },
                values: new object[,]
                {
                    { new Guid("25204c1b-b742-4f1f-9ea3-79264f6d4920"), 2, "Dokąd nocą tupta jeż ??", "Drugi wątek", new DateTime(2023, 11, 15, 20, 38, 32, 641, DateTimeKind.Local).AddTicks(942), null, 20f, new Guid("46202b9d-d7a9-4883-be6b-7c42e81d795b"), "User2" },
                    { new Guid("dee357fe-8df4-4f9c-a1a9-8c769122b6b7"), 1, "Treść pierwszego wątku", "Pierwszy wątek", new DateTime(2023, 11, 15, 20, 38, 32, 641, DateTimeKind.Local).AddTicks(902), null, 20f, new Guid("0a12578d-74ab-4001-8787-72a38c9f9022"), "User1" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Content", "ReplyDate", "ReplyImage", "ReplyUserId", "SubjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("75a90278-e52b-4d4f-9ca7-9c4def081f85"), "Hmmm naprawdę ciekawy temat", new DateTime(2023, 11, 15, 20, 50, 32, 641, DateTimeKind.Local).AddTicks(1040), null, new Guid("0a12578d-74ab-4001-8787-72a38c9f9022"), new Guid("25204c1b-b742-4f1f-9ea3-79264f6d4920"), new Guid("877a24a0-e670-4a08-8045-48f85307a951") },
                    { new Guid("bf9ce504-a564-4229-a03c-5a313c65aa02"), "Rzeczywiście daje wiele do myślenia", new DateTime(2023, 11, 15, 21, 1, 32, 641, DateTimeKind.Local).AddTicks(1046), null, new Guid("877a24a0-e670-4a08-8045-48f85307a951"), new Guid("25204c1b-b742-4f1f-9ea3-79264f6d4920"), new Guid("e23330c3-318f-4d23-a38e-8a21532f8ec3") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("75a90278-e52b-4d4f-9ca7-9c4def081f85"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("bf9ce504-a564-4229-a03c-5a313c65aa02"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("dee357fe-8df4-4f9c-a1a9-8c769122b6b7"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("25204c1b-b742-4f1f-9ea3-79264f6d4920"));

            migrationBuilder.DropColumn(
                name: "ReplyImage",
                table: "Replies");

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
        }
    }
}
