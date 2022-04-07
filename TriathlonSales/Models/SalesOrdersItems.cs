namespace TriathlonSales.Models
{
    public class SalesOrdersItems
    {
        public int Id { get; set; }
        public string docNo     { get; set; }
        public int posId { get; set; }
        public virtual string posName { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
        public DateTime createdDate { get; set; }= DateTime.Now;
    }
}
