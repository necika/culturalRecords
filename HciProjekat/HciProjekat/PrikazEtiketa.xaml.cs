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
    /// Interaction logic for PrikazEtiketa.xaml
    /// </summary>
    public partial class PrikazEtiketa : Window
    {
        public static Model2 selektovaniItem = new Model2();
        public static MainWindow main;

        public static ObservableCollection<Model2> Etikete
        {
            get;
            set;
        }

        public static ObservableCollection<Model2> sakriveneEtiketeOpis
        {
            get;
            set;
        }

        public static ObservableCollection<Model2> sakriveneEtiketeSearch
        {
            get;
            set;
        }
        public static ObservableCollection<Model2> sakriveneEtiketePretraga
        {
            get;
            set;
        }

        public String s;

        public static Model2 selektovanaEtiketa = new Model2();
        public static int selektovaniIndex;

        public PrikazEtiketa()
        {

            InitializeComponent();
            this.DataContext = this;
            Etikete = new ObservableCollection<Model2>();
            sakriveneEtiketeOpis = new ObservableCollection<Model2>();
            sakriveneEtiketeSearch = new ObservableCollection<Model2>();
            sakriveneEtiketePretraga = new ObservableCollection<Model2>();

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



        }



        /* private void cp_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
         {
             if (colorPicker.SelectedColor.HasValue)
             {
                 Color C = colorPicker.SelectedColor.Value;

                 long colorVal = Convert.ToInt64(C.R * (Math.Pow(256, 0)) + C.G * (Math.Pow(256, 1)) + C.B * (Math.Pow(256, 2)));
                 s = "#" + C.R + C.G + C.B;

             }

         }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dgrMain.SelectedItem != null)
            {
                selektovanaEtiketa = (Model2)dgrMain.SelectedItem;
                selektovaniIndex = dgrMain.SelectedIndex;
                IzmenaEtikete s = new IzmenaEtikete();
                s.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Niste selektovali nijednu etiketu.");
            }

        }

        private void click_ponisti(object sender, RoutedEventArgs e)
        {
            txtOpis.Text = "";
           


            if (sakriveneEtiketeOpis.Count != 0)
            {
                for (int i = 0; i < sakriveneEtiketeOpis.Count; i++)
                {
                    Etikete.Add(sakriveneEtiketeOpis[i]);
                }

                foreach (Model2 s in Etikete)
                {
                    sakriveneEtiketeOpis.Remove(s);
                }
            }
            if (sakriveneEtiketePretraga.Count != 0)
            {
                for (int i = 0; i < sakriveneEtiketePretraga.Count; i++)
                {
                    Etikete.Add(sakriveneEtiketePretraga[i]);
                }
                foreach (Model2 s in Etikete)
                {
                    sakriveneEtiketePretraga.Remove(s);
                }
            }
            main.statusBar.Text = "Ponistena filtracija i pretraga.";
            main.statusBar.Foreground = Brushes.Green;

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {

            int selektovaniZaBrisanje = dgrMain.SelectedIndex;
            Model2 selektovaniZaBrisanjeItem = (Model2)dgrMain.SelectedItem;
            int o = 0;
            int l = 0;
            int s = 0;

            if (selektovaniZaBrisanjeItem != null)
            {
                foreach (Model2 m2 in Etikete)
                {
                    if (selektovaniZaBrisanje == o)
                    {
                        Etikete.Remove(m2);

                        break;
                    }
                    o++;
                }

                MainWindow.readFromFileEtikete();


                if (selektovaniZaBrisanje < MainWindow.brojacKolikoImaFajlu)
                {
                    foreach (Model2 m2 in MainWindow.Etiketice)
                    {
                        if (selektovaniZaBrisanje == l)
                        {
                            MainWindow.Etiketice.Remove(m2);

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
                        if (selektovaniZaBrisanje == (s + MainWindow.brojacKolikoImaFajlu))
                        {
                            DodavanjeEtiketa.Etikete1.Remove(m2);

                            break;
                        }
                        s++;
                    }
                }
                main.statusBar.Text = "Izbrisana etiketa sa oznakom " + selektovaniZaBrisanjeItem.Oznaka + " .";
                main.statusBar.Foreground = Brushes.Green;
            }
            else
            {
                main.statusBar.Text = "Niste selektovali cvor .";
                main.statusBar.Foreground = Brushes.Red;
            }
        }

        private void TxtOpis_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            String ime = txtOpis.Text;

            if (!ime.Equals(""))
            {
                for (int i = 0; i < Etikete.Count; i++)
                {
                    bool b = Etikete[i].Opis.Contains(ime) || Etikete[i].Opis.ToLower().Contains(ime);
                    if (!b)
                    {
                        sakriveneEtiketeOpis.Add(Etikete[i]);
                    }
                }
                foreach (Model2 eti in sakriveneEtiketeOpis)
                {
                    Etikete.Remove(eti);
                }
                for (int i = 0; i < sakriveneEtiketeOpis.Count; i++)
                {
                    bool b = sakriveneEtiketeOpis[i].Opis.Contains(ime) || sakriveneEtiketeOpis[i].Opis.ToLower().Contains(ime);
                    if (b)
                    {
                        Etikete.Add(sakriveneEtiketeOpis[i]);
                    }
                }
                foreach (Model2 eti in Etikete)
                {
                    sakriveneEtiketeOpis.Remove(eti);
                }
                dgrMain.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < sakriveneEtiketeOpis.Count; i++)
                {
                    Etikete.Add(sakriveneEtiketeOpis[i]);
                }
                foreach (Model2 sp in Etikete)
                {
                    sakriveneEtiketeOpis.Remove(sp);
                }
                dgrMain.SelectedIndex = -1;
            }
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            txtOpis.Text = "";
            PretragaEtiketa s = new PretragaEtiketa();
            s.Show();
            this.Close();
        }

        public static void pretraga() {

            if (!PretragaEtiketa.etiketa.Opis.Equals(""))
            {
                for (int i = 0; i < Etikete.Count; i++)
                {
                    bool b = Etikete[i].Opis.Contains(PretragaEtiketa.etiketa.Opis) || Etikete[i].Opis.ToLower().Contains(PretragaEtiketa.etiketa.Opis);
                    if (!b)
                    {
                        sakriveneEtiketePretraga.Add(Etikete[i]);
                    }
                }
                foreach (Model2 eti in sakriveneEtiketePretraga)
                {
                    Etikete.Remove(eti);
                }
                for (int i = 0; i < sakriveneEtiketePretraga.Count; i++)
                {
                    
                }
                foreach (Model2 eti in Etikete)
                {
                    sakriveneEtiketePretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                
            }

            if (!PretragaEtiketa.etiketa.Oznaka.Equals(""))
            {
                for (int i = 0; i < Etikete.Count; i++)
                {
                    bool b = Etikete[i].Oznaka.Contains(PretragaEtiketa.etiketa.Oznaka) || Etikete[i].Oznaka.ToLower().Contains(PretragaEtiketa.etiketa.Oznaka);
                    if (!b)
                    {
                        sakriveneEtiketePretraga.Add(Etikete[i]);
                    }
                }
                foreach (Model2 eti in sakriveneEtiketePretraga)
                {
                    Etikete.Remove(eti);
                }
                for (int i = 0; i < sakriveneEtiketePretraga.Count; i++)
                {
                    
                }
                foreach (Model2 eti in Etikete)
                {
                    sakriveneEtiketePretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
                
            }

            if (!PretragaEtiketa.etiketa.Boja.Equals(""))
            {
                for (int i = 0; i < Etikete.Count; i++)
                {
                    bool b = Etikete[i].Boja.Contains(PretragaEtiketa.etiketa.Boja) || Etikete[i].Boja.ToLower().Contains(PretragaEtiketa.etiketa.Boja);
                    if (!b)
                    {
                        sakriveneEtiketePretraga.Add(Etikete[i]);
                    }
                }
                foreach (Model2 eti in sakriveneEtiketePretraga)
                {
                    Etikete.Remove(eti);
                }
                for (int i = 0; i < sakriveneEtiketePretraga.Count; i++)
                {
                   
                }
                foreach (Model2 eti in Etikete)
                {
                    sakriveneEtiketePretraga.Remove(eti);
                }
                //dgrMain.SelectedIndex = 0;
            }
            else
            {
               
            }
        }

    }
}
