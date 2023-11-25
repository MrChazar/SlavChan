using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlavChanAPP.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Replies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Replies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "ReplyDate", "ReplyUserId", "UserId", "UserName" },
                values: new object[] { null, new DateTime(2023, 11, 25, 22, 4, 52, 118, DateTimeKind.Local).AddTicks(1084), new Guid("a0b15dd9-fa73-4d26-9c54-9d03318298c9"), new Guid("1cfa8884-6fe2-432c-80b0-2e3d1556fca6"), null });

            migrationBuilder.UpdateData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "ReplyDate", "ReplyUserId", "UserId", "UserName" },
                values: new object[] { null, new DateTime(2023, 11, 25, 22, 15, 52, 118, DateTimeKind.Local).AddTicks(1087), new Guid("1cfa8884-6fe2-432c-80b0-2e3d1556fca6"), new Guid("d09ba791-4b37-4086-8cce-e4345fbca9fc"), null });

            migrationBuilder.UpdateData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "ReplyDate", "ReplyUserId", "UserId", "UserName" },
                values: new object[] { null, new DateTime(2023, 11, 27, 9, 29, 52, 118, DateTimeKind.Local).AddTicks(1089), new Guid("1cfa8884-6fe2-432c-80b0-2e3d1556fca6"), new Guid("d09ba791-4b37-4086-8cce-e4345fbca9fc"), null });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PostDate", "TimeSinceLastPost", "UserId" },
                values: new object[] { new DateTime(2023, 11, 25, 21, 52, 52, 118, DateTimeKind.Local).AddTicks(1020), 21f, new Guid("a0b15dd9-fa73-4d26-9c54-9d03318298c9") });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PostDate", "TimeSinceLastPost", "UserId" },
                values: new object[] { new DateTime(2023, 11, 25, 21, 52, 52, 118, DateTimeKind.Local).AddTicks(1062), 21f, new Guid("6337c7f5-220f-4402-bd95-7df6b41f7e7c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Replies");

            migrationBuilder.UpdateData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReplyDate", "ReplyUserId", "UserId" },
                values: new object[] { new DateTime(2023, 11, 18, 22, 31, 27, 476, DateTimeKind.Local).AddTicks(5935), new Guid("3f6901b2-cbc2-40c7-ba5a-e328a11b4e1a"), new Guid("c81510bb-4bd9-4157-8b28-dedc2eeb8440") });

            migrationBuilder.UpdateData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReplyDate", "ReplyUserId", "UserId" },
                values: new object[] { new DateTime(2023, 11, 18, 22, 42, 27, 476, DateTimeKind.Local).AddTicks(5940), new Guid("c81510bb-4bd9-4157-8b28-dedc2eeb8440"), new Guid("0624ced6-4927-449f-863f-8c6e526b7a2e") });

            migrationBuilder.UpdateData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ReplyDate", "ReplyUserId", "UserId" },
                values: new object[] { new DateTime(2023, 11, 20, 9, 56, 27, 476, DateTimeKind.Local).AddTicks(5943), new Guid("c81510bb-4bd9-4157-8b28-dedc2eeb8440"), new Guid("0624ced6-4927-449f-863f-8c6e526b7a2e") });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PostDate", "TimeSinceLastPost", "UserId" },
                values: new object[] { new DateTime(2023, 11, 18, 22, 19, 27, 476, DateTimeKind.Local).AddTicks(5873), 22f, new Guid("3f6901b2-cbc2-40c7-ba5a-e328a11b4e1a") });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PostDate", "TimeSinceLastPost", "UserId" },
                values: new object[] { new DateTime(2023, 11, 18, 22, 19, 27, 476, DateTimeKind.Local).AddTicks(5917), 22f, new Guid("25338d9d-33bf-4aa1-a6ee-4bab4872efe5") });
        }
    }
}
