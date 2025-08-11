using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arix.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TradingPair = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Deposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Leverage = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExitTradeConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Profit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TakeProfitBySignal = table.Column<bool>(type: "bit", nullable: false),
                    EnableStopLoss = table.Column<bool>(type: "bit", nullable: false),
                    StopLoss = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TerminateBotAfterStopLossExecution = table.Column<bool>(type: "bit", nullable: true),
                    BotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExitTradeConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExitTradeConditions_Bot_BotId",
                        column: x => x.BotId,
                        principalTable: "Bot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradeEntryConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeEntryConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradeEntryConditions_Bot_BotId",
                        column: x => x.BotId,
                        principalTable: "Bot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradingModes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OverlappingPriceChangeRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GridOrdersCount = table.Column<int>(type: "int", nullable: false),
                    MartingaleRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IndentRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LogarithmicPriceDistribution = table.Column<bool>(type: "bit", nullable: false),
                    LogarithmicDistributionRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PartialAmountOfGridOrders = table.Column<int>(type: "int", nullable: false),
                    PullingUpGridOrderRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StopBotAfterDealsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    AmountAfterToStop = table.Column<int>(type: "int", nullable: true),
                    IncludeExchangePositionInTrade = table.Column<bool>(type: "bit", nullable: false),
                    BotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingModes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradingModes_Bot_BotId",
                        column: x => x.BotId,
                        principalTable: "Bot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Indicator = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IntervalMinutes = table.Column<int>(type: "int", nullable: false),
                    ExecutionType = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ThresholdValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExitTradeConditionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TradeEntryConditionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filter_ExitTradeConditions_ExitTradeConditionId",
                        column: x => x.ExitTradeConditionId,
                        principalTable: "ExitTradeConditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Filter_TradeEntryConditions_TradeEntryConditionId",
                        column: x => x.TradeEntryConditionId,
                        principalTable: "TradeEntryConditions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExitTradeConditions_BotId",
                table: "ExitTradeConditions",
                column: "BotId");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_ExitTradeConditionId",
                table: "Filter",
                column: "ExitTradeConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_TradeEntryConditionId",
                table: "Filter",
                column: "TradeEntryConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeEntryConditions_BotId",
                table: "TradeEntryConditions",
                column: "BotId");

            migrationBuilder.CreateIndex(
                name: "IX_TradingModes_BotId",
                table: "TradingModes",
                column: "BotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filter");

            migrationBuilder.DropTable(
                name: "TradingModes");

            migrationBuilder.DropTable(
                name: "ExitTradeConditions");

            migrationBuilder.DropTable(
                name: "TradeEntryConditions");

            migrationBuilder.DropTable(
                name: "Bot");
        }
    }
}
