using System;
using System.Windows;
using AppName.Common;

namespace AppName
{
    public partial class MainWindow : Window
    {
        private readonly BouncingSuppressor _bouncingSuppressor = new BouncingSuppressor();

        public MainWindow()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;
        }

        private async void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (await _bouncingSuppressor.Check())
            {
                // some actions
            }
        }
    }
}
