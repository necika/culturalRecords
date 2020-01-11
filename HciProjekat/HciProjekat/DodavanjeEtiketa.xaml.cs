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
    /// Interaction logic for DodavanjeEtiketa.xaml
    /// </summary>
    public partial class DodavanjeEtiketa : Window
    {
        public static String s;
        public static bool prazan = false;
        public int brojac = 0;
        public static string bojica;
        public static byte red;
        public static byte green;
        public static byte blue;
        public static MainWindow main;


        public static ObservableCollection<Model2> Etikete1
        {
            get;
            set;
        }

        public static ObservableCollection<Color> sveBoje
        {
            get;
            set;
        }

        private void cp_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (textBoxBoja.SelectedColor.HasValue)
            {
                Color C = textBoxBoja.SelectedColor.Value;
                sveBoje.Add(textBoxBoja.SelectedColor.Value);


                red = new byte();

                red = C.R;
                green = C.G;
                blue = C.B;

                long colorVal = Convert.ToInt64(C.R * (Math.Pow(256, 0)) + C.G * (Math.Pow(256, 1)) + C.B * (Math.Pow(256, 2)));
                s = Convert.ToString(textBoxBoja.SelectedColor.Value);

            }

        }



        public DodavanjeEtiketa()
        {
            InitializeComponent();
            if (MainWindow.etiketa1 == 0)
            {
                Etikete1 = new ObservableCollection<Model2>();
            }
            MainWindow.etiketa1++;
        }

        private void click_dodaj_etiketu(object sender, RoutedEventArgs e)
        {
            Model2 etiketa = new Model2();



            // DA NE MOGU 2 ETIKETE SA ISTOM OZNAKOM

            etiketa.Oznaka = textBoxOznaka.Text;
            etiketa.Opis = textBoxOpis.Text;
            etiketa.Boja = s;


            this.DataContext = this;

            if (textBoxOznaka.Text == "")
            {
                statusEtiketa.Text = "";
                validacijaOznaka.Text = "Molimo unesite oznaku etikete.";
                validacijaOznaka.Foreground = Brushes.Red;

                if (textBoxBoja.SelectedColorText == "")
                {
                    validacijaBoja.Text = "Molimo unesite boju etikete.";
                    validacijaBoja.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaBoja.Text = "";
                }
                if (textBoxOpis.Text == "")
                {
                    validacijaOpis.Text = "Molimo unesite opis etikete.";
                    validacijaOpis.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOpis.Text = "";
                }
            }
            else if (textBoxOpis.Text == "")
            {
                statusEtiketa.Text = "";
                validacijaOpis.Text = "Molimo unesite opis etikete.";
                validacijaOpis.Foreground = Brushes.Red;

                if (textBoxBoja.SelectedColorText == "")
                {
                    validacijaBoja.Text = "Molimo unesite ime tipa.";
                    validacijaBoja.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaBoja.Text = "";
                }
                if (textBoxOznaka.Text == "")
                {
                    validacijaOznaka.Text = "Molimo unesite opis tipa.";
                    validacijaOznaka.Foreground = Brushes.Red;
                }
                else
                {
                    validacijaOznaka.Text = "";
                }
            }
            else if (textBoxBoja.SelectedColorText == "")
            {
                statusEtiketa.Text = "";
                validacijaBoja.Text = "Molimo unesite boju etikete.";
                validacijaBoja.Foreground = Brushes.Red;


                if (textBoxOznaka.Text == "")
                {
                    validacijaOznaka.Text = "Molimo unesite ime tipa.";
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
                if (DodavanjeEtiketa.Etikete1 != null)
                {
                    foreach (Model2 et in DodavanjeEtiketa.Etikete1)
                    {
                        if (et.Oznaka == textBoxOznaka.Text)
                        {
                            statusEtiketa.Text = "";
                            vecPostojiOznaka = true;
                            validacijaOznaka.Text = "Molimo unesite neku drugu oznaku.";
                            validacijaOznaka.Foreground = Brushes.Red;

                            if (textBoxBoja.SelectedColorText == "")
                            {
                                validacijaBoja.Text = "Molimo unesite ime tipa.";
                                validacijaBoja.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaBoja.Text = "";
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

                            break;
                        }
                    }
                }
                if (MainWindow.Etiketice != null)
                {
                    foreach (Model2 et in MainWindow.Etiketice)
                    {
                        if (et.Oznaka == textBoxOznaka.Text)
                        {
                            vecPostojiOznaka = true;
                            validacijaOznaka.Text = "Molimo unesite neku drugu oznaku.";
                            validacijaOznaka.Foreground = Brushes.Red;
                            statusEtiketa.Text = "";

                            if (textBoxBoja.SelectedColorText == "")
                            {
                                validacijaBoja.Text = "Molimo unesite ime tipa.";
                                validacijaBoja.Foreground = Brushes.Red;
                            }
                            else
                            {
                                validacijaBoja.Text = "";
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

                            break;
                        }
                    }
                }



                if (vecPostojiOznaka == false)
                {
                    validacijaOznaka.Text = "";
                    validacijaBoja.Text = "";
                    validacijaOpis.Text = "";
                    DodavanjeEtiketa.Etikete1.Add(etiketa);
                    prazan = true;
                   
                    brojac++;

                    main.statusBar.Text = "Dodata etiketa sa oznakom " + textBoxOznaka.Text + " .";
                    main.statusBar.Foreground = Brushes.Green;


                    textBoxOpis.Text = "";
                    textBoxBoja.SelectedColor = null;
                    textBoxOznaka.Text = "";
                    this.Close();
                    PrikazEtiketa s = new PrikazEtiketa();
                    s.Show();
                }
                
            }


            
        }

        private void click_prikaz_spomenika(object sender, RoutedEventArgs e)
        {
            PrikazEtiketa s = new PrikazEtiketa();
            s.Show();
            this.Close();
        }
    }
}
