namespace Models
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}