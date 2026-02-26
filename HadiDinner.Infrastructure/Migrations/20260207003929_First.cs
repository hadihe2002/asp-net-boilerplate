using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HadiDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menus",
                columns: table =>
                    new
                    {
                        menu_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        name = table.Column<string>(
                            type: "nvarchar(100)",
                            maxLength: 100,
                            nullable: false
                        ),
                        description = table.Column<string>(
                            type: "nvarchar(100)",
                            maxLength: 100,
                            nullable: false
                        ),
                        average_rating = table.Column<double>(type: "float", nullable: false),
                        rating_count = table.Column<int>(type: "int", nullable: false),
                        host_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                        updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.menu_id);
                }
            );

            migrationBuilder.CreateTable(
                name: "menu_dinner_ids",
                columns: table =>
                    new
                    {
                        id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        dinner_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        menu_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_dinner_ids", x => x.id);
                    table.ForeignKey(
                        name: "FK_menu_dinner_ids_menus_menu_id",
                        column: x => x.menu_id,
                        principalTable: "menus",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "menu_review_ids",
                columns: table =>
                    new
                    {
                        id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        review_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        menu_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_review_ids", x => x.id);
                    table.ForeignKey(
                        name: "FK_menu_review_ids_menus_menu_id",
                        column: x => x.menu_id,
                        principalTable: "menus",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "menu_sections",
                columns: table =>
                    new
                    {
                        menu_section_id = table.Column<Guid>(
                            type: "uniqueidentifier",
                            nullable: false
                        ),
                        menu_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        name = table.Column<string>(
                            type: "nvarchar(100)",
                            maxLength: 100,
                            nullable: false
                        ),
                        description = table.Column<string>(
                            type: "nvarchar(100)",
                            maxLength: 100,
                            nullable: false
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_sections", x => new { x.menu_section_id, x.menu_id });
                    table.ForeignKey(
                        name: "FK_menu_sections_menus_menu_id",
                        column: x => x.menu_id,
                        principalTable: "menus",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "menu_items",
                columns: table =>
                    new
                    {
                        menu_item_id = table.Column<Guid>(
                            type: "uniqueidentifier",
                            nullable: false
                        ),
                        menu_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        menu_section_id = table.Column<Guid>(
                            type: "uniqueidentifier",
                            nullable: false
                        ),
                        name = table.Column<string>(
                            type: "nvarchar(100)",
                            maxLength: 100,
                            nullable: false
                        ),
                        description = table.Column<string>(
                            type: "nvarchar(100)",
                            maxLength: 100,
                            nullable: false
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_menu_items",
                        x =>
                            new
                            {
                                x.menu_item_id,
                                x.menu_id,
                                x.menu_section_id
                            }
                    );
                    table.ForeignKey(
                        name: "FK_menu_items_menu_sections_menu_section_id_menu_id",
                        columns: x => new { x.menu_section_id, x.menu_id },
                        principalTable: "menu_sections",
                        principalColumns: new[] { "menu_section_id", "menu_id" },
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_menu_dinner_ids_menu_id",
                table: "menu_dinner_ids",
                column: "menu_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_menu_section_id_menu_id",
                table: "menu_items",
                columns: new[] { "menu_section_id", "menu_id" }
            );

            migrationBuilder.CreateIndex(
                name: "IX_menu_review_ids_menu_id",
                table: "menu_review_ids",
                column: "menu_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_menu_sections_menu_id",
                table: "menu_sections",
                column: "menu_id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "menu_dinner_ids");

            migrationBuilder.DropTable(name: "menu_items");

            migrationBuilder.DropTable(name: "menu_review_ids");

            migrationBuilder.DropTable(name: "menu_sections");

            migrationBuilder.DropTable(name: "menus");
        }
    }
}
