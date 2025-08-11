namespace Arix.Contracts.Models;

public class ExitTradeCondition
{
    public Guid Id { get; set; }
    public List<decimal> Profit { get; set; }
    public bool TakeProfitBySignal { get; set; } = false;
    public List<Filter>? Filters { get; set; }
    public bool EnableStopLoss { get; set; }
    public decimal? StopLoss { get; set; }
    public bool? TerminateBotAfterStopLossExecution { get; set; }
}