using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HciProjekat
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static MainWindow main;

        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // LOGIN RADITI
            string[] lines = System.IO.File.ReadAllLines("Registracija.txt");
            foreach (string line in lines)
            {
                if (!lines[0].Equals(""))
                {

                   String[] temp3 = line.Split(' ');

                    String ime = temp3[0];
                    String lozinka = temp3[1];

                    if (txtIme.Text == ime && txtLozinka.Password.ToString() == lozinka)
                    {
                        txtIme.Text = "";
                        txtLozinka.Password = "";
                        MainWindow.prijavljen = true;
                        txtUspesno.Text = "Uspesno";
                        txtUspesno.Foreground = Brushes.Green;

                        Uri myUri = new Uri("correct.jpg", UriKind.RelativeOrAbsolute);
                        JpegBitmapDecoder decoder2 = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                        BitmapSource bitmapSource2 = decoder2.Frames[0];

                        // Draw the Image
                        //myImage2.Source = bitmapSource2;
                        main.statusBar.Text = "Uspesno ste se prijavili .";
                        main.statusBar.Foreground = Brushes.Green;
                        this.Close();

                        break;
                        
                    }
                    else {
                        myImage2.Source = null;
                        lblIme.Text = "Neispravno";
                        lblIme.Foreground = Brushes.Red;

                        lblLozinka.Text = "Neispravno";
                        lblLozinka.Foreground = Brushes.Red;
                    }
                   




                }
            }
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Registracija s = new Registracija();
            s.Show();
            this.Close();
        }
    }
}
