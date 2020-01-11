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
    /// Interaction logic for IzmenaEtikete.xaml
    /// </summary>
    public partial class IzmenaEtikete : Window
    {

        String s = "";
        int i = 0;
        int q = 0;
        public static MainWindow main;


        public IzmenaEtikete()
        {

            InitializeComponent();

            textBoxOznaka.Text = PrikazEtiketa.selektovanaEtiketa.Oznaka;
            textBoxOpis.Text = PrikazEtiketa.selektovanaEtiketa.Opis;



            //Ne prikazuje se boja, pitati
            foreach (Color c in DodavanjeEtiketa.sveBoje)
            {
                if (DodavanjeEtiketa.sveBoje.Count == i)
                {
                    textBoxBoja.SelectedColor = c;

                    break;
                }

                i++;
            }


        }

        private void cp_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (textBoxBoja.SelectedColor.HasValue)
            {
                Color C = textBoxBoja.SelectedColor.Value;

                long colorVal = Convert.ToInt64(C.R * (Math.Pow(256, 0)) + C.G * (Math.Pow(256, 1)) + C.B * (Math.Pow(256, 2)));
                s = "#" + C.R + C.G + C.B;

            }

        }

        private void click_izmeni_etiketu(object sender, RoutedEventArgs e)
        {

            int l = 0;
            int s1 = 0;
            int q = 0;
            int brojac1 = 0;
            int brojac2 = 0;

            if (textBoxOznaka.Text == "")
            {
                validacijaOznaka.Text = "Molimo unesite oznaku etikete.";
                validacijaOznaka.Foreground = Brushes.Red;
                statusEtiketaIzmena.Text = "";
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
            }
            else if (textBoxOpis.Text == "")
            {
                validacijaOpis.Text = "Molimo unesite opis etikete.";
                validacijaOpis.Foreground = Brushes.Red;
                statusEtiketaIzmena.Text = "";
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
                validacijaBoja.Text = "Molimo unesite boju etikete.";
                validacijaBoja.Foreground = Brushes.Red;
                statusEtiketaIzmena.Text = "";

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
                if (PrikazEtiketa.Etikete != null)
                {
                    foreach (Model2 et in PrikazEtiketa.Etikete)
                    {
                        if (PrikazEtiketa.selektovaniIndex != brojac1) {
                            if (et.Oznaka == textBoxOznaka.Text)
                            {
                                vecPostojiOznaka = true;
                                statusEtiketaIzmena.Text = "";
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
                        brojac1++;
                    }
                }
                







                if (vecPostojiOznaka == false) {
                    foreach (Model2 m in PrikazEtiketa.Etikete)
                    {
                        if (q == PrikazEtiketa.selektovaniIndex)
                        {

                            m.Opis = textBoxOpis.Text;
                            m.Oznaka = textBoxOznaka.Text;
                            m.Boja = s;
                            break;
                        }
                        q++;
                    }

                    MainWindow.readFromFileEtikete();


                    if (PrikazEtiketa.selektovaniIndex < MainWindow.brojacKolikoImaFajlu)
                    {
                        foreach (Model2 m2 in MainWindow.Etiketice)
                        {
                            if (PrikazEtiketa.selektovaniIndex == l)
                            {
                                m2.Opis = textBoxOpis.Text;
                                m2.Oznaka = textBoxOznaka.Text;
                                m2.Boja = s;

                                break;
                            }
                            l++;
                        }

                        MainWindow.SaveToTxtEtiketeTemp();
                    }
                    else
                    {
                        foreach (Model2 m2 in DodavanjeEtiketa.Etikete1)
                        {
                            if (PrikazEtiketa.selektovaniIndex == (s1 + MainWindow.brojacKolikoImaFajlu))
                            {
                                m2.Opis = textBoxOpis.Text;
                                m2.Oznaka = textBoxOznaka.Text;
                                m2.Boja = s;

                                break;
                            }
                            s1++;
                        }
                    }
                    main.statusBar.Text = "Izmenjena etiketa na poziciji " + PrikazEtiketa.selektovaniIndex + " .";
                    main.statusBar.Foreground = Brushes.Green;


                    textBoxBoja.SelectedColor = null;
                    textBoxOpis.Text = "";
                    textBoxOznaka.Text = "";
                    this.Close();
                    PrikazEtiketa o = new PrikazEtiketa();
                    o.Show();
                }
            }
        }

        private void click_prikaz_etiketa(object sender, RoutedEventArgs e)
        {
            PrikazEtiketa s = new PrikazEtiketa();
            s.Show();
            this.Close();
        }

        
    }
}
