using PrimerCas4.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

//-----------URADITI 26.5.2019------------------------------------------------
// TODO 1: DONE!!! VIDJETI FALI LI JOS NESTO OKO STABLA, TIPA KAD SE PROMJENI SPOMENIK DA SE PROMJENI I U STABLU
// TODO 2: DONE!!! IZMJENITI U TABELAMA GDJE IMA SLIKA DA BUDE SLIKA A NE PUTANJA DO SLIKE
// TODO 3: DONE!!! UCITAVANJE SPOMENIKA U STABLO IZ DATOTEKE
// TODO 4: DONE!!!DRAG AND DROP

//-----------URADITI ZA ODBRANU PROJEKTA------------------------------------------------
// TODO 1: DONE!!! : PROMJENITI DA AKO SE NE OTVORI TABLEEXAMPLE DA SACUVA NOVU NEKU LISTU IZ MAINWINDOW KLASE KOJA CE DA BUDE ISTA KAO SPOMENICI IZ TABLEEXAMPLE
// TODO 2: DONE!!! : DA KAD SE MJENJA TIP DA SE MJENJA I U SPOMENIKU I U COMBOBOXU
// TODO 3: DONE!!! : DA KAD SE IZBRISE TIP DA SE IZBRISE I SVI SPOMENICI KOJI SU U TOM TIPU
// TODO 4: DONE!!! : SVE OVO POD 1 i 2 DA BUDE MJENJANO I NA MAPI I STABLU
// TODO 5: DONE!!! : PRIKAZATI BOJU U TABELI A NE SLOVA
// TODO 6: DONE!!! : VALIDACIJU ZA IZMENU SVEGA URADITI
// TODO 7: DONE!!! : FILTRIRANJE
// TODO 8: DONE!!! : UCITAVANJE BOJE NEKAKO URADITI
// TODO 9: DONE!!! : PRECICE
// TODO 10: DONE!!! : HELP
// TODO 11: DONE!!! : STATUS BAR
// TODO 12: DONE!!! : ZABRANITI UNOS SA TASTATURE DATUMA
// TODO 13: DONE!!! : LOGOVANJE
// TODO 14:  POGLEDATI JOS NESTO IMA 100%
// TODO 15: DONE!!! : DA BUDU ETIKETE U SPOMENIKU
// TODO 16: DONE!!! : PRETRAGA SPOMENIKA


namespace HciProjekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        
        public static int p = 0;
        public static Boolean prijavljen = false;
        public static int spomenik1 = 0;
        public static int tipSpomenika1 = 0;
        public static int etiketa1 = 0;
        public static Model3 selektovaniTipSpomenika = new Model3();
        public static int brojacZaCitanjeSpomenika = 0;
        static string[] temp1;
        static string[] temp2;
        static string[] temp3;
        public static int brojacKolikoImaFajlu = 0;
        public static int brojacKolikoImaFajluTipova = 0;
        public static int brojacKolikoImaFajluSpomenik = 0;
        public static int selektovaniIndex;


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }



        


        public static ObservableCollection<String> registracija
        {
            get;
            set;
        }


        public static ObservableCollection<Model1> naMapi
        {
            get;
            set;
        }

        public static ObservableCollection<Model3> TipoviTree
        {
            get;
            set;
        }
        public static ObservableCollection<Model1> SpomeniciTree
        {
            get;
            set;
        }

        public static ObservableCollection<Model3> Tipovi1
        {
            get;
            set;
        }

        public static ObservableCollection<Model1> Spomenici1
        {
            get;
            set;
        }

        public static ObservableCollection<Model2> Etiketice
        {
            get;
            set;
        }

        public static ObservableCollection<Model1> Spomenicici
        {
            get;
            set;
        }



        public static ObservableCollection<Model3> Tipovici
        {
            get;
            set;
        }
        public int brojPozivaKonstruktora = 0;


        public MainWindow()
        {

            
            InitializeComponent();


                p++;
                Console.WriteLine(p);


            
                TipoviTree = new ObservableCollection<Model3>();
                SpomeniciTree = new ObservableCollection<Model1>();
                naMapi = new ObservableCollection<Model1>();
                registracija = new ObservableCollection<string>();
                DodavanjeEtiketa.sveBoje = new ObservableCollection<Color>();


                readFromFileEtikete();
                readFromFileTipove();
                resetujTree();
                readFromFileSpomenike();
                readFromFileTipoveZaSpomenike();
                readFromFileSpomenikeNaMapi();
                readFromFileRegistracija();


                Model3 m = new Model3();
                m.Ime = "Ime1";
                
                
                DodavanjeTipaSpomenika.main = this;
                DodavanjeEtiketa.main = this;
                DodavanjeSpomenika.main = this;
                IzmenaEtikete.main = this;
                IzmenaSpomenika.main = this;
                TipSpomenikaIzmena.main = this;
                TableExample.main = this;
                PrikazEtiketa.main = this;
                PrikazTipaSpomenika.main = this;
                Login.main = this;

            this.DataContext = this;
            


            //brojPozivaKonstruktora++;

        }

        public MainWindow(String s) {
            InitializeComponent();

            this.statusBar.Text = s;

        }



        public static void readFromFileSpomenike()
        {


            Spomenicici = new ObservableCollection<Model1>();

            string[] lines = System.IO.File.ReadAllLines("Spomenici.txt");
            brojacKolikoImaFajluSpomenik = 0;

            foreach (string line in lines)
            {
                if (!lines[0].Equals(""))
                {
                    temp3 = line.Split(' ');

                    int i = 14;


                    Model1 m1 = new Model1();

                    m1.Oznaka = temp3[0];
                    m1.Ime = temp3[1];
                    m1.Tip = temp3[2];
                    m1.DatumOtkrivanja = Convert.ToDateTime(temp3[3] + " " + temp3[4] + " " + temp3[5]);
                    m1.Opis = temp3[6];
                    m1.Prihod = Convert.ToSingle(temp3[7]);

                    if (temp3[8].Equals("True"))
                    {
                        m1.ArhObradjen = true;
                    }
                    else
                    {
                        m1.ArhObradjen = false;
                    }

                    if (temp3[9].Equals("True"))
                    {
                        m1.PripadaUnesko = true;
                    }
                    else
                    {
                        m1.PripadaUnesko = false;
                    }

                    if (temp3[10].Equals("True"))
                    {
                        m1.PripadaNaseljenom = true;
                    }
                    else
                    {
                        m1.PripadaNaseljenom = false;
                    }

                    m1.Era = temp3[11];
                    m1.TuristickiStatus = temp3[12];
                    m1.Tagovani = null;



                    Uri myUri = new Uri(temp3[13], UriKind.RelativeOrAbsolute);
                    JpegBitmapDecoder decoder2 = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    BitmapSource bitmapSource2 = decoder2.Frames[0];

                    m1.Ikonica = bitmapSource2;
                    Spomenicici.Add(m1);
                    brojacKolikoImaFajluSpomenik++;

                    if (brojacZaCitanjeSpomenika == 0) {
                        foreach (Model3 m in MainWindow.TipoviTree)
                        {
                            if (m.Oznaka == m1.Tip)
                            {
                                m.spomeniciUnutarTipova.Add(m1);
                                break;
                            }
                        }
                     }
                    
                    while (temp3[i] != "") {
                        m1.Etikete.Add(temp3[i]);
                        i++;
                    }

                }
            }
            brojacZaCitanjeSpomenika++;
        }
       


        public static void readFromFileTipove()
        {
            //DodavanjeTipaSpomenika.pomocni1 = new ObservableCollection<string>();

            Tipovici = new ObservableCollection<Model3>();

            string[] lines = System.IO.File.ReadAllLines("Tipovi.txt");
            brojacKolikoImaFajluTipova = 0;

            foreach (string line in lines)
            {
                if (!lines[0].Equals(""))
                {
                    temp2 = line.Split(' ');




                    Model3 m3 = new Model3();
                    m3.Ime = temp2[0];
                    m3.Oznaka = temp2[1];
                    m3.Opis = temp2[2];

                    Uri myUri = new Uri(temp2[3], UriKind.RelativeOrAbsolute);
                    JpegBitmapDecoder decoder2 = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    BitmapSource bitmapSource2 = decoder2.Frames[0];

                    m3.Ikonica = bitmapSource2;
                    Tipovici.Add(m3);
                    brojacKolikoImaFajluTipova++;


                }
            }


        }

        public static void readFromFileRegistracija()
        {
            //DodavanjeTipaSpomenika.pomocni1 = new ObservableCollection<string>();

            registracija = new ObservableCollection<String>();
            String[] temp10 = null;
            string[] lines = System.IO.File.ReadAllLines("Registracija.txt");
            brojacKolikoImaFajluTipova = 0;

            foreach (string line in lines)
            {
                if (!lines[0].Equals(""))
                {
                    temp10 = line.Split(' ');


                    String ime = temp10[0];
                    String sifra = temp10[1];


                    registracija.Add(ime + " " + sifra);
                    brojacKolikoImaFajluTipova++;


                }
            }


        }

        public static void readFromFileSpomenikeNaMapi()
        {
            MainWindow.naMapi = new ObservableCollection<Model1>();

            //Tipovici = new ObservableCollection<Model3>();

            string[] lines = System.IO.File.ReadAllLines("SpomeniciNaMapi.txt");


            foreach (string line in lines)
            {
                if (!lines[0].Equals(""))
                {
                    temp2 = line.Split(' ');


                    Model1 m1 = new Model1();

                    m1.Oznaka = temp2[0];

                    Uri myUri = new Uri(temp2[1], UriKind.RelativeOrAbsolute);
                    JpegBitmapDecoder decoder2 = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    BitmapSource bitmapSource2 = decoder2.Frames[0];

                    m1.Ikonica = bitmapSource2;


                    String[] temp3 = temp2[2].Split(',');
                    double prviPoint = Convert.ToDouble(temp3[0]);
                    double drugiPoint = Convert.ToDouble(temp3[1]);

                    Point p = new Point(prviPoint, drugiPoint);
                    m1.Point = p;

                    MainWindow.naMapi.Add(m1);
                }
            }

        }



        public static void readFromFileTipoveZaSpomenike()
        {
            Model3._sadrzaniSpomenici = new ObservableCollection<string>();

            //Tipovici = new ObservableCollection<Model3>();

            string[] lines = System.IO.File.ReadAllLines("Tipovi.txt");


            foreach (string line in lines)
            {
                if (!lines[0].Equals(""))
                {
                    temp2 = line.Split(' ');


                    Model3._sadrzaniSpomenici.Add(temp2[1]);
                }
            }

        }



        public static void readFromFileEtikete()
        {

            Etiketice = new ObservableCollection<Model2>();

            brojacKolikoImaFajlu = 0;
            string[] lines = System.IO.File.ReadAllLines("Etikete.txt");

            foreach (string line in lines)
            {
                if (!lines[0].Equals(""))
                {
                    temp1 = line.Split(' ');




                    Model2 m2 = new Model2();
                    m2.Oznaka = temp1[0];
                    m2.Opis = temp1[1];

                    Color C = (Color)ColorConverter.ConvertFromString(temp1[2]);

                    String s = Convert.ToString(C);
                    m2.Boja = s;

                    

                   
                    


                    Etiketice.Add(m2);
                    brojacKolikoImaFajlu++;

                }

            }


        }




        private void click_prikaz_spomenika(object sender, RoutedEventArgs e)
        {
            if (prijavljen == true)
            {
                TableExample s = new TableExample();
                s.Show();
                statusBar.Text = "";
            }
            else {
                statusBar.Text = "STATUS: Niste se prijavili,onemogucena opcija.";
                statusBar.Foreground = Brushes.Red;
            }
        }

        




        public static void SaveToTxtEtiketeTemp()
        {

            StreamWriter fileEtikete = new StreamWriter("Etikete.txt");


            if (PrikazEtiketa.Etikete != null)
            {
                foreach (Model2 m2 in Etiketice)
                {
                    fileEtikete.WriteLine(m2.Oznaka + " " + m2.Opis + " " + m2.Boja);
                }
            }
            fileEtikete.Close();

        }




        public static void SaveToTxtEtikete()
        {

            StreamWriter fileEtikete = new StreamWriter("Etikete.txt");


            if (PrikazEtiketa.Etikete != null)
            {
                foreach (Model2 m2 in PrikazEtiketa.Etikete)
                {
                    fileEtikete.WriteLine(m2.Oznaka + " " + m2.Opis + " " + m2.Boja);
                }
            }
            fileEtikete.Close();


        }

        public static void SaveToTxtTipove()
        {

            StreamWriter fileTipovi = new StreamWriter("Tipovi.txt");


            if (MainWindow.TipoviTree != null)
            {
                foreach (Model3 m3 in MainWindow.TipoviTree)
                {
                    fileTipovi.WriteLine(m3.Ime + " " + m3.Oznaka + " " + m3.Opis + " " + m3.Ikonica);
                }
            }
            fileTipovi.Close();


        }

        public static void SaveToTxtTipoveTemp()
        {

            StreamWriter fileTipovi = new StreamWriter("Tipovi.txt");


            if (MainWindow.TipoviTree != null)
            {
                foreach (Model3 m3 in Tipovici)
                {
                    fileTipovi.WriteLine(m3.Ime + " " + m3.Oznaka + " " + m3.Opis + " " + m3.Ikonica);
                }
            }
            fileTipovi.Close();


        }

        public static void SaveToTxtSpomenike()
        {

            StreamWriter fileSpomenici = new StreamWriter("Spomenici.txt");
            

            

            if (TableExample.Spomenici != null)
            {
                foreach (Model1 m1 in TableExample.Spomenici)
                {
                    fileSpomenici.Write(m1.Oznaka + " " + m1.Ime + " " + m1.Tip + " " + m1.DatumOtkrivanja + " " + m1.Opis + " " + m1.Prihod + " " + m1.ArhObradjen + " " + m1.PripadaUnesko + " " + m1.PripadaNaseljenom + " " + m1.Era + " " + m1.TuristickiStatus + " " + m1.Ikonica + " ");
                    foreach (String m2 in m1.Etikete) {
                        fileSpomenici.Write(m2 + " ");
                    }
                    fileSpomenici.WriteLine("");
                }
            }
            
            fileSpomenici.Close();


        }
        public static void SaveToTxtSpomenikeNaMapi()
        {

            StreamWriter fileSpomenici = new StreamWriter("SpomeniciNaMapi.txt");


            if (MainWindow.naMapi != null)
            {
                foreach (Model1 m1 in MainWindow.naMapi)
                {
                    fileSpomenici.WriteLine(m1.Oznaka + " " + m1.Ikonica + " " + m1.Point);
                }
            }
            fileSpomenici.Close();


        }


        public static void SaveToTxtSpomenikeTemp()
        {

            StreamWriter fileSpomenici = new StreamWriter("Spomenici.txt");

            if (TableExample.Spomenici != null)
            {
                foreach (Model1 m1 in TableExample.Spomenici)
                {
                    fileSpomenici.Write(m1.Oznaka + " " + m1.Ime + " " + m1.Tip + " " + m1.DatumOtkrivanja + " " + m1.Opis + " " + m1.Prihod + " " + m1.ArhObradjen + " " + m1.PripadaUnesko + " " + m1.PripadaNaseljenom + " " + m1.Era + " " + m1.TuristickiStatus +" " + m1.Ikonica + " ");
                    foreach (String m2 in m1.Etikete)
                    {
                        fileSpomenici.Write(m2 + " ");
                    }
                    fileSpomenici.WriteLine("");
                }
            }

            fileSpomenici.Close();

        }
        
        



        public static void resetujTree()
        {



            TipoviTree = new ObservableCollection<Model3>();

            if (Tipovici != null) {
                foreach (Model3 m in Tipovici) {
                    TipoviTree.Add(m);
                }
            }
            if (MainWindow.Tipovi1 != null) {
                foreach (Model3 m in MainWindow.Tipovi1)
                {
                    TipoviTree.Add(m);
                }
            }




            MainWindow samoDaPozoveKonstruktorRadiInicijalizacije = new MainWindow("s");

        }

        //Drag and drop

        private Point startPoint = new Point();
        private Boolean isDragging = false;

        // Pocetak drag and dropa, da znam odakle krecem logicno
        private void Tree_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }
        private void TreeViewItem_OnItemSelected(object sender, RoutedEventArgs e)
        {
            xTree.Tag = e.OriginalSource;
        }
        private void Tree_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && !isDragging)
            {
                Point position = e.GetPosition(null);
                if (Math.Abs(position.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(position.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    StartDrag(e);
                }
            }
        }

        //Glavni deo drag and dropa
        private void StartDrag(MouseEventArgs e)
        {
            //obavezno if! tipovi se ne mogu dragovati, a ovako ako je neko slucajno kliknuo negde na drvo ne moze ni to
            if (xTree.SelectedItem is Model1)
            {
                isDragging = true;

                Model1 selectedItem = (Model1)xTree.SelectedItem;
                TreeViewItem tvi = xTree.Tag as TreeViewItem;
                // Initialize the drag & drop operation                
                DataObject dragData = new DataObject("ugrozeniDrag", selectedItem);
                if (isDragging == true)
                    DragDrop.DoDragDrop(tvi, dragData, DragDropEffects.Move);
                //ovde se dodje tek kada se spusti objekat
                isDragging = false;
            }
        }
        // Iniciranje drag and dropa
        private void NaMapi_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && !isDragging)
            {
                Point position = e.GetPosition(null);
                if (Math.Abs(position.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(position.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    StartDragMap(e);
                }
            }
        }
        private void StartDragMap(MouseEventArgs e)
        {
            if (NaMapi.SelectedItem is Model1) //zbog null, ako je neko krenuo da vuce po mapi bezveze
            {
                isDragging = true;
                Model1 selectedItem = (Model1)NaMapi.SelectedItem;
                ListBoxItem lwi = (ListBoxItem)NaMapi.ItemContainerGenerator.ContainerFromItem(selectedItem);
                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("ugrozeniDrag", selectedItem);
                if (isDragging == true)
                    DragDrop.DoDragDrop(lwi, dragData, DragDropEffects.Move);
                isDragging = false;
            }
        }
        // Nisam siguran, nasao na internetu
        private void NaMapi_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("ugrozeniDrag")) //ni slucajno od njih e.source == sender dodati. Onda ne moze po mapi da se pomera
            {
                e.Effects = DragDropEffects.None;
            }

        }

        private void Tree_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("ugrozeniDrag"))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Tree_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("ugrozeniDrag"))
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
            else
            {
                Model1 uv = e.Data.GetData("ugrozeniDrag") as Model1;
                if (uv.Point.X == -1)
                {
                    e.Effects = DragDropEffects.None;
                    e.Handled = true;
                }
            }
        }


        private void NaMapi_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("ugrozeniDrag"))
            {

                Model1 uv = e.Data.GetData("ugrozeniDrag") as Model1;
                Console.WriteLine("Dropovan " + uv.Ime);
                uv.Point = e.GetPosition(NaMapi);
                if (!naMapi.Contains(uv))
                {
                    naMapi.Add(uv);
                }



                isDragging = false;
            }
        }

        private void Tree_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("ugrozeniDrag"))
            {
                Model1 uv = e.Data.GetData("ugrozeniDrag") as Model1;

                Console.WriteLine("Tree Drop");
                naMapi.Remove(uv);
                Console.WriteLine("Obrisan: " + naMapi.Count);
                uv.Point = new Point(-1, -1);

                isDragging = false;
            }
        }

        private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveToTxtEtikete();
            SaveToTxtTipove();
            SaveToTxtSpomenike();
            SaveToTxtSpomenikeNaMapi();
            



        }

        

        private void form1_load(object sender, RoutedEventArgs e)
        {

        }

        private void form_kd(object sender, KeyEventArgs e)
        {

        }

        

        private void NaMapi_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void NaMapi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NaMapi_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (NaMapi.SelectedItem is Model1)
            {
                Model1 m = (Model1)NaMapi.SelectedItem;
                naMapi.Remove(m);
                statusBar.Text = "Uklonjen spomenik sa mape.";
                statusBar.Foreground = Brushes.Green;
            }

        }

        

       
        public void Ispisi(String l) {
            statusBar.Text = l;
        }

        //PRECICE

        private void DodajSpomenik_Can_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void DodajSpomenik_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (prijavljen == true)
            {
                DodavanjeSpomenika s = new DodavanjeSpomenika();
                s.Show();
                statusBar.Text = "";
            }
            else
            {
                statusBar.Text = "STATUS: Niste se prijavili,onemogucena opcija.";
                statusBar.Foreground = Brushes.Red;
            }
        }

        private void DodajTip_Can_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void DodajTip_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (prijavljen == true)
            {
                DodavanjeTipaSpomenika s = new DodavanjeTipaSpomenika();
                s.Show();
                statusBar.Text = "";
            }
            else
            {
                statusBar.Text = "STATUS: Niste se prijavili,onemogucena opcija.";
                statusBar.Foreground = Brushes.Red;
            }
        }

        private void PrikazTip_Can_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void PrikazTip_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (prijavljen == true)
            {
                PrikazTipaSpomenika s = new PrikazTipaSpomenika();
                s.Show();
                statusBar.Text = "";
            }
            else
            {
                statusBar.Text = "STATUS: Niste se prijavili,onemogucena opcija.";
                statusBar.Foreground = Brushes.Red;
            }
        }

        private void DodajEtiketu_Can_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void DodajEtiketu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (prijavljen == true)
            {
                DodavanjeEtiketa s = new DodavanjeEtiketa();
                s.Show();
                statusBar.Text = "";
            }
            else
            {
                statusBar.Text = "STATUS: Niste se prijavili,onemogucena opcija.";
                statusBar.Foreground = Brushes.Red;
            }
        }

        private void PrikazEtiketu_Can_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void PrikazEtiketu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (prijavljen == true)
            {
                PrikazEtiketa s = new PrikazEtiketa();
                s.Show();
                statusBar.Text = "";
            }
            else
            {
                statusBar.Text = "STATUS: Niste se prijavili,onemogucena opcija.";
                statusBar.Foreground = Brushes.Red;
            }
        }

        private void Sacuvaj_Can_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Sacuvaj_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
                if (prijavljen)
                {
                    SaveToTxtEtikete();
                    SaveToTxtTipove();
                    SaveToTxtSpomenike();
                    SaveToTxtSpomenikeNaMapi();
                    statusBar.Text = "Sacuvano je stablo u fajl.";
                    statusBar.Foreground = Brushes.Green;
                }
                else
                {
                    statusBar.Text = "STATUS: Niste se prijavili,onemogucena opcija.";
                    statusBar.Foreground = Brushes.Red;
                }
        }
          

        private void Pomoc_Can_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Pomoc_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (prijavljen == true)
            {
                Pomoc s = new Pomoc("MainWindow");
                s.Show();
                statusBar.Text = "";
            }
            else
            {
                statusBar.Text = "STATUS: Niste se prijavili,onemogucena opcija.";
                statusBar.Foreground = Brushes.Red;
            }
        }

        private void Login_Can_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Login_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
                Login s = new Login();
                s.Show();
                statusBar.Text = "";
                
            
        }
        private void Registracija_Can_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Registracija_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            Registracija s = new Registracija();
            s.Show();
            statusBar.Text = "";


        }

    }

}


    


