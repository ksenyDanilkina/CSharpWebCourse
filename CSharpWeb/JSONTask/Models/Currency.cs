namespace JSONTask.Models
{
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public override string ToString()
        {
            return $"Валюта: {Name}, код {Code}, символ {Symbol}";
        }
    }
}
