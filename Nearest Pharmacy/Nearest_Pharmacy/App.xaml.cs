using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreshMvvm;

using Xamarin.Forms;
using Nearest_Pharmacy.PageModels;
using Nearest_Pharmacy.Models;

namespace Nearest_Pharmacy
{
    public partial class Application : Xamarin.Forms.Application
    {
        public Application()
        {
            object name = "";
            if (!Current.Properties.TryGetValue("Auth", out name))
            {
                Xamarin.Forms.Application.Current.Properties["Auth"] = "False";
            }
            InitializeComponent();
            FreshIOC.Container.Register<IPharmacyService, PharmacyService>();
            var masterDetailNav = new FreshMasterDetailNavigationContainer();

            var homePage = FreshPageModelResolver.ResolvePageModel<ProductListPageModel>();
            masterDetailNav.Detail = new FreshNavigationContainer(homePage);
            var homePageModel = homePage.GetModel();

            var menuPage = FreshPageModelResolver.ResolvePageModel<MenuPageModel>(homePageModel);
            masterDetailNav.Master = menuPage;

            homePageModel.CoreMethods.PopToRoot(true);

            MainPage = masterDetailNav;

        }

        public const string DATABASE_NAME = "products.db";
        public static ProductRepository database;
        public static ProductRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProductRepository(DATABASE_NAME);
                }
                return database;
            }
        }

        protected override void OnStart()
        {         
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
