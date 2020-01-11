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
    /// Interaction logic for PrikazTipaSpomenika.xaml
    /// </summary>
    public partial class PrikazTipaSpomenika : Window
    {
        public static MainWindow main;
        int listLenght1;
        String selektovaniTip = "";
        

        public static ObservableCollection<Model3> Tipovi
        {
            get;
            set;
        }

        public static ObservableCollection<Model3> sakriveniTipoviIme
        {
            get;
            set;
        }

        public static ObservableCollection<Model3> sakriveniTipoviOpis
        {
            get;
            set;
        }

        public static ObservableCollection<Model3> sakriveniTipoviSearch
        {
            get;
            set;
        }
        public static ObservableCollection<Model3> sakriveniTipoviPretraga
        {
            get;
            set;
        }

        public static int selektovaniIndex;

        public PrikazTipaSpomenika()
        {
            InitializeComponent();
            this.DataContext = this;
            Tipovi = new ObservableCollection<Model3>();
            sakriveniTipoviIme = new ObservableCollection<Model3>();
            sakriveniTipoviOpis = new ObservableCollection<Model3>();
            sakriveniTipoviSearch = new ObservableCollection<Model3>();
            sakriveniTipoviPretraga = new ObservableCollection<Model3>();


            if (MainWindow.Tipovici.Count != 0)
            {
                Tipovi = MainWindow.Tipovici;
            }

            if (MainWindow.Tipovi1 != null)
            {
                foreach (Model3 m3 in MainWindow.Tipovi1)
                {
                    Tipovi.Add(m3);
                    MainWindow.readFromFileTipove();
                }
            }





        }


        private void click_izmeni_tip(object sender, RoutedEventArgs e)
        {

            if (dgrMain.SelectedItem != null)
            {
                MainWindow.selektovaniTipSpomenika = (Model3)dgrMain.SelectedItem;

                MainWindow.selektovaniIndex = dgrMain.SelectedIndex;
                TipSpomenikaIzmena s = new TipSpomenikaIzmena();
                s.Show();
                this.Close();
            }
            else
            {
                main.statusBar.Text = "Niste selektovali nijedan cvor.";
                main.statusBar.Foreground = Brushes.Red;
            }
        }

        //brisanje tipa spomenika
        private void click_izbrisi_tip(object sender, RoutedEventArgs e)
        {
            int selektovaniZaBrisanje = dgrMain.SelectedIndex;
            Model3 selektovaniTipZaBrisanje = (Model3) dgrMain.SelectedItem;


            int o = 0;
            int l = 0;
            int s = 0;
            int iteratorKrozListuStabla = 0;
            int iteratorKrozOznakeUTipu = 0;

            int iteratorDaIzbriseSveSpomenikeTogTipa = 0;

            if (selektovaniTipZaBrisanje != null)
            {

                //da se izbrisu svi spomenici koji imaju taj tip UNUTAR TABELE
                if (selektovaniTipZaBrisanje != null)
                {
                    selektovaniTip = selektovaniTipZaBrisanje.Oznaka;
                }
                int listLenght = MainWindow.Spomenicici.Count;
                int brojac = 1;
                Boolean usao = false;

                if (MainWindow.Spomenicici != null)
                {
                    for (int i = 0; i < listLenght; ++i)
                    {

                        if (usao == true)
                        {
                            i = 0;
                        }

                        usao = false;

                        if (MainWindow.Spomenicici[i].Tip == selektovaniTip)
                        {
                            MainWindow.Spomenicici.Remove(MainWindow.Spomenicici[i]);
                            usao = true;
                        }
                        if (brojac == listLenght)
                        {
                            break;
                        }
                        brojac++;
                    }
                }

                if (MainWindow.Spomenici1 != null)
                {
                    listLenght1 = MainWindow.Spomenici1.Count;
                }
                int brojac1 = 1;
                Boolean usao1 = false;

                if (MainWindow.Spomenici1 != null)
                {
                    for (int i = 0; i < listLenght1; ++i)
                    {

                        if (usao1 == true)
                        {
                            i = 0;
                        }

                        usao1 = false;

                        if (MainWindow.Spomenici1[i].Tip == selektovaniTip)
                        {
                            MainWindow.Spomenici1.Remove(MainWindow.Spomenici1[i]);
                            usao1 = true;
                        }
                        if (brojac1 == listLenght1)
                        {
                            break;
                        }
                        brojac1++;
                    }
                }





                // da izbaci oznaku iz combobox u dodavanju spomenika
                foreach (String oznaka in Model3._sadrzaniSpomenici)
                {
                    if (iteratorKrozOznakeUTipu == selektovaniZaBrisanje)
                    {
                        Model3._sadrzaniSpomenici.Remove(oznaka);
                        break;
                    }
                    iteratorKrozOznakeUTipu++;
                }

                // da izbrise i iz drveta
                foreach (Model3 m3 in MainWindow.TipoviTree)
                {
                    if (selektovaniZaBrisanje == iteratorKrozListuStabla)
                    {
                        MainWindow.TipoviTree.Remove(m3);
                        break;
                    }
                    iteratorKrozListuStabla++;
                }

                // da izbrise iz tabele i da izbrise sve spomenike koji se nalazi pod tim tipom
                foreach (Model3 m3 in Tipovi)
                {
                    if (selektovaniZaBrisanje == o)
                    {
                        //samo da TableExample.Spomenici ne bi bio null
                        TableExample op = new TableExample();
                        if (m3.spomeniciUnutarTipova != null)
                        {
                            foreach (Model1 m1 in m3.spomeniciUnutarTipova)
                            {
                                TableExample.Spomenici.Remove(m1);
                                if (MainWindow.Spomenici1 != null)
                                {
                                    foreach (Model1 m11 in MainWindow.Spomenici1)
                                    {
                                        if (m1.Oznaka == m11.Oznaka)
                                        {
                                            MainWindow.Spomenici1.Remove(m11);
                                            break;
                                        }
                                    }
                                }
                                if (MainWindow.Spomenicici != null)
                                {
                                    foreach (Model1 m11 in MainWindow.Spomenicici)
                                    {
                                        if (m1.Oznaka == m11.Oznaka)
                                        {
                                            MainWindow.Spomenicici.Remove(m11);
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        Tipovi.Remove(m3);

                        break;
                    }
                    o++;
                }


                MainWindow.readFromFileTipove();



                if (selektovaniZaBrisanje < MainWindow.brojacKolikoImaFajluTipova)
                {
                    foreach (Model3 m3 in MainWindow.Tipovici)
                    {
                        if (selektovaniZaBrisanje == l)
                        {
                            MainWindow.Tipovici.Remove(m3);

                            break;
                        }
                        l++;
                    }

                    MainWindow.SaveToTxtTipoveTemp();
                }
                else
                {
                    foreach (Model3 m3 in MainWindow.Tipovi1)
                    {
                        if (selektovaniZaBrisanje == (s + MainWindow.brojacKolikoImaFajluTipova))
                        {
                            MainWindow.Tipovi1.Remove(m3);

                            break;
                        }
                        s++;
                    }
                }

                    main.statusBar.Text = "Izbrisan je tip sa oznakom " + selektovaniTipZaBrisanje.Oznaka + " .";
                    main.statusBar.Foreground = Brushes.Green;
                
            }
            else {
                main.statusBar.Text = "Niste selektovali nijedan cvor.";
                main.statusBar.Foreground = Brushes.Red;
            }
        }

        private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // MainWindow.resetujTree();
        }

        private void TxtOpis_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            String opis = txtOpis.Text;

            if (!opis.Equals(""))
            {
                for (int i = 0; i < Tipovi.Count; i++)
                {
                    bool b = Tipovi[i].Opis.Contains(opis) || Tipovi[i].Opis.ToLower().Contains(opis);
                    if (!b)
                    {
                        sakriveniTipoviOpis.Add(Tipovi[i]);
                    }
                }
                foreach (Model3 eti in sakriveniTipoviOpis)
                {
                    Tipovi.Remove(eti);
                }
                for (int i = 0; i < sakriveniTipoviOpis.Count; i++)
                {
                    bool b = sakriveniTipoviOpis[i].Opis.Contains(opis) || sakriveniTipoviOpis[i].Opis.ToLower().Contains(opis);
                    if (b)
                    {
                        Tipovi.Add(sakriveniTipoviOpis[i]);
                    }
                }
                foreach (Model3 eti in Tipovi)
                {
                    sakriveniTipoviOpis.Remove(eti);
                }
                dgrMain.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < sakriveniTipoviOpis.Count; i++)
                {
                    Tipovi.Add(sakriveniTipoviOpis[i]);
                }
                foreach (Model3 sp in Tipovi)
                {
                    sakriveniTipoviOpis.Remove(sp);
                }
                dgrMain.SelectedIndex = -1;
            }
        }

        private void TxtIme_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            String ime = txtIme.Text;

            if (!ime.Equals(""))
            {
                for (int i = 0; i < Tipovi.Count; i++)
                {
                    bool b = Tipovi[i].Ime.Contains(ime) || Tipovi[i].Ime.ToLower().Contains(ime);
                    if (!b)
                    {
                        sakriveniTipoviIme.Add(Tipovi[i]);
                    }
                }
                foreach (Model3 eti in sakriveniTipoviIme)
                {
                    Tipovi.Remove(eti);
                }
                for (int i = 0; i < sakriveniTipoviIme.Count; i++)
                {
                    bool b = sakriveniTipoviIme[i].Ime.Contains(ime) || sakriveniTipoviIme[i].Ime.ToLower().Contains(ime);
                    if (b)
                    {
                        Tipovi.Add(sakriveniTipoviIme[i]);
                    }
                }
                foreach (Model3 eti in Tipovi)
                {
                    sakriveniTipoviIme.Remove(eti);
                }
                dgrMain.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < sakriveniTipoviIme.Count; i++)
                {
                    Tipovi.Add(sakriveniTipoviIme[i]);
                }
                foreach (Model3 sp in Tipovi)
                {
                    sakriveniTipoviIme.Remove(sp);
                }
                dgrMain.SelectedIndex = -1;
            }
        }

        

        private void click_ponisti(object sender, RoutedEventArgs e)
        {
            txtIme.Text = "";
            txtOpis.Text = "";
           


            if (sakriveniTipoviIme.Count != 0)
            {
                for (int i = 0; i < sakriveniTipoviIme.Count; i++)
                {
                    Tipovi.Add(sakriveniTipoviIme[i]);
                }

                foreach (Model3 s in Tipovi)
                {
                    sakriveniTipoviIme.Remove(s);
                }
            }
            if (sakriveniTipoviOpis.Count != 0)
            {
                for (int i = 0; i < sakriveniTipoviOpis.Count; i++)
                {
                    Tipovi.Add(sakriveniTipoviOpis[i]);
                }

                foreach (Model3 s in Tipovi)
                {
                    sakriveniTipoviOpis.Remove(s);
                }
            }

            if (sakriveniTipoviPretraga.Count != 0)
            {
                for (int i = 0; i < sakriveniTipoviPretraga.Count; i++)
                {
                    Tipovi.Add(sakriveniTipoviPretraga[i]);
                }
                foreach (Model3 s in Tipovi)
                {
                    sakriveniTipoviPretraga.Remove(s);
                }
            }
            main.statusBar.Text = "Ponistena filtracija i pretraga .";
            main.statusBar.Foreground = Brushes.Green;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtIme.Text = "";
            txtOpis.Text = "";
            PretragaTip s = new PretragaTip();
            s.Show();
            this.Close();
        }
        public static void pretraga() {
            
            /*
             
             */

            if (!PretragaTip.tip.Opis.Equals(""))
            {
                for (int i = 0; i < Tipovi.Count; i++)
                {
                    bool b = Tipovi[i].Opis.Contains(PretragaTip.tip.Opis) || Tipovi[i].Opis.ToLower().Contains(PretragaTip.tip.Opis);
                    if (!b)
                    {
                        sakriveniTipoviPretraga.Add(Tipovi[i]);
                    }
                }
                foreach (Model3 eti in sakriveniTipoviPretraga)
                {
                    Tipovi.Remove(eti);
                }
                for (int i = 0; i < sakriveniTipoviPretraga.Count; i++)
                {
                   /* bool b = sakriveniTipoviPretraga[i].Opis.Contains(PretragaTip.tip.Opis) || sakriveniTipoviPretraga[i].Opis.ToLower().Contains(PretragaTip.tip.Opis);
                    if (b)
                    {
                        Tipovi.Add(sakriveniTipoviPretraga[i]);
                    }*/
                }
                foreach (Model3 eti in Tipovi)
                {
                    sakriveniTipoviPretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                /*for (int i = 0; i < sakriveniTipoviPretraga.Count; i++)
                {
                    Tipovi.Add(sakriveniTipoviPretraga[i]);
                }
                foreach (Model3 sp in Tipovi)
                {
                    sakriveniTipoviPretraga.Remove(sp);
                }
                //dgrMain.SelectedIndex = -1;*/
            }

            if (!PretragaTip.tip.Oznaka.Equals("") )
            {
                for (int i = 0; i < Tipovi.Count; i++)
                {
                    bool b = Tipovi[i].Oznaka.Contains(PretragaTip.tip.Oznaka) || Tipovi[i].Oznaka.ToLower().Contains(PretragaTip.tip.Oznaka);
                    if (!b)
                    {
                        sakriveniTipoviPretraga.Add(Tipovi[i]);
                    }
                }
                foreach (Model3 eti in sakriveniTipoviPretraga)
                {
                    Tipovi.Remove(eti);
                }
                for (int i = 0; i < sakriveniTipoviPretraga.Count; i++)
                {
                   
                }
                foreach (Model3 eti in Tipovi)
                {
                    sakriveniTipoviPretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
               
            }

            if (!PretragaTip.tip.Ime.Equals(""))
            {
                for (int i = 0; i < Tipovi.Count; i++)
                {
                    bool b = Tipovi[i].Ime.Contains(PretragaTip.tip.Ime) || Tipovi[i].Ime.ToLower().Contains(PretragaTip.tip.Ime);
                    if (!b)
                    {
                        sakriveniTipoviPretraga.Add(Tipovi[i]);
                    }
                }
                foreach (Model3 eti in sakriveniTipoviPretraga)
                {
                    Tipovi.Remove(eti);
                }
                for (int i = 0; i < sakriveniTipoviPretraga.Count; i++)
                {
                    
                }
                foreach (Model3 eti in Tipovi)
                {
                    sakriveniTipoviPretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                
            }

            

          /*  if (PretragaTip.tip.Ikonica != null)
            {
                for (int i = 0; i < Tipovi.Count; i++)
                {
                    bool b = Tipovi[i].Ikonica.Equals(PretragaTip.tip.Ikonica) ;
                    if (!b)
                    {
                        sakriveniTipoviPretraga.Add(Tipovi[i]);
                    }
                }
                foreach (Model3 eti in sakriveniTipoviPretraga)
                {
                    Tipovi.Remove(eti);
                }
                for (int i = 0; i < sakriveniTipoviPretraga.Count; i++)
                {
                    bool b = sakriveniTipoviPretraga[i].Ikonica.Equals(PretragaTip.tip.Ikonica);
                    if (b)
                    {
                        Tipovi.Add(sakriveniTipoviPretraga[i]);
                    }
                }
                foreach (Model3 eti in Tipovi)
                {
                    sakriveniTipoviPretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < sakriveniTipoviPretraga.Count; i++)
                {
                    Tipovi.Add(sakriveniTipoviPretraga[i]);
                }
                foreach (Model3 sp in Tipovi)
                {
                    sakriveniTipoviPretraga.Remove(sp);
                }
                //dgrMain.SelectedIndex = -1;
            }*/
        }
    }
}
