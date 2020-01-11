using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            StreamWriter fileRegistracija = new StreamWriter("Registracija.txt");
            MainWindow.registracija.Add(txtIme.Text + " " + txtLozinka.Password.ToString());


            if (MainWindow.registracija != null)
            {
                foreach (String m in MainWindow.registracija)
                {
                    fileRegistracija.WriteLine(m);
                }
            }
            fileRegistracija.Close();


            Uri myUri = new Uri("correct.jpg", UriKind.RelativeOrAbsolute);
            JpegBitmapDecoder decoder2 = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource2 = decoder2.Frames[0];

            // Draw the Image
            myImage2.Source = bitmapSource2;
            txtIme.Text = "";
            txtLozinka.Password = "";
            txtUspesno.Text = "Uspesno logovanje.";

           
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Login s = new Login();
            s.Show();
            this.Close();
        }
    }
}
