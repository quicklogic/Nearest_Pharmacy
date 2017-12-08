using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using System.Collections.ObjectModel;
using Nearest_Pharmacy.Models;
using PropertyChanged;

namespace Nearest_Pharmacy.PageModels
{
    [ImplementPropertyChanged]
    public class BasketPageModel:FreshBasePageModel
    {
        public ObservableCollection<Basket> basket { get; set; }

        public bool isEmpty = true;
        public BasketPageModel()
        {
            if (isEmpty !=true)
            {
                basket = new ObservableCollection<Basket>(Application.Database.GetBasket());
            }
        }

        public async override void Init(object initData)
        {
            if (initData != null)
            {
                try
                {
                    Application.Database.AddBasket((Product)initData as Basket);
                    basket = new ObservableCollection<Basket>(Application.Database.GetBasket());
                    isEmpty = false;
                }
                catch(Exception e)
                {
                    await CoreMethods.DisplayAlert(Convert.ToString(e), "", "Ок");
                }
            }
        }
    }
}
