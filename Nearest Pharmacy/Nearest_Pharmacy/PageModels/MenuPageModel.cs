using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using PropertyChanged;
using Xamarin.Forms;
using System.Windows.Input;
using Nearest_Pharmacy.Models;

namespace Nearest_Pharmacy.PageModels
{
    [ImplementPropertyChanged]
    class MenuPageModel : FreshBasePageModel
    {
        public MenuPageModel()
        {
            if (Convert.ToString(Xamarin.Forms.Application.Current.Properties["Auth"]) == "True")
            {
                IsLogin = true;
                IsLogon = false;
            }
            else
            {
                IsLogin = false;
                IsLogon = true;
            }
        }
           
        public bool IsLogin { get; set; }
        public bool IsLogon { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);  
        }
     
        public ICommand goMain => new Command(async (value) =>
        {
            await CoreMethods.PushPageModel<ProductListPageModel>();
        });
        public ICommand goUserProfile => new Command(async (value) =>
        {
            await CoreMethods.PushPageModel<UserProfilePageModel>();
        });
        public ICommand goOrders => new Command(async (value) =>
        {
            await CoreMethods.PushPageModel<ProductListPageModel>();
        });
        public ICommand goInfo => new Command(async (value) =>
        {
            await CoreMethods.PushPageModel<ProductListPageModel>();
        });

        public ICommand goSettings => new Command(async =>
        {
            CoreMethods.PushPageModel<RegisterPageModel>();
        });

        public ICommand goLogin => new Command(async =>
        {
            CoreMethods.PushPageModel<LoginPageModel>();
        });

        public ICommand goRegister => new Command(async =>
        {
            CoreMethods.PushPageModel<RegisterPageModel>();
        });
    }
}
