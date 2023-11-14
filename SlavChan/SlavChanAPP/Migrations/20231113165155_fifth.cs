using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SlavChanAPP.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("69e45305-a1de-4894-94fd-a3e129d3ea35"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("bc60a72b-ff07-41cd-9f86-a4e39f409f66"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("9bd51624-d70a-47a7-a41b-325000b1e9ee"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("c0dca3bb-2d04-4f2f-9489-d3c50ff40ad3"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Replies");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectImage",
                table: "Subjects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "BoardId", "Content", "Name", "PostDate", "SubjectImage", "TimeSinceLastPost", "UserId", "UserName" },
                values: new object[,]
                {
                    { new Guid("425f0e55-be2d-4fe8-96cb-719f56baa137"), 2, "Treść drugiego wątku", "Drugi wątek", new DateTime(2023, 11, 13, 17, 51, 55, 493, DateTimeKind.Local).AddTicks(483), null, 17f, new Guid("0508138c-c50a-46ac-91d7-0d4f417cf1f7"), "User2" },
                    { new Guid("a4184425-6adf-41b1-9803-5d4bd80dc298"), 1, "Treść pierwszego wątku", "Pierwszy wątek", new DateTime(2023, 11, 13, 17, 51, 55, 493, DateTimeKind.Local).AddTicks(438), null, 17f, new Guid("058a1b2e-133a-4e1d-a6f8-3d43e94f44b9"), "User1" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Content", "ReplyDate", "ReplyUserId", "SubjectId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4ff4a082-b7d5-4c08-a754-462417e886eb"), "Treść odpowiedzi", new DateTime(2023, 11, 13, 18, 3, 55, 493, DateTimeKind.Local).AddTicks(537), new Guid("058a1b2e-133a-4e1d-a6f8-3d43e94f44b9"), new Guid("425f0e55-be2d-4fe8-96cb-719f56baa137"), new Guid("d7116f02-6e22-416f-a4b7-d6c22f6f49f6") },
                    { new Guid("e51883b1-a820-4873-aa9a-48b63dd44428"), "Jebać pis", new DateTime(2023, 11, 13, 18, 14, 55, 493, DateTimeKind.Local).AddTicks(542), new Guid("d7116f02-6e22-416f-a4b7-d6c22f6f49f6"), new Guid("425f0e55-be2d-4fe8-96cb-719f56baa137"), new Guid("c023de5e-a726-464d-b4f6-8188db243a5b") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("4ff4a082-b7d5-4c08-a754-462417e886eb"));

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: new Guid("e51883b1-a820-4873-aa9a-48b63dd44428"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("a4184425-6adf-41b1-9803-5d4bd80dc298"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("425f0e55-be2d-4fe8-96cb-719f56baa137"));

            migrationBuilder.DropColumn(
                name: "SubjectImage",
                table: "Subjects");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Subjects",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Replies",
                type: "varbinary(max)",
                nullable: true);

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
        }
    }
}
