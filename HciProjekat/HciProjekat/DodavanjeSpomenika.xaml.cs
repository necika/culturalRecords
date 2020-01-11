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
    /// Interaction logic for DodavanjeSpomenika.xaml
    /// </summary>
    public partial class DodavanjeSpomenika : Window
    {



        public static ObservableCollection<string> Pomocni
        {
            get;
            set;
        }

        public static ObservableCollection<NazivSlika> slicice1
        {
            get;
            set;
        }


        public static ObservableCollection<Model1> Spomenici1
        {
            get;
            set;
        }

        public static ObservableCollection<Model2> Etikete
        {
            get;
            set;
        }

        public int brojac = 0;
        public static bool prazan = false;
        public static MainWindow main;

        public DodavanjeSpomenika()
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
            


            textBoxGodisnjiPrihod.Text = "0";
            comboEra.SelectedIndex = 0;
            comboStatus.SelectedIndex = 0;
           ;

            //inicijalizacija pri prvom prolasku samo
            if (MainWindow.spomenik1 == 0)
            {
                MainWindow.Spomenici1 = new ObservableCollection<Model1>();
                Spomenici1 = new ObservableCollection<Model1>();
                Pomocni = new ObservableCollection<string>();
                
                slicice1 = new ObservableCollection<NazivSlika>();
                slicice1 = DodavanjeTipaSpomenika.slicice;

                
            }
            else
            {
                Pomocni = new ObservableCollection<string>();
               
            }
            MainWindow.spomenik1++;



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
                    validacijaSlika.Text = "Molimo izabarite jpg fajl.";
                    validacijaSlika.Foreground = Brushes.Red;
                }
            }


        }





        private void click_dodaj_spomenik(object sender, RoutedEventArgs e)
        {

            Model1 spomenik = new Model1();


            spomenik.Oznaka = textBoxOznaka.Text;
            spomenik.Ime = textBoxIme.Text;
            spomenik.Opis = textBoxOpis.Text;
            spomenik.Tip = textBoxTip.Text;



            if (textBoxDatumOtkrivanja.SelectedDate != null)
            {
                 spomenik.DatumOtkrivanja = textBoxDatumOtkrivanja.SelectedDate.Value.Date;
                

            }
            else
            {
                
                validacijaDatumOtkrivanja.Text = "Molimo unesite datum otkrivanja.";
                validacijaDatumOtkrivanja.Foreground = Brushes.Red;

                if (textBoxOznaka.Text == "")
                {
                   
                    validacijaOznaka.Text = "Molimo unesite oznaku spomenika.";
                    validacijaOznaka.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOznaka.Text = "";
                }

                if (textBoxIme.Text == "")
                {
                   
                    validacijaIme.Text = "Molimo unesite ime spomenika.";
                    validacijaIme.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaIme.Text = "";
                }

                if (textBoxOpis.Text == "")
                {
                   
                    validacijaOpis.Text = "Molimo unesite opis spomenika.";
                    validacijaOpis.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOpis.Text = "";
                }

                if (textBoxTip.Text == "")
                {
                    
                    validacijaTip.Text = "Molimo unesite tip spomenika.";
                    validacijaTip.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTip.Text = "";
                }

                if (textBoxGodisnjiPrihod.Text == "")
                {
                   
                    validacijaGodisnjiPrihod.Text = "Molimo unesite prihod spomenika.";
                    validacijaGodisnjiPrihod.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaGodisnjiPrihod.Text = "";
                }

                if (comboEra.Text == "")
                {
                   
                    validacijaEra.Text = "Molimo izaberite eru spomenika.";
                    validacijaEra.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaEra.Text = "";
                }

                if (comboStatus.Text == "")
                {
                   
                    validacijaTuristickiStatus.Text = "Molimo izaberite status spomenika.";
                    validacijaTuristickiStatus.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTuristickiStatus.Text = "";
                }

                

                if (myImage2.Source == null)
                {
                    
                    validacijaSlika.Text = "Bice izabrana slika tipa.";
                    validacijaSlika.Foreground = Brushes.CornflowerBlue;
                }
                else
                {
                    validacijaSlika.Text = "";
                }


            }
            if (myImage2.Source != null)
            {
                
                spomenik.Ikonica = myImage2.Source;
            }
            else
            {
                if (MainWindow.TipoviTree != null) {
                    foreach (Model3 m3 in MainWindow.TipoviTree) {
                        if (m3.Oznaka == spomenik.Tip) {
                            spomenik.Ikonica = m3.Ikonica;
                            break;
                        }
                    }
                }




                validacijaSlika.Text = "Bice izabrana slika tipa.";
                validacijaSlika.Foreground = Brushes.CornflowerBlue;

                if (textBoxOznaka.Text == "")
                {
                    
                    validacijaOznaka.Text = "Molimo unesite oznaku spomenika.";
                    validacijaOznaka.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOznaka.Text = "";
                }

                if (textBoxIme.Text == "")
                {
                    
                    validacijaIme.Text = "Molimo unesite ime spomenika.";
                    validacijaIme.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaIme.Text = "";
                }

                if (textBoxOpis.Text == "")
                {
                    
                    validacijaOpis.Text = "Molimo unesite opis spomenika.";
                    validacijaOpis.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOpis.Text = "";
                }

                if (textBoxTip.Text == "")
                {
                    
                    validacijaTip.Text = "Molimo unesite tip spomenika.";
                    validacijaTip.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTip.Text = "";
                }

                if (textBoxGodisnjiPrihod.Text == "")
                {
                    
                    validacijaGodisnjiPrihod.Text = "Molimo unesite prihod spomenika.";
                    validacijaGodisnjiPrihod.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaGodisnjiPrihod.Text = "";
                }

                if (comboEra.Text == "")
                {
                    
                    validacijaEra.Text = "Molimo izaberite eru spomenika.";
                    validacijaEra.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaEra.Text = "";
                }

                if (comboStatus.Text == "")
                {
                    
                    validacijaTuristickiStatus.Text = "Molimo izaberite status spomenika.";
                    validacijaTuristickiStatus.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTuristickiStatus.Text = "";
                }

                

                if (textBoxDatumOtkrivanja.Text == "")
                {
                    
                    validacijaDatumOtkrivanja.Text = "Molimo unesite datum otkrivanja.";
                    validacijaDatumOtkrivanja.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaDatumOtkrivanja.Text = "";
                }




            }


            if (textBoxGodisnjiPrihod.Text != "")
            {
                spomenik.Prihod = Convert.ToSingle(textBoxGodisnjiPrihod.Text);
            }

            if (Arheoloski_obradjen.IsChecked == true)
            {

                spomenik.ArhObradjen = true;
            }
            if (Pripada_UNESKO.IsChecked == true)
            {
                spomenik.PripadaUnesko = true;
            }
            if (Pripada_naseljenom_mjestu.IsChecked == true)
            {
                spomenik.PripadaNaseljenom = true;
            }

            if (comboEra.Text != "")
            {
                spomenik.Era = comboEra.Text;
            }
            if (comboStatus.Text != "")
            {
                spomenik.TuristickiStatus = comboStatus.Text;
            }
            




            this.DataContext = this;




            if (textBoxOznaka.Text == "")
            {
                
                validacijaOznaka.Text = "Molimo unesite oznaku spomenika.";
                validacijaOznaka.Foreground = Brushes.Red;

                if (myImage2.Source == null)
                {
                    validacijaSlika.Text = "Bice izabrana slika tipa.";
                    validacijaSlika.Foreground = Brushes.CornflowerBlue;
                }
                else
                {
                    validacijaSlika.Text = "";
                }

                if (textBoxIme.Text == "")
                {
                    validacijaIme.Text = "Molimo unesite ime spomenika.";
                    validacijaIme.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaIme.Text = "";
                }

                if (textBoxOpis.Text == "")
                {
                    validacijaOpis.Text = "Molimo unesite opis spomenika.";
                    validacijaOpis.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOpis.Text = "";
                }

                if (textBoxTip.Text == "")
                {
                    validacijaTip.Text = "Molimo unesite tip spomenika.";
                    validacijaTip.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTip.Text = "";
                }

                if (textBoxGodisnjiPrihod.Text == "")
                {
                    validacijaGodisnjiPrihod.Text = "Molimo unesite prihod spomenika.";
                    validacijaGodisnjiPrihod.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaGodisnjiPrihod.Text = "";
                }

                if (comboEra.Text == "")
                {
                    validacijaEra.Text = "Molimo izaberite eru spomenika.";
                    validacijaEra.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaEra.Text = "";
                }

                if (comboStatus.Text == "")
                {
                    validacijaTuristickiStatus.Text = "Molimo izaberite status spomenika.";
                    validacijaTuristickiStatus.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTuristickiStatus.Text = "";
                }

                

                if (textBoxDatumOtkrivanja.Text == "")
                {
                    validacijaDatumOtkrivanja.Text = "Molimo unesite datum otkrivanja.";
                    validacijaDatumOtkrivanja.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaDatumOtkrivanja.Text = "";
                }
            }

            else if (textBoxIme.Text == "")
            {
                
                validacijaIme.Text = "Molimo unesite ime spomenika.";
                validacijaIme.Foreground = Brushes.Red;

                if (myImage2.Source == null)
                {
                    validacijaSlika.Text = "Bice izabrana slika tipa.";
                    validacijaSlika.Foreground = Brushes.CornflowerBlue;
                }
                else
                {
                    validacijaSlika.Text = "";
                }

                if (textBoxOznaka.Text == "")
                {
                    validacijaOznaka.Text = "Molimo unesite oznaku spomenika.";
                    validacijaOznaka.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOznaka.Text = "";
                }

                if (textBoxOpis.Text == "")
                {
                    validacijaOpis.Text = "Molimo unesite opis spomenika.";
                    validacijaOpis.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOpis.Text = "";
                }

                if (textBoxTip.Text == "")
                {
                    validacijaTip.Text = "Molimo unesite tip spomenika.";
                    validacijaTip.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTip.Text = "";
                }

                if (textBoxGodisnjiPrihod.Text == "")
                {
                    validacijaGodisnjiPrihod.Text = "Molimo unesite prihod spomenika.";
                    validacijaGodisnjiPrihod.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaGodisnjiPrihod.Text = "";
                }

                if (comboEra.Text == "")
                {
                    validacijaEra.Text = "Molimo izaberite eru spomenika.";
                    validacijaEra.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaEra.Text = "";
                }

                if (comboStatus.Text == "")
                {
                    validacijaTuristickiStatus.Text = "Molimo izaberite status spomenika.";
                    validacijaTuristickiStatus.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTuristickiStatus.Text = "";
                }

                

                if (textBoxDatumOtkrivanja.Text == "")
                {
                    validacijaDatumOtkrivanja.Text = "Molimo unesite datum otkrivanja.";
                    validacijaDatumOtkrivanja.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaDatumOtkrivanja.Text = "";
                }
            }
            else if (textBoxTip.Text == "")
            {
              
                validacijaTip.Text = "Molimo unesite tip spomenika.";
                validacijaTip.Foreground = Brushes.Red;

                if (myImage2.Source == null)
                {
                    validacijaSlika.Text = "Bice izabrana slika tipa.";
                    validacijaSlika.Foreground = Brushes.CornflowerBlue;
                }
                else
                {
                    validacijaSlika.Text = "";
                }

                if (textBoxOznaka.Text == "")
                {
                    validacijaOznaka.Text = "Molimo unesite oznaku spomenika.";
                    validacijaOznaka.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOznaka.Text = "";
                }

                if (textBoxOpis.Text == "")
                {
                    validacijaOpis.Text = "Molimo unesite opis spomenika.";
                    validacijaOpis.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOpis.Text = "";
                }

                if (textBoxIme.Text == "")
                {
                    validacijaIme.Text = "Molimo unesite ime spomenika.";
                    validacijaIme.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaIme.Text = "";
                }

                if (textBoxGodisnjiPrihod.Text == "")
                {
                    validacijaGodisnjiPrihod.Text = "Molimo unesite prihod spomenika.";
                    validacijaGodisnjiPrihod.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaGodisnjiPrihod.Text = "";
                }

                if (comboEra.Text == "")
                {
                    validacijaEra.Text = "Molimo izaberite eru spomenika.";
                    validacijaEra.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaEra.Text = "";
                }

                if (comboStatus.Text == "")
                {
                    validacijaTuristickiStatus.Text = "Molimo izaberite status spomenika.";
                    validacijaTuristickiStatus.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTuristickiStatus.Text = "";
                }

                

                if (textBoxDatumOtkrivanja.Text == "")
                {
                    validacijaDatumOtkrivanja.Text = "Molimo unesite datum otkrivanja.";
                    validacijaDatumOtkrivanja.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaDatumOtkrivanja.Text = "";
                }
            }
            else if (textBoxOpis.Text == "")
            {
               
                validacijaOpis.Text = "Molimo unesite opis spomenika.";
                validacijaOpis.Foreground = Brushes.Red;

                if (myImage2.Source == null)
                {
                    validacijaSlika.Text = "Bice izabrana slika tipa.";
                    validacijaSlika.Foreground = Brushes.CornflowerBlue;
                }
                else
                {
                    validacijaSlika.Text = "";
                }

                if (textBoxOznaka.Text == "")
                {
                    validacijaOznaka.Text = "Molimo unesite oznaku spomenika.";
                    validacijaOznaka.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOznaka.Text = "";
                }

                if (textBoxTip.Text == "")
                {
                    validacijaTip.Text = "Molimo unesite tip spomenika.";
                    validacijaTip.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTip.Text = "";
                }

                if (textBoxIme.Text == "")
                {
                    validacijaIme.Text = "Molimo unesite ime spomenika.";
                    validacijaIme.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaIme.Text = "";
                }

                if (textBoxGodisnjiPrihod.Text == "")
                {
                    validacijaGodisnjiPrihod.Text = "Molimo unesite prihod spomenika.";
                    validacijaGodisnjiPrihod.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaGodisnjiPrihod.Text = "";
                }

                if (comboEra.Text == "")
                {
                    validacijaEra.Text = "Molimo izaberite eru spomenika.";
                    validacijaEra.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaEra.Text = "";
                }

                if (comboStatus.Text == "")
                {
                    validacijaTuristickiStatus.Text = "Molimo izaberite status spomenika.";
                    validacijaTuristickiStatus.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTuristickiStatus.Text = "";
                }
                

                if (textBoxDatumOtkrivanja.Text == "")
                {
                    validacijaDatumOtkrivanja.Text = "Molimo unesite datum otkrivanja.";
                    validacijaDatumOtkrivanja.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaDatumOtkrivanja.Text = "";
                }
            }
            else if (textBoxGodisnjiPrihod.Text == "")
            {
               
                validacijaGodisnjiPrihod.Text = "Molimo unesite prihod spomenika.";
                validacijaGodisnjiPrihod.Foreground = Brushes.Red;

                if (myImage2.Source == null)
                {
                    validacijaSlika.Text = "Bice izabrana slika tipa.";
                    validacijaSlika.Foreground = Brushes.CornflowerBlue;
                }
                else
                {
                    validacijaSlika.Text = "";
                }

                if (textBoxOznaka.Text == "")
                {
                    validacijaOznaka.Text = "Molimo unesite oznaku spomenika.";
                    validacijaOznaka.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOznaka.Text = "";
                }

                if (textBoxTip.Text == "")
                {
                    validacijaTip.Text = "Molimo unesite tip spomenika.";
                    validacijaTip.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTip.Text = "";
                }

                if (textBoxIme.Text == "")
                {
                    validacijaIme.Text = "Molimo unesite ime spomenika.";
                    validacijaIme.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaIme.Text = "";
                }

                if (textBoxOpis.Text == "")
                {
                    validacijaOpis.Text = "Molimo unesite opis spomenika.";
                    validacijaOpis.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOpis.Text = "";
                }

                if (comboEra.Text == "")
                {
                    validacijaEra.Text = "Molimo izaberite eru spomenika.";
                    validacijaEra.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaEra.Text = "";
                }

                if (comboStatus.Text == "")
                {
                    validacijaTuristickiStatus.Text = "Molimo izaberite status spomenika.";
                    validacijaTuristickiStatus.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTuristickiStatus.Text = "";
                }

                

                if (textBoxDatumOtkrivanja.Text == "")
                {
                    validacijaDatumOtkrivanja.Text = "Molimo unesite datum otkrivanja.";
                    validacijaDatumOtkrivanja.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaDatumOtkrivanja.Text = "";
                }
            }
            else if (comboEra.Text == "")
            {
                
                validacijaEra.Text = "Molimo izaberite eru spomenika.";
                validacijaEra.Foreground = Brushes.Red;

                if (myImage2.Source == null)
                {
                    validacijaSlika.Text = "Bice izabrana slika tipa.";
                    validacijaSlika.Foreground = Brushes.CornflowerBlue;
                }
                else
                {
                    validacijaSlika.Text = "";
                }

                if (textBoxOznaka.Text == "")
                {
                    validacijaOznaka.Text = "Molimo unesite oznaku spomenika.";
                    validacijaOznaka.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOznaka.Text = "";
                }

                if (textBoxTip.Text == "")
                {
                    validacijaTip.Text = "Molimo unesite tip spomenika.";
                    validacijaTip.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTip.Text = "";
                }

                if (textBoxIme.Text == "")
                {
                    validacijaIme.Text = "Molimo unesite ime spomenika.";
                    validacijaIme.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaIme.Text = "";
                }

                if (textBoxOpis.Text == "")
                {
                    validacijaOpis.Text = "Molimo unesite opis spomenika.";
                    validacijaOpis.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOpis.Text = "";
                }

                if (textBoxGodisnjiPrihod.Text == "")
                {
                    validacijaGodisnjiPrihod.Text = "Molimo unesite prihod spomenika.";
                    validacijaGodisnjiPrihod.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaGodisnjiPrihod.Text = "";
                }

                if (comboStatus.Text == "")
                {
                    validacijaTuristickiStatus.Text = "Molimo izaberite status spomenika.";
                    validacijaTuristickiStatus.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTuristickiStatus.Text = "";
                }

                

                if (textBoxDatumOtkrivanja.Text == "")
                {
                    validacijaDatumOtkrivanja.Text = "Molimo unesite datum otkrivanja.";
                    validacijaDatumOtkrivanja.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaDatumOtkrivanja.Text = "";
                }
            }
            else if (comboStatus.Text == "")
            {
                
                validacijaTuristickiStatus.Text = "Molimo izaberite status spomenika.";
                validacijaTuristickiStatus.Foreground = Brushes.Red;

                if (myImage2.Source == null)
                {
                    validacijaSlika.Text = "Bice izabrana slika tipa.";
                    validacijaSlika.Foreground = Brushes.CornflowerBlue;
                }
                else
                {
                    validacijaSlika.Text = "";
                }

                if (textBoxOznaka.Text == "")
                {
                    validacijaOznaka.Text = "Molimo unesite oznaku spomenika.";
                    validacijaOznaka.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOznaka.Text = "";
                }

                if (textBoxTip.Text == "")
                {
                    validacijaTip.Text = "Molimo unesite tip spomenika.";
                    validacijaTip.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaTip.Text = "";
                }

                if (textBoxIme.Text == "")
                {
                    validacijaIme.Text = "Molimo unesite ime spomenika.";
                    validacijaIme.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaIme.Text = "";
                }

                if (textBoxOpis.Text == "")
                {
                    validacijaOpis.Text = "Molimo unesite opis spomenika.";
                    validacijaOpis.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOpis.Text = "";
                }

                if (textBoxGodisnjiPrihod.Text == "")
                {
                    validacijaGodisnjiPrihod.Text = "Molimo unesite prihod spomenika.";
                    validacijaGodisnjiPrihod.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaGodisnjiPrihod.Text = "";
                }

                if (comboEra.Text == "")
                {
                    validacijaEra.Text = "Molimo izaberite eru spomenika.";
                    validacijaEra.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaEra.Text = "";
                }

                

                if (textBoxDatumOtkrivanja.Text == "")
                {
                    validacijaDatumOtkrivanja.Text = "Molimo unesite datum otkrivanja.";
                    validacijaDatumOtkrivanja.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaDatumOtkrivanja.Text = "";
                }
            }
 
            else
            {
                Boolean vecPostojiOznaka = false;
                if (MainWindow.Spomenici1 != null)
                {
                    foreach (Model1 et in MainWindow.Spomenici1)
                    {
                        if (et.Oznaka == textBoxOznaka.Text)
                        {
                            
                            vecPostojiOznaka = true;
                            validacijaOznaka.Text = "Molimo unesite neku drugu oznaku.";
                            validacijaOznaka.Foreground = Brushes.Red;

                            if (myImage2.Source == null)
                            {
                                validacijaSlika.Text = "Bice izabrana slika tipa.";
                                validacijaSlika.Foreground = Brushes.CornflowerBlue;
                            }
                            else
                            {
                                validacijaSlika.Text = "";
                            }

                            if (textBoxIme.Text == "")
                            {
                                validacijaIme.Text = "Molimo unesite ime spomenika.";
                                validacijaIme.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaIme.Text = "";
                            }

                            if (textBoxOpis.Text == "")
                            {
                                validacijaOpis.Text = "Molimo unesite opis spomenika.";
                                validacijaOpis.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaOpis.Text = "";
                            }

                            if (textBoxTip.Text == "")
                            {
                                validacijaTip.Text = "Molimo unesite tip spomenika.";
                                validacijaTip.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaTip.Text = "";
                            }

                            if (textBoxGodisnjiPrihod.Text == "")
                            {
                                validacijaGodisnjiPrihod.Text = "Molimo unesite prihod spomenika.";
                                validacijaGodisnjiPrihod.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaGodisnjiPrihod.Text = "";
                            }

                            if (comboEra.Text == "")
                            {
                                validacijaEra.Text = "Molimo izaberite eru spomenika.";
                                validacijaEra.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaEra.Text = "";
                            }

                            if (comboStatus.Text == "")
                            {
                                validacijaTuristickiStatus.Text = "Molimo izaberite status spomenika.";
                                validacijaTuristickiStatus.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaTuristickiStatus.Text = "";
                            }

                            

                            if (textBoxDatumOtkrivanja.Text == "")
                            {
                                validacijaDatumOtkrivanja.Text = "Molimo unesite datum otkrivanja.";
                                validacijaDatumOtkrivanja.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaDatumOtkrivanja.Text = "";
                            }



                            break;
                        }
                    }
                }
                if (MainWindow.Spomenicici != null)
                {
                    foreach (Model1 et in MainWindow.Spomenicici)
                    {
                        if (et.Oznaka == textBoxOznaka.Text)
                        {
                            vecPostojiOznaka = true;
                            validacijaOznaka.Text = "Molimo unesite neku drugu oznaku.";
                           
                            validacijaOznaka.Foreground = Brushes.Red;

                            if (myImage2.Source == null)
                            {
                                validacijaSlika.Text = "Bice izabrana slika tipa.";
                                validacijaSlika.Foreground = Brushes.CornflowerBlue;
                            }
                            else
                            {
                                validacijaSlika.Text = "";
                            }

                            if (textBoxIme.Text == "")
                            {
                                validacijaIme.Text = "Molimo unesite ime spomenika.";
                                validacijaIme.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaIme.Text = "";
                            }

                            if (textBoxOpis.Text == "")
                            {
                                validacijaOpis.Text = "Molimo unesite opis spomenika.";
                                validacijaOpis.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaOpis.Text = "";
                            }

                            if (textBoxTip.Text == "")
                            {
                                validacijaTip.Text = "Molimo unesite tip spomenika.";
                                validacijaTip.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaTip.Text = "";
                            }

                            if (textBoxGodisnjiPrihod.Text == "")
                            {
                                validacijaGodisnjiPrihod.Text = "Molimo unesite prihod spomenika.";
                                validacijaGodisnjiPrihod.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaGodisnjiPrihod.Text = "";
                            }

                            if (comboEra.Text == "")
                            {
                                validacijaEra.Text = "Molimo izaberite eru spomenika.";
                                validacijaEra.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaEra.Text = "";
                            }

                            if (comboStatus.Text == "")
                            {
                                validacijaTuristickiStatus.Text = "Molimo izaberite status spomenika.";
                                validacijaTuristickiStatus.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaTuristickiStatus.Text = "";
                            }

                            

                            if (textBoxDatumOtkrivanja.Text == "")
                            {
                                validacijaDatumOtkrivanja.Text = "Molimo unesite datum otkrivanja.";
                                validacijaDatumOtkrivanja.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaDatumOtkrivanja.Text = "";
                            }
                            break;
                        }
                    }
                }





                if (vecPostojiOznaka == false)
                {
                    foreach (Model2 element in etiketaSelect.SelectedItems)
                    {
                        spomenik.Etikete.Add(element.Oznaka);
                    } 

                    MainWindow.Spomenici1.Add(spomenik);

                    main.statusBar.Text = "Dodat spomenik sa oznakom " + textBoxOznaka.Text + " .";
                    main.statusBar.Foreground = Brushes.Green;


                    brojac++;
                    prazan = true;

                    validacijaOznaka.Text = "";
                    validacijaIme.Text = "";
                    validacijaOpis.Text = "";
                    validacijaTip.Text = "";
                    validacijaGodisnjiPrihod.Text = "";
                    validacijaDatumOtkrivanja.Text = "";
                    validacijaEra.Text = "";
                    validacijaTuristickiStatus.Text = "";
                    validacijaTagovani.Text = "";
                    validacijaSlika.Text = "";


                    foreach (Model3 m in MainWindow.TipoviTree) {
                        if (m.Oznaka == textBoxTip.Text) {
                            m.spomeniciUnutarTipova.Add(spomenik);
                            break;
                        }
                    }


                    textBoxDatumOtkrivanja.SelectedDate = null;
                    textBoxIme.Text = "";
                    textBoxGodisnjiPrihod.Text = "0";
                    textBoxOpis.Text = "";
                    textBoxOznaka.Text = "";
                    textBoxTip.SelectedIndex = -1;
                    comboEra.SelectedIndex = 0;
                    comboStatus.SelectedIndex = 0;
                    comboStatus.SelectedIndex = 0;
                    myImage2.Source = null;


                    this.Close();
                    TableExample s = new TableExample();
                    s.Show();
                }

            }
            
        }

        private void click_prikaz_spomenika(object sender, RoutedEventArgs e)
        {
            TableExample s = new TableExample();
            s.Show();
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
