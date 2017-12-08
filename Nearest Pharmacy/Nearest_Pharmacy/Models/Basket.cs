using PropertyChanged;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nearest_Pharmacy.Models
{
    [Table("Basket"), ImplementPropertyChanged]
    public class Basket:Product
    {
   
    }
}
