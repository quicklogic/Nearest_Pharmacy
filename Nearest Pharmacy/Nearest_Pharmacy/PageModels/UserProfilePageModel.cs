using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Nearest_Pharmacy.Models;
using Xamarin.Forms;
using PropertyChanged;

namespace Nearest_Pharmacy.PageModels
{
    [ImplementPropertyChanged]
    public class UserProfilePageModel: FreshBasePageModel
    {
        IPharmacyService _pharmacyService;

        public UserProfilePageModel(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
            isEdit = false;
            Mode = "Редактировать";
            Initial();
        }

        public bool isEdit { get; set; }
        public string Mode { get; set; }
        public string Name { get; set; }
        public string BornDate { get; set; }
        public string Number { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        //public UserInfo User { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);
        }

        public async void Initial()
        {
            try
            {
                UserInfo User1 = new UserInfo();
                string login = Convert.ToString(Xamarin.Forms.Application.Current.Properties["UserLogin"]);
                var MyobjList = await _pharmacyService.GetUserInfo(login);
                User1 = MyobjList[0];
                Name = User1.FirstName + " " + User1.SecondName + " " + User1.Patronomyc;
                BornDate = User1.BornDate;
                Number = User1.Number;
                Mail = User1.Mail;
                Address = User1.Address;
            }
            catch (Exception e) // handle whatever exceptions you expect
            {
                await CoreMethods.DisplayAlert(Convert.ToString(e), "", "Ок");
            }
        }
        public ICommand editBtn => new Command(async (value) =>
        {
            if(isEdit != true)
            {
                isEdit = true;
                Mode = "Сохранить";
            }
            else
            {
                isEdit = false;
                Mode = "Редактировать";
            }

        });
    }
}
