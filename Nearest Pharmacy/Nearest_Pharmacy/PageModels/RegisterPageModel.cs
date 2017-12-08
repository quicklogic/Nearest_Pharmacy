using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using Nearest_Pharmacy.Models;
using PropertyChanged;
using System.Windows.Input;
using Xamarin.Forms;
using System.Globalization;

namespace Nearest_Pharmacy.PageModels
{
    [ImplementPropertyChanged]
    public class RegisterPageModel:FreshBasePageModel
    {
        public IPharmacyService _pharmacyService;

        public RegisterPageModel(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronomyc { get; set; }
        public DateTime DateTime { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public override void Init(object initData)
        {
            base.Init(initData);
        }
        public ICommand Register => new Command((value) =>
        {
            Registration(new UserInfo
            {
                login = Login,
                Password = Password,
                FirstName = FirstName,
                SecondName = SecondName,
                Patronomyc = Patronomyc,
                BornDate = DateTime.AddMonths(-1).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                Mail = Email,
                Number = Number,
                Address = Address
             });
        });

        public async void Registration(UserInfo user)
        {
                      
            var result =  await _pharmacyService.Add(user);
            if( result == null)
            {
                await CoreMethods.DisplayAlert("Произошла какая то ошибка, попробуйте снова", "", "Ок");
                return;
            }
            else
            {
                await CoreMethods.DisplayAlert("Вы удачно зарегистрировались!", "", "Ок");             
                await CoreMethods.PushPageModel<LoginPageModel>();
            }      
        }


    }
}
