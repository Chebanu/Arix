namespace Arix.Contracts.Models;

public class TradingMode
{
    public Guid Id { get; set; }
    public decimal OverlappingPriceChangeRatio { get; set; }
    public int GridOrdersCount { get; set; }
    public decimal MartingaleRatio { get; set; }
    public decimal IndentRatio { get; set; }
    public bool LogarithmicPriceDistribution { get; set; } = false;
    public decimal? LogarithmicDistributionRatio { get; set; }
    public int PartialAmountOfGridOrders { get; set; }
    public decimal PullingUpGridOrderRatio { get; set; }
    public bool StopBotAfterDealsCompleted { get; set; } = false;
    public int? AmountAfterToStop { get; set; }
    public bool IncludeExchangePositionInTrade { get; set; }
}
