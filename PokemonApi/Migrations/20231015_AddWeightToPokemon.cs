using Microsoft.EntityFrameworkCore.Migrations;

public partial class AddWeightToPokemon : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "Weight",
            table: "Pokemons",
            nullable: false,
            defaultValue: 0);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Weight",
            table: "Pokemons");
    }
}
