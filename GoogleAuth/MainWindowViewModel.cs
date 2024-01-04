using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoogleAuth.Services;

namespace GoogleAuth
{
    public partial class  MainWindowViewModel : ObservableRecipient
    {
        private const string successed = "#69F0AE";
        private const string failed = "#FF9E80";
        [ObservableProperty]
        private string response;
        [ObservableProperty]
        private string background;
        [ObservableProperty]
        private string forecolor;
        private readonly GoogleAuthServices googleAuth = new();
        [RelayCommand]
        private void Login()
        {
            try
            {
                var credential = googleAuth.AuthenticateAsync().Result;
                Response = "successed";
                Background = successed;
                Forecolor = "#1B5E20";
            }
            catch (Exception ex)
            {
                Background = failed;
                Response = ex.Message;
                Forecolor = "#DD2C00";
            }
                

        }

    }
}
