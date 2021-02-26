using LocalDataBaseDemo.models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalDataBaseDemo.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsInfoList : ContentPage
    {

        public StudentsInfoList()
        {
            InitializeComponent();
            BindStudentInformation();
            studentlstview.RefreshCommand = new Command(() => {
                //Do your stuff.    
                RefreshData();
                studentlstview.IsRefreshing = false;
            });
        }

       /* protected override void OnAppearing()
        {
            base.OnAppearing();
            BindStudentInformation();

        }*/
        private void BindStudentInformation()
        {
            try
            {
                var ListofStudents = App.Database.GetStudentsAsync();
                studentlstview.ItemsSource = ListofStudents.Result;

               
            }
            catch (Exception e)
            {
            }
        }
        public void RefreshData()
        {
            studentlstview.ItemsSource = null;
            studentlstview.ItemsSource = App.Database.GetStudentsAsync().Result;
        }
        private void AddStduentInfo(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddStudentsInfoPage(null));
        }

        private void SelectStudentInfoItem(object sender, SelectedItemChangedEventArgs e)
        {

            var selectedITem = e.SelectedItem as StudentsInfo;

            Navigation.PushAsync(new AddStudentsInfoPage(selectedITem));
        }

        private void OnDelete(object sender, System.EventArgs e)
        {
            var listItem = ((MenuItem)sender);
            var studentsInfo = (StudentsInfo)listItem.CommandParameter;
            App.Database.DeleteStudentAsync(studentsInfo);
            RefreshData();
        }
    }
}