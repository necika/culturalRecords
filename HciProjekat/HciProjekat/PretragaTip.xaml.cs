using Microsoft.Win32;
using PrimerCas4.Table;
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
    /// Interaction logic for PretragaTip.xaml
    /// </summary>
    public partial class PretragaTip : Window
    {
        public static Model3 tip;

        public PretragaTip()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();

            String selectedImage = open.FileName;




            if (selectedImage.Equals(""))
            {
                //Console.WriteLine("Warning : Niste uneli nijednu sliku.");
            }
            else
            {
                String[] niz = selectedImage.Split('.');



                if (niz[1].Equals("jpg"))
                {
                    Uri myUri = new Uri(selectedImage, UriKind.RelativeOrAbsolute);
                    JpegBitmapDecoder decoder2 = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    BitmapSource bitmapSource2 = decoder2.Frames[0];

                    // Draw the Image
                    myImage2.Source = bitmapSource2;
                    myImage2.Stretch = Stretch.Uniform;
                    myImage2.Margin = new Thickness(5);
                }
                else
                {
                    MessageBox.Show("Molimo Vas ubacite .jpg fajl.");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tip = new Model3();

            if (textBoxIme.Text != "" && textBoxIme.Text != null)
            {
                tip.Ime = textBoxIme.Text;
            }
            else
            {
                tip.Ime = "";
            }
            if (textBoxOpis.Text != "" && textBoxOpis.Text != null)
            {
                tip.Opis = textBoxOpis.Text;
            }
            else
            {
                tip.Opis = "";
            }
            if (textBoxOznaka.Text != "" && textBoxOznaka.Text != null)
            {
                tip.Oznaka = textBoxOznaka.Text;
            }
            else
            {
                tip.Oznaka = "";
            }
            if (myImage2.Source != null)
            {
                tip.Ikonica = myImage2.Source;
            }
            else
            {
                myImage2.Source = null;
            }

            
            PrikazTipaSpomenika s = new PrikazTipaSpomenika();
            s.Show();
            PrikazTipaSpomenika.pretraga();
            this.Close();
        }

        
        private void xOznaka_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}
