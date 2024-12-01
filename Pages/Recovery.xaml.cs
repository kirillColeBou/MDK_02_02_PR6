using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegIn_Тепляков.Pages
{
    /// <summary>
    /// Логика взаимодействия для Recovery.xaml
    /// </summary>
    public partial class Recovery : Page
    {
        string OldLogin;
        bool IsCapture = false;

        public Recovery()
        {
            InitializeComponent();
        }

        void animation(bool flag)
        {
            BitmapImage img = new BitmapImage();
            ImageSource src = img;
            if (flag)
            {
                MemoryStream ms = new MemoryStream(MainWindow.mainWindow.userLogin.Image);
                img.BeginInit();
                img.StreamSource = ms;
                img.EndInit();
                src = img;
            }
            DoubleAnimation start = new DoubleAnimation();
            start.From = 1;
            start.To = 0;
            start.Duration = TimeSpan.FromSeconds(0.6);
            start.Completed += delegate
            {
                if (flag) IUser.Source = src;
                else IUser.Source = new BitmapImage(new Uri("pack://application:,,,/Images/ic-user.png"));
                DoubleAnimation end = new DoubleAnimation();
                end.From = 0;
                end.To = 1;
                end.Duration = TimeSpan.FromSeconds(1.2);
                IUser.BeginAnimation(OpacityProperty, start);
            };
            IUser.BeginAnimation(OpacityProperty, start);
        }
    }
}
