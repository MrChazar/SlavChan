﻿using System;
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
                name: "Threads",
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
                    table.PrimaryKey("PK_Threads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threads_Boards_BoardId",
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
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ThreadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Threads_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "Threads",
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