using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tbr_data_api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    _id = table.Column<string>(nullable: false),
                    uploadKey = table.Column<string>(nullable: true),
                    conversationId = table.Column<string>(nullable: true),
                    recipientId = table.Column<int>(nullable: false),
                    senderId = table.Column<int>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    _id = table.Column<string>(nullable: false),
                    conversationId = table.Column<string>(nullable: true),
                    uploadKey = table.Column<string>(nullable: true),
                    recipientId = table.Column<int>(nullable: false),
                    senderId = table.Column<int>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    externalId = table.Column<int>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x._id);
                    table.ForeignKey(
                        name: "FK_Message_Conversation_conversationId",
                        column: x => x.conversationId,
                        principalTable: "Conversation",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaUrl",
                columns: table => new
                {
                    _id = table.Column<string>(nullable: false),
                    messageId = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaUrl", x => x._id);
                    table.ForeignKey(
                        name: "FK_MediaUrl_Message_messageId",
                        column: x => x.messageId,
                        principalTable: "Message",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaUrl_messageId",
                table: "MediaUrl",
                column: "messageId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_conversationId",
                table: "Message",
                column: "conversationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaUrl");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Conversation");
        }
    }
}
