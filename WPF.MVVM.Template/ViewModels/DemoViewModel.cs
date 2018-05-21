using AppName.Models;
using System;
using System.Collections.ObjectModel;


namespace AppName.ViewModels
{
    public class DemoViewModel : ViewModelBase
    {
        private string _header;

        public DemoViewModel()
        {
            Header = "Header";
            for (int i = 0; i < 20; i++)
            {
                UserList.Add(new User() { FirstName = i.ToString(), SecondName = (i * 10).ToString() });
            }
        }

        public ObservableCollection<User> UserList { get; private set; } = new ObservableCollection<User>();

        public string Header
        {
            get { return _header; }
            set { SetProperty(ref _header, value); }
        }
    }
}
