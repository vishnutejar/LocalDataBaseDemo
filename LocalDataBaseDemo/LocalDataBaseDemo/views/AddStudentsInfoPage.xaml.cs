using LocalDataBaseDemo.models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalDataBaseDemo.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddStudentsInfoPage : ContentPage
    {
        private string _emailid, _firstname, _lastname, _phonenumber, _password, _confirmpassword,_age;
        private int _studentId;
        public AddStudentsInfoPage(StudentsInfo selectedITem)
        {
            InitializeComponent();
            if (selectedITem != null) {
                _studentId = selectedITem.Id;
                emailid.Text = selectedITem.Email;
                firstname.Text = selectedITem.FirstName;
                lastname.Text = selectedITem.LastName;
                phonenumber.Text = selectedITem.PhNumber;
                password.Text = selectedITem.Password;
                confirmpassword.Text = selectedITem.Password;
            }
        }

        private void SaveStudentInformation(object sender, EventArgs e)
        {
            _emailid = emailid?.Text?.Trim();
            _firstname = firstname?.Text?.Trim();
            _lastname = lastname?.Text?.Trim();
            _phonenumber = phonenumber?.Text?.Trim();
            _password = password?.Text?.Trim();
            _confirmpassword = confirmpassword?.Text?.Trim();
            _age = age?.Text?.Trim();
            var msg = ValidateUserInputs(_emailid, _firstname, _lastname, _phonenumber, _password, _confirmpassword);

            if (string.IsNullOrEmpty(msg))
            {
                StudentsInfo studentsInfo = new StudentsInfo()
                {
                    Id = _studentId,
                    FirstName = _firstname,
                    LastName = _lastname,
                    Email = _emailid,
                    PhNumber = _phonenumber,
                    Password = _password,
                    Age = _age,
                    profileImage = ""
                };

               App.Database.InsertStudentsAsync(studentsInfo);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error Message ", msg, "cancel");
            }
        }

        private string ValidateUserInputs(string _emailid, string _firstname, string _lastname, string _phonenumber, string _password, string _confirmpassword)
        {
            if (string.IsNullOrWhiteSpace(_firstname))
            {
                return "Enter Your FirstName";
            }else if (string.IsNullOrWhiteSpace(_emailid))
            {
                return "Enter Your Email Id";
            }
            else if (string.IsNullOrWhiteSpace(_lastname))
            {
                return "Enter Your LastName";
            }
            else if (string.IsNullOrWhiteSpace(_phonenumber))
            {
                return "Enter Your Phone Number";
            }
            else if (string.IsNullOrWhiteSpace(_password))
            {
                return "Enter Your Password";
            }
            else if (string.IsNullOrWhiteSpace(_confirmpassword))
            {
                return "Enter Your ConfirmPassword";
            }
            else if (!_password.Equals(_confirmpassword))
            {
                return "Enter Your password and ConfirmPassword should same.";
            }
            else
            {
                return string.Empty;
            }

        }
    }
}