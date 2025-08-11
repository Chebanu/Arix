namespace Arix.Contracts.Models;

public class Filter
{
    public Guid Id { get; set; }
    public Indicator Indicator { get; set; }
    public int IntervalMinutes { get; set; }
    public FilterExecutionType ExecutionType { get; set; }
    public ComparisonOperator Operator { get; set; }
    public decimal ThresholdValue { get; set; }
}

public enum Indicator
{
    RSI,
    BollingerBands,
    ADX
}

public enum FilterExecutionType
{
    AtBarClosing,
    OncePerMinute
}

public enum ComparisonOperator
{
    Less,
    Greater
}