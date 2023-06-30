using System.ComponentModel;

namespace Models
{
    public class Product : Entity
    {
        [DisplayName("Nazwa")]
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string Summary => $"{Name}; {Price} zł;";
        public string Type => this.GetType().ToString();

    }
}