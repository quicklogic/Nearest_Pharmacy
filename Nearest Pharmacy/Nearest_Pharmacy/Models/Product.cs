using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Nearest_Pharmacy.Models
{

    [Table("Products"), ImplementPropertyChanged]
    public class Product
    {
        [PrimaryKey, Column("_id")]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Availability { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ProducerID { get; set; }
        public bool IsVisible { get; set; }
        public string ImageURI{ get; set; }

        public Product()
        {
            this.IsVisible = true;
        }
    }
}
