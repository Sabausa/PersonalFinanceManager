using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Front.Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenditure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentExpenseMonthId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenditure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseMonth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenditureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseMonth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseMonth_Expenditure_ExpenditureId",
                        column: x => x.ExpenditureId,
                        principalTable: "Expenditure",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentIncomeMonthId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeMonth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeMonth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeMonth_Income_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "Income",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ExpenditureId = table.Column<int>(type: "int", nullable: false),
                    IncomeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Expenditure_ExpenditureId",
                        column: x => x.ExpenditureId,
                        principalTable: "Expenditure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Income_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "Income",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ExpenseMonthId = table.Column<int>(type: "int", nullable: true),
                    IncomeMonthId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListItem_ExpenseMonth_ExpenseMonthId",
                        column: x => x.ExpenseMonthId,
                        principalTable: "ExpenseMonth",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListItem_IncomeMonth_IncomeMonthId",
                        column: x => x.IncomeMonthId,
                        principalTable: "IncomeMonth",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenditure_CurrentExpenseMonthId",
                table: "Expenditure",
                column: "CurrentExpenseMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseMonth_ExpenditureId",
                table: "ExpenseMonth",
                column: "ExpenditureId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_CurrentIncomeMonthId",
                table: "Income",
                column: "CurrentIncomeMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeMonth_IncomeId",
                table: "IncomeMonth",
                column: "IncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_ExpenseMonthId",
                table: "ListItem",
                column: "ExpenseMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_IncomeMonthId",
                table: "ListItem",
                column: "IncomeMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ExpenditureId",
                table: "Users",
                column: "ExpenditureId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IncomeId",
                table: "Users",
                column: "IncomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditure_ExpenseMonth_CurrentExpenseMonthId",
                table: "Expenditure",
                column: "CurrentExpenseMonthId",
                principalTable: "ExpenseMonth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_IncomeMonth_CurrentIncomeMonthId",
                table: "Income",
                column: "CurrentIncomeMonthId",
                principalTable: "IncomeMonth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditure_ExpenseMonth_CurrentExpenseMonthId",
                table: "Expenditure");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_IncomeMonth_CurrentIncomeMonthId",
                table: "Income");

            migrationBuilder.DropTable(
                name: "ListItem");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ExpenseMonth");

            migrationBuilder.DropTable(
                name: "Expenditure");

            migrationBuilder.DropTable(
                name: "IncomeMonth");

            migrationBuilder.DropTable(
                name: "Income");
        }
    }
}
