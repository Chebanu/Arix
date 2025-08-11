namespace Arix.Contracts.Models;

public class Bot
{
    public Guid Id { get; set; }
    public Guid? OwnerId { get; set; }
    public string Name { get; set; }
    public Guid ApiId { get; set; }
    public string TradingPair { get; set; }
    public decimal Deposit { get; set; }
    public int Leverage { get; set; }
    public List<TradingMode> TradingMode { get; set; }
    public List<TradeEntryCondition> TradeEntryCondition { get; set; }
    public List<ExitTradeCondition> ExitTradeCondition { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public BotState CurrentState { get; set; }
}

public enum BotState
{
    Idle,
    AwaitingSignal,
    InTrade,
    Terminated,
    Error,
    Backtesting
}