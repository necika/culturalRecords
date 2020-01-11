using Microsoft.Win32;
using PrimerCas4.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for DodavanjeTipaSpomenika.xaml
    /// </summary>
    public partial class DodavanjeTipaSpomenika : Window
    {
        public static bool prazan = false;
        public int brojac = 0;
        
        public static ImageSource pada;

        public static ObservableCollection<NazivSlika> slicice
        {
            get;
            set;
        }
        public Boolean dodatTip = false;

        String temp = "";

        public static MainWindow main;


        //tipovi spomenika



        public DodavanjeTipaSpomenika()
        {
            InitializeComponent();
            if (MainWindow.tipSpomenika1 == 0)
            {
                MainWindow.Tipovi1 = new ObservableCollection<Model3>();
                slicice = new ObservableCollection<NazivSlika>();
            }
            MainWindow.tipSpomenika1++;
            
            

            
        }
        

        private void click_dodaj_tip_spomenika(object sender, RoutedEventArgs e)
        {
            dodatTip = false;
            Model3 tip = new Model3();
            
            tip.Oznaka = textBoxOznaka.Text;
            tip.Ime = textBoxIme.Text;
            tip.Opis = textBoxOpis.Text;
            tip.Ikonica = myImage2.Source;


            if (textBoxOznaka.Text == "")
            {
                validacijaOznaka.Text = "Molimo unesite oznaku tipa.";
                validacijaOznaka.Foreground = Brushes.Red;
                statusTip.Text = "";

                if (textBoxIme.Text == "")
                {
                    validacijaIme.Text = "Molimo unesite ime tipa.";
                    validacijaIme.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaIme.Text = "";
                }
                if (textBoxOpis.Text == "")
                {
                    validacijaOpis.Text = "Molimo unesite opis tipa.";
                    validacijaOpis.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOpis.Text = "";
                }
                if (myImage2.Source == null)
                {
                    validacijaSlika.Text = "Molimo unesite sliku tipa.";
                    validacijaSlika.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaSlika.Text = "";
                }



            }
            else if (textBoxIme.Text == "")
            {
                validacijaIme.Text = "Molimo unesite ime tipa.";
                validacijaIme.Foreground = Brushes.Red;
                statusTip.Text = "";

                if (textBoxOznaka.Text == "")
                {
                    validacijaOznaka.Text = "Molimo unesite oznaku tipa.";
                    validacijaOznaka.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOznaka.Text = "";
                }
                if (textBoxOpis.Text == "")
                {
                    validacijaOpis.Text = "Molimo unesite opis tipa.";
                    validacijaOpis.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOpis.Text = "";
                }
                if (myImage2.Source == null)
                {
                    validacijaSlika.Text = "Molimo unesite sliku tipa.";
                    validacijaSlika.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaSlika.Text = "";
                }


            }
            else if (textBoxOpis.Text == "")
            {
                validacijaOpis.Text = "Molimo unesite opis tipa.";
                validacijaOpis.Foreground = Brushes.Red;
                statusTip.Text = "";

                if (textBoxIme.Text == "")
                {
                    validacijaIme.Text = "Molimo unesite ime tipa.";
                    validacijaIme.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaIme.Text = "";
                }
                if (textBoxOznaka.Text == "")
                {
                    validacijaOznaka.Text = "Molimo unesite oznaku tipa.";
                    validacijaOznaka.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOznaka.Text = "";
                }
                if (myImage2.Source == null)
                {
                    validacijaSlika.Text = "Molimo unesite sliku tipa.";
                    validacijaSlika.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaSlika.Text = "";
                }
            }
            else if (myImage2.Source == null)
            {
                validacijaSlika.Text = "Molimo unesite sliku tipa.";
                validacijaSlika.Foreground = Brushes.Red;
                statusTip.Text = "";

                if (textBoxIme.Text == "")
                {
                    validacijaIme.Text = "Molimo unesite ime tipa.";
                    validacijaIme.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaIme.Text = "";
                }
                if (textBoxOznaka.Text == "")
                {
                    validacijaOznaka.Text = "Molimo unesite oznaku tipa.";
                    validacijaOznaka.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOznaka.Text = "";
                }
                if (textBoxOpis.Text == "")
                {
                    validacijaOpis.Text = "Molimo unesite opis tipa.";
                    validacijaOpis.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOpis.Text = "";
                }
            }
            else
            {
                Boolean vecPostojiOznaka = false;
                if (MainWindow.Tipovi1 != null)
                {
                    foreach (Model3 et in MainWindow.Tipovi1)
                    {
                        if (et.Oznaka == textBoxOznaka.Text)
                        {
                            vecPostojiOznaka = true;
                            validacijaOznaka.Text = "Molimo unesite neku drugu oznaku.";
                            validacijaOznaka.Foreground = Brushes.Red;
                            statusTip.Text = "";

                            if (textBoxIme.Text == "")
                            {
                                validacijaIme.Text = "Molimo unesite ime tipa.";
                                validacijaIme.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaIme.Text = "";
                            }
                            if (textBoxOpis.Text == "")
                            {
                                validacijaOpis.Text = "Molimo unesite opis tipa.";
                                validacijaOpis.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaOpis.Text = "";
                            }
                            if (myImage2.Source == null)
                            {
                                validacijaSlika.Text = "Molimo unesite sliku tipa.";
                                validacijaSlika.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaSlika.Text = "";
                            }



                            break;
                        }
                    }
                }
                if (MainWindow.Tipovici != null)
                {
                    foreach (Model3 et in MainWindow.Tipovici)
                    {
                        if (et.Oznaka == textBoxOznaka.Text)
                        {
                            vecPostojiOznaka = true;
                            statusTip.Text = "";
                            validacijaOznaka.Text = "Molimo unesite neku drugu oznaku.";
                            validacijaOznaka.Foreground = Brushes.Red;

                            if (textBoxIme.Text == "")
                            {
                                validacijaIme.Text = "Molimo unesite ime tipa.";
                                validacijaIme.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaIme.Text = "";
                            }
                            if (textBoxOpis.Text == "")
                            {
                                validacijaOpis.Text = "Molimo unesite opis tipa.";
                                validacijaOpis.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaOpis.Text = "";
                            }
                            if (myImage2.Source == null)
                            {
                                validacijaSlika.Text = "Molimo unesite sliku tipa.";
                                validacijaSlika.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaSlika.Text = "";
                            }
                            break;
                        }
                    }
                }





                if (vecPostojiOznaka == false)
                {

                    validacijaIme.Text = "";
                    validacijaOznaka.Text = "";
                    validacijaOpis.Text = "";
                    validacijaSlika.Text = "";
                    statusTip.Text = "Dodat tip";

                    main.statusBar.Text = "Dodat tip sa oznakom "+textBoxOznaka.Text+" .";
                    main.statusBar.Foreground = Brushes.Green;




                    MainWindow.TipoviTree.Add(tip);


                    MainWindow.Tipovi1.Add(tip);
                    prazan = true;
                   
                    brojac++;

                    MainWindow.readFromFileTipoveZaSpomenike();
                    foreach (Model3 item in MainWindow.Tipovi1)
                    {

                        Model3._sadrzaniSpomenici.Add(item.Oznaka);
                    }
                    NazivSlika ns = new NazivSlika();

                    ns.Oznaka = tip.Oznaka;
                    ns.Slika = tip.Ikonica;

                    slicice.Add(ns);

                    textBoxIme.Text = "";
                    textBoxOpis.Text = "";
                    textBoxOznaka.Text = "";
                    myImage2.Source = null;

                    dodatTip = true;

                    this.Close();
                    PrikazTipaSpomenika p = new PrikazTipaSpomenika();
                    p.Show();
                }

                


            }
            

        }

        private void click_prikaz_tipa_spomenika(object sender, RoutedEventArgs e)
        {
            MainWindow.resetujTree();
            PrikazTipaSpomenika s = new PrikazTipaSpomenika();
            s.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();

            String selectedImage = open.FileName;




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
                    MessageBox.Show("Molimo Vas ubacite .jpg fajl.");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _ime;
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;

                }
            }
        }
        private string _oznaka;
        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;

                }
            }
        }

        private string _opis;
        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;

                }
            }
        }


        private bool oznakaOK = false;
        private bool imeOK = false;
        private bool prihodOK = true;
        private bool slobodnoIme = true;
        private bool slobodnaOznaka = true;

        private void xOznaka_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;



            if (tb.Text.Length < 3)
            {
                oznakaOK = false;
            }
            else
            {
                oznakaOK = true;
            }

            if (PrikazTipaSpomenika.Tipovi != null)
            {
                foreach (Model3 s in PrikazTipaSpomenika.Tipovi)
                {
                    if (!s.Oznaka.Equals(tb.Text))
                    {
                        slobodnaOznaka = true;
                    }
                    else
                    {
                        slobodnaOznaka = false;
                        break;
                    }
                }


            }
        }

        private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // MainWindow.resetujTree();
        }

        public void ispisiStatus(MainWindow m,String s) {
            
        }
    }
}
