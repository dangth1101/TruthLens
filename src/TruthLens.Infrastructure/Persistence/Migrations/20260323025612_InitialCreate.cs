using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruthLens.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UploadCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaUploads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Filename = table.Column<string>(type: "character varying(260)", maxLength: 260, nullable: false),
                    StoragePath = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    FileHash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    MimeType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsAiGenerated = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AiConfidenceScore = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaUploads_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DuplicateRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OriginalUploadId = table.Column<Guid>(type: "uuid", nullable: false),
                    DuplicateUploadId = table.Column<Guid>(type: "uuid", nullable: false),
                    DetectedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuplicateRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuplicateRecords_MediaUploads_DuplicateUploadId",
                        column: x => x.DuplicateUploadId,
                        principalTable: "MediaUploads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuplicateRecords_MediaUploads_OriginalUploadId",
                        column: x => x.OriginalUploadId,
                        principalTable: "MediaUploads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RankEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaUploadId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalUploads = table.Column<int>(type: "integer", nullable: false),
                    AiGeneratedCount = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RankEntries_MediaUploads_MediaUploadId",
                        column: x => x.MediaUploadId,
                        principalTable: "MediaUploads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuplicateRecords_DuplicateUploadId",
                table: "DuplicateRecords",
                column: "DuplicateUploadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuplicateRecords_OriginalUploadId",
                table: "DuplicateRecords",
                column: "OriginalUploadId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaUploads_UserId",
                table: "MediaUploads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RankEntries_MediaUploadId",
                table: "RankEntries",
                column: "MediaUploadId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuplicateRecords");

            migrationBuilder.DropTable(
                name: "RankEntries");

            migrationBuilder.DropTable(
                name: "MediaUploads");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
