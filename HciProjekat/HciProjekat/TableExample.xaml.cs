using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using HciProjekat;
using static System.Windows.Forms;
using Microsoft.Win32;
using System.ComponentModel;

namespace PrimerCas4.Table
{
    /// <summary>
    /// Interaction logic for TableExample.xaml
    /// </summary>
    public partial class TableExample : Window
    {

        public static int selektovaniIndex;
        public static MainWindow main;
        public static Model1 selektovaniSpomenik = new Model1();


        public static ObservableCollection<Model1> sakriveniSpomeniciTip
        {
            get;
            set;
        }
        public static ObservableCollection<Model1> sakriveniSpomeniciPretraga
        {
            get;
            set;
        }

        public static ObservableCollection<Model1> sakriveniSpomeniciIme
        {
            get;
            set;
        }

        public static ObservableCollection<Model1> sakriveniSpomeniciSearch
        {
            get;
            set;
        }

        public static ObservableCollection<Model1> Spomenici
        {
            get;
            set;
        }
        public static ObservableCollection<String> Pomocni2
        {
            get;
            set;
        }

        public TableExample()
        {
            InitializeComponent();
            this.DataContext = this;

            Spomenici = new ObservableCollection<Model1>();
            Pomocni2 = new ObservableCollection<String>();
            sakriveniSpomeniciTip = new ObservableCollection<Model1>();
            sakriveniSpomeniciIme = new ObservableCollection<Model1>();
            sakriveniSpomeniciSearch = new ObservableCollection<Model1>();
            sakriveniSpomeniciPretraga = new ObservableCollection<Model1>();

            Pomocni2 = DodavanjeSpomenika.Pomocni;


            if (MainWindow.Spomenicici.Count != 0)
            {
                Spomenici = MainWindow.Spomenicici;
            }


            if (MainWindow.Spomenici1 != null)
            {
                foreach (Model1 m1 in MainWindow.Spomenici1)
                {
                    Spomenici.Add(m1);
                    MainWindow.readFromFileSpomenike();
                }
            }






        }







        private void click_izmeni_spomenik(object sender, RoutedEventArgs e)
        {

            if (dgrMain.SelectedItem != null)
            {
                selektovaniSpomenik = (Model1)dgrMain.SelectedItem;
                selektovaniIndex = dgrMain.SelectedIndex;
                IzmenaSpomenika s = new IzmenaSpomenika();
                s.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Niste selektovali nijedan spomenik.");
            }

        }


        private void click_izbrisi_spomenik(object sender, RoutedEventArgs e)
        {
            int selektovaniZaBrisanje = dgrMain.SelectedIndex;
            int o = 0;
            int l = 0;
            int s = 0;
            Model1 selektovaniModel = (Model1)dgrMain.SelectedItem;
            int iteratorKrozListuStabla = 0;


            if (selektovaniModel != null)
            {
                foreach (Model3 m3 in MainWindow.TipoviTree)
                {
                    if (m3.Oznaka == selektovaniModel.Tip)
                    {
                        foreach (Model1 m in m3.spomeniciUnutarTipova)
                        {
                            if (selektovaniModel.Ime == m.Ime)
                            {
                                m3.spomeniciUnutarTipova.Remove(m);
                                break;
                            }
                        }

                    }
                    iteratorKrozListuStabla++;
                }

                //da se izbrise i na mapi ako je dodat
                if (MainWindow.naMapi != null)
                {
                    foreach (Model1 m1 in MainWindow.naMapi)
                    {
                        if (selektovaniModel.Oznaka == m1.Oznaka)
                        {
                            MainWindow.naMapi.Remove(m1);
                            break;
                        }
                    }
                }



                foreach (Model1 m1 in Spomenici)
                {
                    if (selektovaniZaBrisanje == o)
                    {
                        Spomenici.Remove(m1);

                        break;
                    }
                    o++;
                }

                MainWindow.readFromFileSpomenike();


                if (selektovaniZaBrisanje < MainWindow.brojacKolikoImaFajluSpomenik)
                {
                    foreach (Model1 m1 in MainWindow.Spomenicici)
                    {
                        if (selektovaniZaBrisanje == l)
                        {
                            MainWindow.Spomenicici.Remove(m1);

                            break;
                        }
                        l++;
                    }

                    MainWindow.SaveToTxtSpomenikeTemp();
                }
                else
                {
                    foreach (Model1 m1 in MainWindow.Spomenici1)
                    {
                        if (selektovaniZaBrisanje == (s + MainWindow.brojacKolikoImaFajluSpomenik))
                        {
                            MainWindow.Spomenici1.Remove(m1);

                            break;
                        }
                        s++;
                    }
                }
                main.statusBar.Text = "Izbrisan je spomenik sa oznakom " + selektovaniModel.Oznaka + " .";
                main.statusBar.Foreground = Brushes.Green;
            }
            else {
                main.statusBar.Text = "Niste selektovali cvor .";
                main.statusBar.Foreground = Brushes.Red;
            }
        }

        private void click_dodaj_spomenik(object sender, RoutedEventArgs e)
        {
            DodavanjeSpomenika s = new DodavanjeSpomenika();
            s.Show();
            this.Close();
        }

        /*private void TextBoxTip_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;



           combo.ItemsSource = Pomocni2;

        }

        private void TextBoxTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           var selectedComboItem = sender as ComboBox;
           string name = selectedComboItem.SelectedItem as string;

        }
        */
        private void TextBoxTip_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;



            combo.ItemsSource = Model3._sadrzaniSpomenici;

        }

        //FILTRIRANJE

        private void TextBoxTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            String tip = (String)tipSelect.SelectedItem;

            if (tip != null)
            {
                for (int i = 0; i < Spomenici.Count; i++)
                {
                    bool b = Spomenici[i].Tip.Equals(tip);
                    if (!b)
                    {
                        sakriveniSpomeniciTip.Add(Spomenici[i]);
                    }
                }
                foreach (Model1 eti in sakriveniSpomeniciTip)
                {
                    Spomenici.Remove(eti);
                }
                for (int i = 0; i < sakriveniSpomeniciTip.Count; i++)
                {
                    bool b = sakriveniSpomeniciTip[i].Tip.Equals(tip);
                    if (b)
                    {
                        Spomenici.Add(sakriveniSpomeniciTip[i]);
                    }
                }
                foreach (Model1 eti in Spomenici)
                {
                    sakriveniSpomeniciTip.Remove(eti);
                }
            }
            else
            {
                for (int i = 0; i < sakriveniSpomeniciTip.Count; i++)
                {
                    Spomenici.Add(sakriveniSpomeniciTip[i]);
                }
                foreach (Model1 sp in Spomenici)
                {
                    sakriveniSpomeniciTip.Remove(sp);
                }
            }

        }

        private void TxtIme_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            String ime = txtIme.Text;

            if (!ime.Equals(""))
            {
                for (int i = 0; i < Spomenici.Count; i++)
                {
                    bool b = Spomenici[i].Ime.Contains(ime) || Spomenici[i].Ime.ToLower().Contains(ime);
                    if (!b)
                    {
                        sakriveniSpomeniciIme.Add(Spomenici[i]);
                    }
                }
                foreach (Model1 eti in sakriveniSpomeniciIme)
                {
                    Spomenici.Remove(eti);
                }
                for (int i = 0; i < sakriveniSpomeniciIme.Count; i++)
                {
                    bool b = sakriveniSpomeniciIme[i].Ime.Contains(ime) || sakriveniSpomeniciIme[i].Ime.ToLower().Contains(ime);
                    if (b)
                    {
                        Spomenici.Add(sakriveniSpomeniciIme[i]);
                    }
                }
                foreach (Model1 eti in Spomenici)
                {
                    sakriveniSpomeniciIme.Remove(eti);
                }
                dgrMain.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < sakriveniSpomeniciIme.Count; i++)
                {
                    Spomenici.Add(sakriveniSpomeniciIme[i]);
                }
                foreach (Model1 sp in Spomenici)
                {
                    sakriveniSpomeniciIme.Remove(sp);
                }
                dgrMain.SelectedIndex = -1;
            }
        }

       
        public void pretraga() {
           
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtIme.Text = "";
           
            tipSelect.SelectedItem = null;

            if (sakriveniSpomeniciTip.Count != 0)
            {
                for (int i = 0; i < sakriveniSpomeniciTip.Count; i++)
                {
                    Spomenici.Add(sakriveniSpomeniciTip[i]);
                }

                foreach (Model1 s in Spomenici)
                {
                    sakriveniSpomeniciTip.Remove(s);
                }
            }
            if (sakriveniSpomeniciIme.Count != 0) {
                for (int i = 0; i < sakriveniSpomeniciIme.Count; i++)
                {
                    Spomenici.Add(sakriveniSpomeniciIme[i]);
                }
                foreach (Model1 s in Spomenici)
                {
                    sakriveniSpomeniciIme.Remove(s);
                }
            }
            if (sakriveniSpomeniciPretraga.Count != 0)
            {
                for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                }
                foreach (Model1 s in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(s);
                }
            }
            main.statusBar.Text = "Ponistena filtracija i pretraga.";
            main.statusBar.Foreground = Brushes.Green;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtIme.Text = "";
            
            PretragaSpomenik s = new PretragaSpomenik();
            s.Show();
            this.Close();
        }
        public static void pretraga1()
        {
           


            if (!PretragaSpomenik.spomenik.Oznaka.Equals(""))
            {
                for (int i = 0; i < Spomenici.Count; i++)
                {
                    bool b = Spomenici[i].Oznaka.Contains(PretragaSpomenik.spomenik.Oznaka) || Spomenici[i].Oznaka.ToLower().Contains(PretragaSpomenik.spomenik.Oznaka);
                    if (!b)
                    {
                        sakriveniSpomeniciPretraga.Add(Spomenici[i]);
                    }
                }
                foreach (Model1 eti in sakriveniSpomeniciPretraga)
                {
                    Spomenici.Remove(eti);
                }
                for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    /*bool b = sakriveniSpomeniciPretraga[i].Oznaka.Contains(PretragaSpomenik.spomenik.Oznaka) || sakriveniSpomeniciPretraga[i].Oznaka.ToLower().Contains(PretragaSpomenik.spomenik.Oznaka);
                    if (b)
                    {
                        Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                    }*/
                }
                foreach (Model1 eti in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                /*for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                }
                foreach (Model1 sp in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(sp);
                }
                //dgrMain.SelectedIndex = -1;
                */
            }

            if (!PretragaSpomenik.spomenik.Ime.Equals(""))
            {
                for (int i = 0; i < Spomenici.Count; i++)
                {
                    bool b = Spomenici[i].Ime.Contains(PretragaSpomenik.spomenik.Ime) || Spomenici[i].Ime.ToLower().Contains(PretragaSpomenik.spomenik.Ime);
                    if (!b)
                    {
                        sakriveniSpomeniciPretraga.Add(Spomenici[i]);
                    }
                }
                foreach (Model1 eti in sakriveniSpomeniciPretraga)
                {
                    Spomenici.Remove(eti);
                }
                for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    /*bool b = sakriveniSpomeniciPretraga[i].Ime.Contains(PretragaSpomenik.spomenik.Ime) || sakriveniSpomeniciPretraga[i].Ime.ToLower().Contains(PretragaSpomenik.spomenik.Ime);
                    if (b)
                    {
                        Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                    }*/
                }
                foreach (Model1 eti in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                /*for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
               {
                   Spomenici.Add(sakriveniSpomeniciPretraga[i]);
               }
               foreach (Model1 sp in Spomenici)
               {
                   sakriveniSpomeniciPretraga.Remove(sp);
               }
               //dgrMain.SelectedIndex = -1;
               */
            }
            if (!PretragaSpomenik.spomenik.Opis.Equals(""))
            {
                for (int i = 0; i < Spomenici.Count; i++)
                {
                    bool b = Spomenici[i].Opis.Contains(PretragaSpomenik.spomenik.Opis) || Spomenici[i].Opis.ToLower().Contains(PretragaSpomenik.spomenik.Opis);
                    if (!b)
                    {
                        sakriveniSpomeniciPretraga.Add(Spomenici[i]);
                    }
                }
                foreach (Model1 eti in sakriveniSpomeniciPretraga)
                {
                    Spomenici.Remove(eti);
                }
                for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                   /* bool b = sakriveniSpomeniciPretraga[i].Opis.Contains(PretragaSpomenik.spomenik.Opis) || sakriveniSpomeniciPretraga[i].Opis.ToLower().Contains(PretragaSpomenik.spomenik.Opis);
                    if (b)
                    {
                        Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                    }*/
                }
                foreach (Model1 eti in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                /*for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
               {
                   Spomenici.Add(sakriveniSpomeniciPretraga[i]);
               }
               foreach (Model1 sp in Spomenici)
               {
                   sakriveniSpomeniciPretraga.Remove(sp);
               }
               //dgrMain.SelectedIndex = -1;
               */
            }

            if (!PretragaSpomenik.spomenik.Tip.Equals(""))
            {
                for (int i = 0; i < Spomenici.Count; i++)
                {
                    bool b = Spomenici[i].Tip.Contains(PretragaSpomenik.spomenik.Tip) || Spomenici[i].Tip.ToLower().Contains(PretragaSpomenik.spomenik.Tip);
                    if (!b)
                    {
                        sakriveniSpomeniciPretraga.Add(Spomenici[i]);
                    }
                }
                foreach (Model1 eti in sakriveniSpomeniciPretraga)
                {
                    Spomenici.Remove(eti);
                }
                for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    /*bool b = sakriveniSpomeniciPretraga[i].Oznaka.Contains(PretragaSpomenik.spomenik.Oznaka) || sakriveniSpomeniciPretraga[i].Oznaka.ToLower().Contains(PretragaSpomenik.spomenik.Oznaka);
                    if (b)
                    {
                        Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                    }*/
                }
                foreach (Model1 eti in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                /*for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                }
                foreach (Model1 sp in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(sp);
                }
                //dgrMain.SelectedIndex = -1;
                */
            }

            if (PretragaSpomenik.spomenik.Prihod != 0)
            {
                for (int i = 0; i < Spomenici.Count; i++)
                {
                    bool b = Spomenici[i].Prihod == (PretragaSpomenik.spomenik.Prihod);
                    if (!b)
                    {
                        sakriveniSpomeniciPretraga.Add(Spomenici[i]);
                    }
                }
                foreach (Model1 eti in sakriveniSpomeniciPretraga)
                {
                    Spomenici.Remove(eti);
                }
                for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    /*bool b = sakriveniSpomeniciPretraga[i].Oznaka.Contains(PretragaSpomenik.spomenik.Oznaka) || sakriveniSpomeniciPretraga[i].Oznaka.ToLower().Contains(PretragaSpomenik.spomenik.Oznaka);
                    if (b)
                    {
                        Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                    }*/
                }
                foreach (Model1 eti in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                /*for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                }
                foreach (Model1 sp in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(sp);
                }
                //dgrMain.SelectedIndex = -1;
                */
            }

            
                for (int i = 0; i < Spomenici.Count; i++)
                {
                    bool b = Spomenici[i].ArhObradjen == (PretragaSpomenik.spomenik.ArhObradjen);
                    if (!b)
                    {
                        sakriveniSpomeniciPretraga.Add(Spomenici[i]);
                    }
                }
                foreach (Model1 eti in sakriveniSpomeniciPretraga)
                {
                    Spomenici.Remove(eti);
                }
                for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    /*bool b = sakriveniSpomeniciPretraga[i].Oznaka.Contains(PretragaSpomenik.spomenik.Oznaka) || sakriveniSpomeniciPretraga[i].Oznaka.ToLower().Contains(PretragaSpomenik.spomenik.Oznaka);
                    if (b)
                    {
                        Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                    }*/
                }
                foreach (Model1 eti in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(eti);
                }
            //dgrMain.SelectedIndex = 0;

            for (int i = 0; i < Spomenici.Count; i++)
            {
                bool b = Spomenici[i].PripadaNaseljenom == (PretragaSpomenik.spomenik.PripadaNaseljenom);
                if (!b)
                {
                    sakriveniSpomeniciPretraga.Add(Spomenici[i]);
                }
            }
            foreach (Model1 eti in sakriveniSpomeniciPretraga)
            {
                Spomenici.Remove(eti);
            }
            for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
            {
                /*bool b = sakriveniSpomeniciPretraga[i].Oznaka.Contains(PretragaSpomenik.spomenik.Oznaka) || sakriveniSpomeniciPretraga[i].Oznaka.ToLower().Contains(PretragaSpomenik.spomenik.Oznaka);
                if (b)
                {
                    Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                }*/
            }
            foreach (Model1 eti in Spomenici)
            {
                sakriveniSpomeniciPretraga.Remove(eti);
            }


            for (int i = 0; i < Spomenici.Count; i++)
            {
                bool b = Spomenici[i].PripadaUnesko == (PretragaSpomenik.spomenik.PripadaUnesko);
                if (!b)
                {
                    sakriveniSpomeniciPretraga.Add(Spomenici[i]);
                }
            }
            foreach (Model1 eti in sakriveniSpomeniciPretraga)
            {
                Spomenici.Remove(eti);
            }
            for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
            {
                /*bool b = sakriveniSpomeniciPretraga[i].Oznaka.Contains(PretragaSpomenik.spomenik.Oznaka) || sakriveniSpomeniciPretraga[i].Oznaka.ToLower().Contains(PretragaSpomenik.spomenik.Oznaka);
                if (b)
                {
                    Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                }*/
            }
            foreach (Model1 eti in Spomenici)
            {
                sakriveniSpomeniciPretraga.Remove(eti);
            }


            if (!PretragaSpomenik.spomenik.Era.Equals(""))
            {
                for (int i = 0; i < Spomenici.Count; i++)
                {
                    bool b = Spomenici[i].Era == PretragaSpomenik.spomenik.Era;
                    {
                        sakriveniSpomeniciPretraga.Add(Spomenici[i]);
                    }
                }
                foreach (Model1 eti in sakriveniSpomeniciPretraga)
                {
                    Spomenici.Remove(eti);
                }
                for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    /*bool b = sakriveniSpomeniciPretraga[i].Oznaka.Contains(PretragaSpomenik.spomenik.Oznaka) || sakriveniSpomeniciPretraga[i].Oznaka.ToLower().Contains(PretragaSpomenik.spomenik.Oznaka);
                    if (b)
                    {
                        Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                    }*/
                }
                foreach (Model1 eti in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                /*for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                }
                foreach (Model1 sp in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(sp);
                }
                //dgrMain.SelectedIndex = -1;
                */
            }

            if (!PretragaSpomenik.spomenik.TuristickiStatus.Equals(""))
            {
                for (int i = 0; i < Spomenici.Count; i++)
                {
                    bool b = Spomenici[i].TuristickiStatus == PretragaSpomenik.spomenik.TuristickiStatus;
                    {
                        sakriveniSpomeniciPretraga.Add(Spomenici[i]);
                    }
                }
                foreach (Model1 eti in sakriveniSpomeniciPretraga)
                {
                    Spomenici.Remove(eti);
                }
                for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    /*bool b = sakriveniSpomeniciPretraga[i].Oznaka.Contains(PretragaSpomenik.spomenik.Oznaka) || sakriveniSpomeniciPretraga[i].Oznaka.ToLower().Contains(PretragaSpomenik.spomenik.Oznaka);
                    if (b)
                    {
                        Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                    }*/
                }
                foreach (Model1 eti in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                /*for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                }
                foreach (Model1 sp in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(sp);
                }
                //dgrMain.SelectedIndex = -1;
                */
            }

            if (PretragaSpomenik.spomenik.Etikete != null)
            {
                for (int i = 0; i < Spomenici.Count; i++)
                {
                    Boolean b = false;
                    foreach (String m2 in PretragaSpomenik.spomenik.Etikete) {
                        foreach (String m22 in PretragaSpomenik.spomenik.Etikete)
                        {
                            if (m2.Equals(m22))
                            {
                                b = true;
                            }
                        }
                    }

                    
                    {
                        sakriveniSpomeniciPretraga.Add(Spomenici[i]);
                    }
                }
                foreach (Model1 eti in sakriveniSpomeniciPretraga)
                {
                    Spomenici.Remove(eti);
                }
                for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    /*bool b = sakriveniSpomeniciPretraga[i].Oznaka.Contains(PretragaSpomenik.spomenik.Oznaka) || sakriveniSpomeniciPretraga[i].Oznaka.ToLower().Contains(PretragaSpomenik.spomenik.Oznaka);
                    if (b)
                    {
                        Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                    }*/
                }
                foreach (Model1 eti in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                /*for (int i = 0; i < sakriveniSpomeniciPretraga.Count; i++)
                {
                    Spomenici.Add(sakriveniSpomeniciPretraga[i]);
                }
                foreach (Model1 sp in Spomenici)
                {
                    sakriveniSpomeniciPretraga.Remove(sp);
                }
                //dgrMain.SelectedIndex = -1;
                */
            }
        }
    }
}
