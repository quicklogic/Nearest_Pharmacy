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
    class LoginPageModel : FreshBasePageModel
    {
        public IPharmacyService _pharmacyService;

        public LoginPageModel(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public ICommand Enter => new Command(async (value) =>
        {
            if (String.IsNullOrEmpty(Login)|| String.IsNullOrEmpty(Password))
            {
                await CoreMethods.DisplayAlert("Логин или пароль не введён", "", "Ок");
                return;
            }
            User user = new User
            {
                Login = Login,
                Password = Password
            };
            var result = await _pharmacyService.Login(user);
            if (result == null)
            {
                await CoreMethods.DisplayAlert("Не удалось найти такого пользователя", "", "Ок");
            }
            else
            {
                Xamarin.Forms.Application.Current.Properties["UserLogin"] = Login;
                Xamarin.Forms.Application.Current.Properties["Auth"] = "True";
                MenuPageModel a = new MenuPageModel();
                a.IsLogin = false;
                a.IsLogon = true;

                await CoreMethods.PushPageModel<ProductListPageModel>();
            }

        });
    }
}
