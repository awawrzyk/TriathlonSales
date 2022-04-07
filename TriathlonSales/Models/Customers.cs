namespace TriathlonSales.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNo { get; set; }
        public virtual string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string streetNo { get; set; }
        public string PostalCode { get; set; }
    }
}
