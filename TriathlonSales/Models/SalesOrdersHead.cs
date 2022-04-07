namespace TriathlonSales.Models
{
    public class SalesOrdersHead
    {
        public int Id { get; set; }
        public string docNo { get; set; }
        public string Customer { get; set; }
        public DateTime createdDate { get; set; }= DateTime.Now;
        public string Currency { get; set; }
        public decimal totalNet { get; set; }
        public decimal totalGross { get; set; }
        public string Vat { get; set; }

    }
}
