namespace CheckSaver.Areas.Invoices.Models
{
    public interface ITarif
    {
        decimal Calculate(double difference, int month);
    }
}
