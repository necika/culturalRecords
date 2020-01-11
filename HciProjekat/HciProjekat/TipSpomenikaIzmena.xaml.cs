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
    /// Interaction logic for TipSpomenikaIzmena.xaml
    /// </summary>
    public partial class TipSpomenikaIzmena : Window
    {
        int i = 0;
        int q = 0;
        String tipPre = "";
        public static MainWindow main;

        public TipSpomenikaIzmena()
        {
            InitializeComponent();

            textBoxOznaka.Text = MainWindow.selektovaniTipSpomenika.Oznaka;
            textBoxIme.Text = MainWindow.selektovaniTipSpomenika.Ime;
            textBoxOpis.Text = MainWindow.selektovaniTipSpomenika.Opis;
            myImage2.Source = MainWindow.selektovaniTipSpomenika.Ikonica;
            tipPre = textBoxOznaka.Text;

        }

        private void click_izmeni_tip_spomenika(object sender, RoutedEventArgs e)
        {
            int l = 0;
            int s1 = 0;
            int iteracijaZaStablo = 0;
            int brojacS = 0;


            if (textBoxOznaka.Text == "")
            {
                validacijaOznaka.Text = "Molimo unesite oznaku tipa.";
                validacijaOznaka.Foreground = Brushes.Red;
                statusTipIzmena.Text = "";

                if (textBoxIme.Text == "")
                {
                    validacijaIme.Text = "Molimo unesite ime tipa.";
                    validacijaIme.Foreground = Brushes.Red;
                    statusTipIzmena.Text = "";
                }
                else
                {
                    validacijaIme.Text = "";
                }
                if (textBoxOpis.Text == "")
                {
                    validacijaOpis.Text = "Molimo unesite opis tipa.";
                    validacijaOpis.Foreground = Brushes.Red;
                    statusTipIzmena.Text = "";
                }
                else
                {
                    validacijaOpis.Text = "";
                }
                if (myImage2.Source == null)
                {
                    validacijaSlika.Text = "Molimo unesite sliku tipa.";
                    validacijaSlika.Foreground = Brushes.Red;
                    statusTipIzmena.Text = "";
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
                statusTipIzmena.Text = "";
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
                statusTipIzmena.Text = "";
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
                statusTipIzmena.Text = "";
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
                
                if (PrikazTipaSpomenika.Tipovi != null)
                {
                    foreach (Model3 et in PrikazTipaSpomenika.Tipovi)
                    {
                        if (MainWindow.selektovaniIndex != brojacS) {
                            if (et.Oznaka == textBoxOznaka.Text)
                            {
                                vecPostojiOznaka = true;
                                validacijaOznaka.Text = "Molimo unesite neku drugu oznaku.";
                                validacijaOznaka.Foreground = Brushes.Red;
                                statusTipIzmena.Text = "";
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
                            brojacS++;
                        }
                    }
                }




                if (vecPostojiOznaka == false) {
                    String tipPosle = textBoxOznaka.Text;
                    //da se izmeni u comboboxu

                    for (int i = 0; i < Model3._sadrzaniSpomenici.Count; i++)
                    {
                        if (Model3._sadrzaniSpomenici[i] == tipPre)
                        {
                            Model3._sadrzaniSpomenici[i] = tipPosle;
                            break;
                        }
                    }

                    //da se izmene svi tipovi unutar spomenika

                    foreach (Model3 m3 in MainWindow.TipoviTree)
                    {
                        if (m3.Oznaka == tipPre)
                        {
                            foreach (Model1 m1 in m3.spomeniciUnutarTipova)
                            {
                                m1.Tip = tipPosle;
                            }
                        }
                    }

                    //izmena u stablu
                    foreach (Model3 m in MainWindow.TipoviTree)
                    {
                        if (iteracijaZaStablo == MainWindow.selektovaniIndex)
                        {
                            m.Opis = textBoxOpis.Text;
                            m.Oznaka = textBoxOznaka.Text;
                            m.Ime = textBoxIme.Text;
                            m.Ikonica = myImage2.Source;


                            break;
                        }
                        iteracijaZaStablo++;
                    }


                    foreach (Model3 m in PrikazTipaSpomenika.Tipovi)
                    {
                        if (q == MainWindow.selektovaniIndex)
                        {

                            m.Opis = textBoxOpis.Text;
                            m.Oznaka = textBoxOznaka.Text;
                            m.Ime = textBoxIme.Text;
                            m.Ikonica = myImage2.Source;


                            break;
                        }
                        q++;
                    }

                    MainWindow.readFromFileTipove();


                    if (PrikazTipaSpomenika.selektovaniIndex < MainWindow.brojacKolikoImaFajluTipova)
                    {
                        foreach (Model3 m in MainWindow.Tipovici)
                        {
                            if (MainWindow.selektovaniIndex == l)
                            {
                                m.Opis = textBoxOpis.Text;
                                m.Oznaka = textBoxOznaka.Text;
                                m.Ime = textBoxIme.Text;
                                m.Ikonica = myImage2.Source;

                                break;
                            }
                            l++;
                        }

                        MainWindow.SaveToTxtTipoveTemp();
                    }
                    else
                    {
                        foreach (Model3 m in MainWindow.Tipovi1)
                        {
                            if (MainWindow.selektovaniIndex == (s1 + MainWindow.brojacKolikoImaFajluTipova))
                            {
                                m.Opis = textBoxOpis.Text;
                                m.Oznaka = textBoxOznaka.Text;
                                m.Ime = textBoxIme.Text;
                                m.Ikonica = myImage2.Source;


                                break;
                            }
                            s1++;
                        }

                    }
                    main.statusBar.Text = "Izmenjen tip na poziciji " + PrikazTipaSpomenika.selektovaniIndex + " .";
                    main.statusBar.Foreground = Brushes.Green;
                    textBoxIme.Text = "";
                    textBoxOpis.Text = "";
                    textBoxOznaka.Text = "";
                    myImage2.Source = null;
                    this.Close();
                    PrikazTipaSpomenika s = new PrikazTipaSpomenika();
                    s.Show();
                }
            }
        }

        private void click_prikaz_tipa_spomenika(object sender, RoutedEventArgs e)
        {
            PrikazTipaSpomenika s = new PrikazTipaSpomenika();
            s.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();

            String selectedImage = open.FileName;

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
            else if (niz[1].Equals(""))
            {
                MessageBox.Show("Warning, niste uneli nijednu sliku, tako da ostaje vazeca.");
            }
            else
            {
                MessageBox.Show("Molimo Vas ubacite .jpg fajl.");
            }
        }

        private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MainWindow.resetujTree();
        }
    }
}
