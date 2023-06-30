using Resources.Properties;
using System.ComponentModel;

namespace Models
{
    public class Product : Entity
    {
        private string name = string.Empty;

        [DisplayName("Nazwa")]
        public string Name
        {
            get => name;
            set
            {
                name = value;

                if(name.Length < 5)
                {
                    ErrorDictionary[nameof(Name)] = Resources.Properties.Resources.NameTooShort;
                }
                else
                {
                    ErrorDictionary.Remove(nameof(Name));
                }
                OnErrorChanged();
            }
        }
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string Summary => $"{Name}; {Price} zł;";
        public string Type => this.GetType().ToString();

    }
}