using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MauiForm;

public partial class MainPage : ContentPage
{
    int count = 0;
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Validation();
    }

    private async void Validation()
    {
        
        int date = 988;
        string fullNamePattern = "^[a-zA-Z]+$";
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]$";
        //string countryPattern = @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$";
        //string phonePattern = "[0-9]{3}-[0-9]{3}-[0-9]{4}";
        string passwordPattern = "^[0-9]";

        //Regex reg = new Regex(@"[^0-9]");

        //if (((entryName.Text == null || entryName.Text == "") || entryName.Text == "") || (entrySurname.Text == null || entrySurname.Text == "") || (entryPatronymic.Text == null || entryPatronymic.Text == "") || (entryEmail.Text == null || entryEmail.Text == "") || (entryPassword.Text == null || entryPassword.Text == "") || (entryPhone.Text == null || entryPhone.Text == "") || (entryContry.Text == null || entryContry.Text == ""))
        //{
        //    await DisplayAlert("Alert", "Пустые поля", "Ок");
        //    return;
        //}

        if (!Regex.IsMatch(entryName.Text, fullNamePattern))
        {
            await DisplayAlert("Alert", "Вы ввели неверное имя", "Ok");
            count++;
         
        }
        //if (Regex.IsMatch(entrySurname.Text, fullNamePattern)) await DisplayAlert("Alert", "SurnameFalse", "Ok");
        //if (Regex.IsMatch(entryPatronymic.Text, fullNamePattern)) await DisplayAlert("Alert", "PatronymicFalse", "Ok");
        if (!Regex.IsMatch(entryEmail.Text, emailPattern))
        {
            await DisplayAlert("Alert", "EmailFalse", "Ok");
            count++;
          
        }
        if (!Regex.IsMatch(entryPassword.Text, passwordPattern))
        {
            await DisplayAlert("Alert", "PasswordFalse", "Ok");
            count++;
        }
        //if (Regex.IsMatch(entryPhone.Text, phonePattern)) await DisplayAlert("Alert", "PhoneFalse", "Ok");
        //if (Regex.IsMatch(entryContry.Text, countryPattern)) await DisplayAlert("Alert", "ContryFalse", "Ok");


        if(count == 4)
        {
            string promt = await DisplayPromptAsync("Question", "Когда было крещение руси?", "Ok", "Cancel", "", 4, Keyboard.Numeric);
            if (date == Convert.ToInt32(promt))
            {
                await DisplayAlert("Поздравляем", "Вы правильно ответили на вопрос", "Ok");
                count = 0;

            }
            else
            {
                await DisplayAlert("Соболезнуем", "Вы ответили неверно, учите историю", "Ok");
                //return;
            }
        }
       
    }

}