using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HadiDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        password_hash = table.Column<string>(
                            type: "nvarchar(max)",
                            nullable: false
                        ),
                        first_name = table.Column<string>(
                            type: "nvarchar(100)",
                            maxLength: 100,
                            nullable: false
                        ),
                        last_name = table.Column<string>(
                            type: "nvarchar(100)",
                            maxLength: 100,
                            nullable: false
                        ),
                        email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                        updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "users");
        }
    }
}
