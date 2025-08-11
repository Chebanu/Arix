namespace Arix.Contracts.Models;

public class TradeEntryCondition
{
    public Guid Id { get; set; }
    public List<Filter> Filters { get; set; }
}