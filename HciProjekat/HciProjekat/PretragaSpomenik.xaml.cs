using Microsoft.Win32;
using PrimerCas4.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PretragaSpomenik.xaml
    /// </summary>
    public partial class PretragaSpomenik : Window
    {
        public static Model1 spomenik;
        public static ObservableCollection<Model2> Etikete
        {
            get;
            set;
        }


        public PretragaSpomenik()
        {
            this.DataContext = this;
            Etikete = new ObservableCollection<Model2>();

            if (MainWindow.Etiketice.Count != 0)
            {
                Etikete = MainWindow.Etiketice;
            }


            if (DodavanjeEtiketa.Etikete1 != null)
            {
                foreach (Model2 m2 in DodavanjeEtiketa.Etikete1)
                {
                    Etikete.Add(m2);
                    MainWindow.readFromFileEtikete();
                }
            }


            InitializeComponent();
        }

        private void click_browse(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();

            String selectedImage = open.FileName;
            Console.WriteLine(selectedImage);

            if (selectedImage.Equals(""))
            {
                Console.WriteLine("Warning : Niste uneli nijednu sliku.");
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
                    
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            spomenik = new Model1();

            if (textBoxIme.Text != "" && textBoxIme.Text != null)
            {
                spomenik.Ime = textBoxIme.Text;
            }
            else
            {
                spomenik.Ime = "";
            }
            if (textBoxOpis.Text != "" && textBoxOpis.Text != null)
            {
                spomenik.Opis = textBoxOpis.Text;
            }
            else
            {
                spomenik.Opis = "";
            }
            if (textBoxOznaka.Text != "" && textBoxOznaka.Text != null)
            {
                spomenik.Oznaka = textBoxOznaka.Text;
            }
            else
            {
                spomenik.Oznaka = "";
            }
            if (myImage2.Source != null)
            {
                spomenik.Ikonica = myImage2.Source;
            }
            else
            {
                myImage2.Source = null;
            }
            if (textBoxTip.Text != "" && textBoxTip.Text != null)
            {
                spomenik.Tip = textBoxTip.Text;
            }
            else
            {
                spomenik.Tip = "";
            }
            if (textBoxGodisnjiPrihod.Text != "" && textBoxGodisnjiPrihod.Text != null)
            {
                spomenik.Prihod = Convert.ToSingle(textBoxGodisnjiPrihod.Text);
            }
            else
            {
                spomenik.Prihod = 0;
            }
            if (textBoxDatumOtkrivanja.Text != "" && textBoxDatumOtkrivanja.Text != null)
            {
                spomenik.DatumOtkrivanja = textBoxDatumOtkrivanja.SelectedDate.Value.Date;
            }
            else
            {
               // spomenik.DatumOtkrivanja = "{5/29/2019 12:00:00 AM}";
            }
            if (Arheoloski_obradjen.IsChecked == true)
            {

                spomenik.ArhObradjen = true;
            }
            else {
                spomenik.ArhObradjen = false;
            }
            if (Pripada_naseljenom_mjestu.IsChecked == true)
            {

                spomenik.PripadaNaseljenom = true;
            }
            else
            {
                spomenik.PripadaNaseljenom = false;
            }
            if (Pripada_UNESKO.IsChecked == true)
            {

                spomenik.PripadaUnesko = true;
            }
            else
            {
                spomenik.PripadaUnesko = false;
            }

            if (comboEra.Text != "" && comboEra.Text != null)
            {
                spomenik.Era = comboEra.Text;
            }
            else
            {
                spomenik.Era = "";
            }
            if (comboStatus.Text != "" && comboStatus.Text != null)
            {
                spomenik.TuristickiStatus = comboStatus.Text;
            }
            else
            {
                spomenik.TuristickiStatus = "";
            }

            foreach (Model2 element in etiketaSelect.SelectedItems)
            {
                spomenik.Etikete.Add(element.Oznaka);
            }

            

            TableExample s = new TableExample();
            s.Show();
            TableExample.pretraga1();
            this.Close();

        }

        private void TextBoxTip_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;



            combo.ItemsSource = Model3._sadrzaniSpomenici;

        }

        private void TextBoxTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedComboItem = sender as ComboBox;
            string name = selectedComboItem.SelectedItem as string;

        }
    }
}
