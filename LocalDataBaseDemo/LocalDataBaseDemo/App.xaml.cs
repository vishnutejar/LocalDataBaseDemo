using LocalDataBaseDemo.database;
using LocalDataBaseDemo.views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalDataBaseDemo
{
    public partial class App : Application
    {
        static StudentDataBase database;
        public static StudentDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new StudentDataBase();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new StudentsInfoList());
        }
    }
}
