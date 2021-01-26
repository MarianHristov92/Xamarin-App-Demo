using System;
using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Data
{
    public class MainPageData
    {

        public static IList<MainPageItem> MainDataList { get; private set; }

        static MainPageData()
        {
            MainDataList = new List<MainPageItem>();

            MainDataList.Add(new MainPageItem
            {
                Name = "About",
                NavigationPath = "AboutPage"
            });

            MainDataList.Add(new MainPageItem
            {
                Name = "Login/Register",
                NavigationPath = "LoginPage"
            });

            MainDataList.Add(new MainPageItem
            {
                Name = "Settings",
                NavigationPath = "SettingsPage"
            });

            MainDataList.Add(new MainPageItem
            {
                Name = "Details Page",
                NavigationPath = "DetailsPage"
            });
        }
    }
}
