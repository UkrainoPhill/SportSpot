using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSpot.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fix_spot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int[]>(
                name: "InterestsTemp",
                table: "Users",
                type: "integer[]",
                nullable: false);

            migrationBuilder.Sql(
                "UPDATE \"Users\" SET \"InterestsTemp\" = string_to_array(\"Interests\", ',')::integer[];");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "InterestsTemp",
                table: "Users",
                newName: "Interests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InterestsTemp",
                table: "Users",
                type: "text",
                nullable: false);

            migrationBuilder.Sql(
                "UPDATE \"Users\" SET \"InterestsTemp\" = array_to_string(\"Interests\", ',');");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "InterestsTemp",
                table: "Users",
                newName: "Interests");
        }
    }
}
