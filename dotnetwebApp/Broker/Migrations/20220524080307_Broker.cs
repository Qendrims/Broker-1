using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Broker.Migrations
{
    public partial class Broker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "counteroffer",
                columns: table => new
                {
                    CounterOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CounterOfferPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_counteroffer", x => x.CounterOfferId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mbiemri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ditelindja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Rruga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qyteti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paga = table.Column<double>(type: "float", nullable: true),
                    AccountNr = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "feedback",
                columns: table => new
                {
                    PermbajtjaFeedBackut = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback", x => new { x.PermbajtjaFeedBackut, x.UserId });
                    table.ForeignKey(
                        name: "FK_feedback_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TakenBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GivenBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_job_user_AgentId",
                        column: x => x.AgentId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longtitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qyteti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rruga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    isArchived = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AgentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_post_user_AgentID",
                        column: x => x.AgentID,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CounterOfferPost",
                columns: table => new
                {
                    CounterOffersCounterOfferId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterOfferPost", x => new { x.CounterOffersCounterOfferId, x.PostId });
                    table.ForeignKey(
                        name: "FK_CounterOfferPost_counteroffer_CounterOffersCounterOfferId",
                        column: x => x.CounterOffersCounterOfferId,
                        principalTable: "counteroffer",
                        principalColumn: "CounterOfferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CounterOfferPost_post_PostId",
                        column: x => x.PostId,
                        principalTable: "post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dergonCounterOffers",
                columns: table => new
                {
                    postid = table.Column<int>(type: "int", nullable: false),
                    CounterOfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_dergonCounterOffers_counteroffer_CounterOfferId",
                        column: x => x.CounterOfferId,
                        principalTable: "counteroffer",
                        principalColumn: "CounterOfferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dergonCounterOffers_post_postid",
                        column: x => x.postid,
                        principalTable: "post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "image",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image", x => new { x.ImageId, x.PostId });
                    table.ForeignKey(
                        name: "FK_image_post_PostId",
                        column: x => x.PostId,
                        principalTable: "post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "postcategory",
                columns: table => new
                {
                    PostCategoryId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postcategory", x => new { x.PostCategoryId, x.PostId });
                    table.ForeignKey(
                        name: "FK_postcategory_post_PostId",
                        column: x => x.PostId,
                        principalTable: "post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "postcounteroffer",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CounterOfferId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postcounteroffer", x => new { x.CounterOfferId, x.PostId });
                    table.ForeignKey(
                        name: "FK_postcounteroffer_counteroffer_CounterOfferId",
                        column: x => x.CounterOfferId,
                        principalTable: "counteroffer",
                        principalColumn: "CounterOfferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_postcounteroffer_post_PostId",
                        column: x => x.PostId,
                        principalTable: "post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_postcounteroffer_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    TagName = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => new { x.TagName, x.PostId });
                    table.ForeignKey(
                        name: "FK_tags_post_PostId",
                        column: x => x.PostId,
                        principalTable: "post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CounterOfferPost_PostId",
                table: "CounterOfferPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_dergonCounterOffers_CounterOfferId",
                table: "dergonCounterOffers",
                column: "CounterOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_dergonCounterOffers_postid",
                table: "dergonCounterOffers",
                column: "postid");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_UserId",
                table: "feedback",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_image_PostId",
                table: "image",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_job_AgentId",
                table: "job",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_post_AgentID",
                table: "post",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_postcategory_PostId",
                table: "postcategory",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_postcounteroffer_PostId",
                table: "postcounteroffer",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_postcounteroffer_UserId",
                table: "postcounteroffer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tags_PostId",
                table: "tags",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CounterOfferPost");

            migrationBuilder.DropTable(
                name: "dergonCounterOffers");

            migrationBuilder.DropTable(
                name: "feedback");

            migrationBuilder.DropTable(
                name: "image");

            migrationBuilder.DropTable(
                name: "job");

            migrationBuilder.DropTable(
                name: "postcategory");

            migrationBuilder.DropTable(
                name: "postcounteroffer");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "counteroffer");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
