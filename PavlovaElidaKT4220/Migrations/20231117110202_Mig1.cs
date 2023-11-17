using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PavlovaElidaKT4220.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_kafedra",
                columns: table => new
                {
                    kafedra_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_kafedra_name = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Название кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_kafedra_kafedra_id", x => x.kafedra_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_stepen",
                columns: table => new
                {
                    stepen_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи ученой степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_stepen_name = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Название ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_stepen_stepen_id", x => x.stepen_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_prepod",
                columns: table => new
                {
                    prepod_id = table.Column<int>(type: "int", nullable: false, comment: "Индетификатор записи преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_prepod_firstname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_prepod_lastname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_prepod_middlename = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kafedra_id = table.Column<int>(type: "int", nullable: false, comment: "Индетификатор кафедры"),
                    stepen_id = table.Column<int>(type: "int", nullable: false, comment: "Индетификатор ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_prepod_prepod_id", x => x.prepod_id);
                    table.ForeignKey(
                        name: "fk_f_kafedra_id",
                        column: x => x.kafedra_id,
                        principalTable: "cd_kafedra",
                        principalColumn: "kafedra_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_stepen_id",
                        column: x => x.stepen_id,
                        principalTable: "cd_stepen",
                        principalColumn: "stepen_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_prepod_fk_c_kafedra_id",
                table: "cd_prepod",
                column: "kafedra_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_prepod_fk_f_stepen_id",
                table: "cd_prepod",
                column: "stepen_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_prepod");

            migrationBuilder.DropTable(
                name: "cd_kafedra");

            migrationBuilder.DropTable(
                name: "cd_stepen");
        }
    }
}
