namespace Domain.Models;

public class Price : EntityBase<DateTimeOffset>
{
    public Price(DateTimeOffset date, decimal molPrice, decimal uihPrice) :
        base(date)
    {
        MolPrice = molPrice;
        UihPrice = uihPrice;
    }

    public decimal MolPrice { get; private set; }
    public decimal UihPrice { get; private set; }
}