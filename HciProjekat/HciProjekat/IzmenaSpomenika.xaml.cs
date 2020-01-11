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
    /// Interaction logic for IzmenaSpomenika.xaml
    /// </summary>
    public partial class IzmenaSpomenika : Window
    {
        Boolean kliknutoDugmeZaIzmenu = false;
        public static int i = 0;
        int q = 0;
        Model1 mTemp = new Model1();
        public static MainWindow main;

        public static ObservableCollection<Model2> Etikete
        {
            get;
            set;
        }

        public IzmenaSpomenika()
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
           

            mTemp.Oznaka = TableExample.selektovaniSpomenik.Oznaka;
            mTemp.Ime = TableExample.selektovaniSpomenik.Ime;
            mTemp.Opis = TableExample.selektovaniSpomenik.Opis;
            mTemp.ArhObradjen = TableExample.selektovaniSpomenik.ArhObradjen;
            mTemp.DatumOtkrivanja = TableExample.selektovaniSpomenik.DatumOtkrivanja;
            mTemp.Era = TableExample.selektovaniSpomenik.Era;
            mTemp.Ikonica = TableExample.selektovaniSpomenik.Ikonica;
            mTemp.Prihod = TableExample.selektovaniSpomenik.Prihod;
            mTemp.PripadaNaseljenom = TableExample.selektovaniSpomenik.PripadaNaseljenom;
            mTemp.PripadaUnesko = TableExample.selektovaniSpomenik.PripadaUnesko;
            mTemp.Tagovani = TableExample.selektovaniSpomenik.Tagovani;
            mTemp.Tip = TableExample.selektovaniSpomenik.Tip;
            mTemp.TuristickiStatus = TableExample.selektovaniSpomenik.TuristickiStatus;
            



            textBoxIme.Text = TableExample.selektovaniSpomenik.Ime;
            textBoxOpis.Text = TableExample.selektovaniSpomenik.Opis;
            textBoxOznaka.Text = TableExample.selektovaniSpomenik.Oznaka;
            textBoxGodisnjiPrihod.Text = TableExample.selektovaniSpomenik.Prihod.ToString();
            textBoxDatumOtkrivanja.Text = TableExample.selektovaniSpomenik.DatumOtkrivanja.ToString();

            textBoxTip.SelectedValue = TableExample.selektovaniSpomenik.Tip;

            comboEra.Text = TableExample.selektovaniSpomenik.Era;
            comboStatus.Text = TableExample.selektovaniSpomenik.TuristickiStatus;
            

            if (TableExample.selektovaniSpomenik.PripadaUnesko == true)
            {
                Pripada_UNESKO.IsChecked = true;
            }
            else
            {
                Pripada_UNESKO.IsChecked = false;
            }

            if (TableExample.selektovaniSpomenik.PripadaNaseljenom == true)
            {
                Pripada_naseljenom_mjestu.IsChecked = true;
            }
            else
            {
                Pripada_naseljenom_mjestu.IsChecked = false;
            }

            if (TableExample.selektovaniSpomenik.ArhObradjen == true)
            {
                Arheoloski_obradjen.IsChecked = true;
            }
            else
            {
                Arheoloski_obradjen.IsChecked = false;
            }

            myImage2.Source = TableExample.selektovaniSpomenik.Ikonica;

            Model1 privremeniSpomenikAkoJeNadjenFalse = new Model1();

            privremeniSpomenikAkoJeNadjenFalse.Ime = textBoxIme.Text;
            privremeniSpomenikAkoJeNadjenFalse.Opis = textBoxOpis.Text;
            privremeniSpomenikAkoJeNadjenFalse.Oznaka = textBoxOznaka.Text;
            privremeniSpomenikAkoJeNadjenFalse.Ikonica = myImage2.Source;

            if (Arheoloski_obradjen.IsChecked == true)
            {
                privremeniSpomenikAkoJeNadjenFalse.ArhObradjen = true;
            }
            else
            {
                privremeniSpomenikAkoJeNadjenFalse.ArhObradjen = false;
            }

            if (Pripada_naseljenom_mjestu.IsChecked == true)
            {
                privremeniSpomenikAkoJeNadjenFalse.PripadaNaseljenom = true;
            }
            else
            {
                privremeniSpomenikAkoJeNadjenFalse.PripadaNaseljenom = false;
            }

            if (Pripada_UNESKO.IsChecked == true)
            {
                privremeniSpomenikAkoJeNadjenFalse.PripadaUnesko = true;
            }
            else
            {
                privremeniSpomenikAkoJeNadjenFalse.PripadaUnesko = false;
            }

            privremeniSpomenikAkoJeNadjenFalse.Era = comboEra.Text;
            privremeniSpomenikAkoJeNadjenFalse.DatumOtkrivanja = Convert.ToDateTime(textBoxDatumOtkrivanja.Text);
            privremeniSpomenikAkoJeNadjenFalse.TuristickiStatus = comboStatus.Text;
            privremeniSpomenikAkoJeNadjenFalse.Prihod = Convert.ToSingle(textBoxGodisnjiPrihod.Text);
            privremeniSpomenikAkoJeNadjenFalse.Tagovani = comboEra.Text;
            privremeniSpomenikAkoJeNadjenFalse.Tip = textBoxTip.Text;

            Boolean nadjen = false;

            // brisanje iz liste tipa da bi ga mogao dodati u onaj koji uzmem
            foreach (Model3 m3 in MainWindow.TipoviTree) {
                if (textBoxTip.SelectedValue.Equals(m3.Oznaka)) {
                    foreach (Model1 m1 in m3.spomeniciUnutarTipova) {
                        if (m1.Oznaka == textBoxOznaka.Text) {
                            m3.spomeniciUnutarTipova.Remove(m1);
                            nadjen = true;
                            break;
                        }
                    }
                    if (nadjen == true) {
                        break;
                    }
                }
            }

        }


        private void click_izmeni_spomenik(object sender, RoutedEventArgs e)
        {
            kliknutoDugmeZaIzmenu = true;
            int l = 0;
            int s1 = 0;
            int brojacQ = 0;

            if (textBoxDatumOtkrivanja.SelectedDate != null)
            {
                // spomenik.DatumOtkrivanja = textBoxDatumOtkrivanja.SelectedDate.Value.Date;


            }
            else
            {
                validacijaDatumOtkrivanja.Text = "Molimo unesite datum otkrivanja.";
                validacijaDatumOtkrivanja.Foreground = Brushes.Red;
                statusSpomenikIzmena.Text = "";

                if (textBoxOznaka.Text == "")
                {
                    validacijaOznaka.Text = "Molimo unesite oznaku spomenika.";
                    validacijaOznaka.Foreground = Brushes.Red;
                    statusSpomenikIzmena.Text = "";
                }
                else
                {
                    validacijaOznaka.Text = "";
                }

                if (textBoxIme.Text == "")
                {
                    validacijaIme.Text = "Molimo unesite ime spomenika.";
                    validacijaIme.Foreground = Brushes.Red;
                    statusSpomenikIzmena.Text = "";
                }
                else
                {
                    validacijaIme.Text = "";
                }

                if (textBoxOpis.Text == "")
                {
                    validacijaOpis.Text = "Molimo unesite opis spomenika.";
                    validacijaOpis.Foreground = Brushes.Red;
                    statusSpomenikIzmena.Text = "";
                }
                else
                {
                    validacijaOpis.Text = "";
                }

                if (textBoxTip.Text == "")
                {
                    validacijaTip.Text = "Molimo unesite tip spomenika.";
                    validacijaTip.Foreground = Brushes.Red;
                    statusSpomenikIzmena.Text = "";
                }
                else
                {
                    validacijaTip.Text = "";
                }

                if (textBoxGodisnjiPrihod.Text == "")
                {
                    validacijaGodisnjiPrihod.Text = "Molimo unesite prihod spomenika.";
                    validacijaGodisnjiPrihod.Foreground = Brushes.Red;
                    statusSpomenikIzmena.Text = "";
                }
                else
                {
                    validacijaGodisnjiPrihod.Text = "";
                }

                if (comboEra.Text == "")
                {
                    validacijaEra.Text = "Molimo izaberite eru spomenika.";
                    validacijaEra.Foreground = Brushes.Red;
                    statusSpomenikIzmena.Text = "";
                }
                else
                {
                    validacijaEra.Text = "";
                }

                if (comboStatus.Text == "")
                {
                    validacijaTuristickiStatus.Text = "Molimo izaberite status spomenika.";
                    validacijaTuristickiStatus.Foreground = Brushes.Red;
                    statusSpomenikIzmena.Text = "";
                }
                else
                {
                    validacijaTuristickiStatus.Text = "";
                }

                

                if (myImage2.Source == null)
                {
                    validacijaSlika.Text = "Bice izabrana slika tipa.";
                    validacijaSlika.Foreground = Brushes.CornflowerBlue;
                    statusSpomenikIzmena.Text = "";
                }
                else
                {
                    validacijaSlika.Text = "";
                }


            }
            if (myImage2.Source != null)
            {
                //spomenik.Ikonica = myImage2.Source;
            }
            else
            {





                validacijaSlika.Text = "Bice izabrana slika tipa.";
                validacijaSlika.Foreground = Brushes.CornflowerBlue;
                statusSpomenikIzmena.Text = "";
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

            this.DataContext = this;


            if (textBoxOznaka.Text == "")
            {
                validacijaOznaka.Text = "Molimo unesite oznaku spomenika.";
                validacijaOznaka.Foreground = Brushes.Red;
                statusSpomenikIzmena.Text = "";
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
                statusSpomenikIzmena.Text = "";
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
                statusSpomenikIzmena.Text = "";
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
                statusSpomenikIzmena.Text = "";
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
                statusSpomenikIzmena.Text = "";
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
                statusSpomenikIzmena.Text = "";
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
                statusSpomenikIzmena.Text = "";
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
                if (TableExample.Spomenici != null)
                {
                    foreach (Model1 et in TableExample.Spomenici)
                    {
                        if (brojacQ != TableExample.selektovaniIndex) {
                            if (et.Oznaka == textBoxOznaka.Text)
                            {
                                vecPostojiOznaka = true;
                                validacijaOznaka.Text = "Molimo unesite neku drugu oznaku.";
                                validacijaOznaka.Foreground = Brushes.Red;
                                statusSpomenikIzmena.Text = "";

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
                        brojacQ++;
                    }
                }


                if (vecPostojiOznaka == false)
                {
                    //izmenaNaMapiSpomenika

                    if (MainWindow.naMapi != null)
                    {
                        foreach (Model1 m1 in MainWindow.naMapi)
                        {
                            if (m1.Oznaka == TableExample.selektovaniSpomenik.Oznaka)
                            {
                                m1.Ikonica = myImage2.Source;
                                m1.Oznaka = textBoxOznaka.Text;
                                m1.Ime = textBoxIme.Text;
                                break;
                                //ostale ne trebaju jer se ne vide
                            }
                        }
                    }


                    //menjanje pozicije spomenika u odnosu na tip
                    foreach (Model3 m3 in MainWindow.TipoviTree)
                    {
                        if (textBoxTip.Text == m3.Oznaka)
                        {
                            Model1 m = new Model1();
                            m.Ime = textBoxIme.Text;
                            m.Opis = textBoxOpis.Text;
                            m.Oznaka = textBoxOznaka.Text;
                            m.Ikonica = myImage2.Source;
                            if (Arheoloski_obradjen.IsChecked == true)
                            {
                                m.ArhObradjen = true;
                            }
                            else
                            {
                                m.ArhObradjen = false;
                            }

                            if (Pripada_naseljenom_mjestu.IsChecked == true)
                            {
                                m.PripadaNaseljenom = true;
                            }
                            else
                            {
                                m.PripadaNaseljenom = false;
                            }

                            if (Pripada_UNESKO.IsChecked == true)
                            {
                                m.PripadaUnesko = true;
                            }
                            else
                            {
                                m.PripadaUnesko = false;
                            }

                            m.Era = comboEra.Text;
                            m.DatumOtkrivanja = Convert.ToDateTime(textBoxDatumOtkrivanja.Text);
                            m.TuristickiStatus = comboStatus.Text;
                            m.Prihod = Convert.ToSingle(textBoxGodisnjiPrihod.Text);
                            m.Tagovani = comboEra.Text;
                            m.Tip = textBoxTip.Text;
                            foreach (Model2 element in etiketaSelect.SelectedItems)
                            {
                                m.Etikete.Add(element.Oznaka);
                            }

                            m3.spomeniciUnutarTipova.Add(m);
                            break;
                        }
                    }

                    foreach (Model1 m in TableExample.Spomenici)
                    {
                        if (q == TableExample.selektovaniIndex)
                        {

                            m.Ime = textBoxIme.Text;
                            m.Opis = textBoxOpis.Text;
                            m.Oznaka = textBoxOznaka.Text;
                            m.Ikonica = myImage2.Source;

                            if (Arheoloski_obradjen.IsChecked == true)
                            {
                                m.ArhObradjen = true;
                            }
                            else
                            {
                                m.ArhObradjen = false;
                            }

                            if (Pripada_naseljenom_mjestu.IsChecked == true)
                            {
                                m.PripadaNaseljenom = true;
                            }
                            else
                            {
                                m.PripadaNaseljenom = false;
                            }

                            if (Pripada_UNESKO.IsChecked == true)
                            {
                                m.PripadaUnesko = true;
                            }
                            else
                            {
                                m.PripadaUnesko = false;
                            }

                            m.Era = comboEra.Text;
                            m.DatumOtkrivanja = Convert.ToDateTime(textBoxDatumOtkrivanja.Text);
                            m.TuristickiStatus = comboStatus.Text;
                            m.Prihod = Convert.ToSingle(textBoxGodisnjiPrihod.Text);
                            m.Tagovani = comboEra.Text;
                            m.Tip = textBoxTip.Text;
                            foreach (Model2 element in etiketaSelect.SelectedItems)
                            {
                                m.Etikete.Add(element.Oznaka);
                            }

                            break;
                        }
                        q++;
                    }

                    MainWindow.readFromFileSpomenike();


                    if (TableExample.selektovaniIndex < MainWindow.brojacKolikoImaFajluSpomenik)
                    {
                        foreach (Model1 m in MainWindow.Spomenicici)
                        {
                            if (TableExample.selektovaniIndex == l)
                            {
                                m.Ime = textBoxIme.Text;
                                m.Opis = textBoxOpis.Text;
                                m.Oznaka = textBoxOznaka.Text;
                                m.Ikonica = myImage2.Source;

                                if (Arheoloski_obradjen.IsChecked == true)
                                {
                                    m.ArhObradjen = true;
                                }
                                else
                                {
                                    m.ArhObradjen = false;
                                }

                                if (Pripada_naseljenom_mjestu.IsChecked == true)
                                {
                                    m.PripadaNaseljenom = true;
                                }
                                else
                                {
                                    m.PripadaNaseljenom = false;
                                }

                                if (Pripada_UNESKO.IsChecked == true)
                                {
                                    m.PripadaUnesko = true;
                                }
                                else
                                {
                                    m.PripadaUnesko = false;
                                }

                                m.Era = comboEra.Text;
                                m.DatumOtkrivanja = Convert.ToDateTime(textBoxDatumOtkrivanja.Text);
                                m.TuristickiStatus = comboStatus.Text;
                                m.Prihod = Convert.ToSingle(textBoxGodisnjiPrihod.Text);
                                m.Tagovani = comboEra.Text;
                                m.Tip = textBoxTip.Text;
                                foreach (Model2 element in etiketaSelect.SelectedItems)
                                {
                                    m.Etikete.Add(element.Oznaka);
                                }

                                break;
                            }
                            l++;
                        }

                        MainWindow.SaveToTxtSpomenikeTemp();
                    }
                    else
                    {
                        foreach (Model1 m in MainWindow.Spomenici1)
                        {
                            if (TableExample.selektovaniIndex == (s1 + MainWindow.brojacKolikoImaFajluSpomenik))
                            {
                                m.Ime = textBoxIme.Text;
                                m.Opis = textBoxOpis.Text;
                                m.Oznaka = textBoxOznaka.Text;
                                m.Ikonica = myImage2.Source;

                                if (Arheoloski_obradjen.IsChecked == true)
                                {
                                    m.ArhObradjen = true;
                                }
                                else
                                {
                                    m.ArhObradjen = false;
                                }

                                if (Pripada_naseljenom_mjestu.IsChecked == true)
                                {
                                    m.PripadaNaseljenom = true;
                                }
                                else
                                {
                                    m.PripadaNaseljenom = false;
                                }

                                if (Pripada_UNESKO.IsChecked == true)
                                {
                                    m.PripadaUnesko = true;
                                }
                                else
                                {
                                    m.PripadaUnesko = false;
                                }

                                m.Era = comboEra.Text;
                                m.DatumOtkrivanja = Convert.ToDateTime(textBoxDatumOtkrivanja.Text);
                                m.TuristickiStatus = comboStatus.Text;
                                m.Prihod = Convert.ToSingle(textBoxGodisnjiPrihod.Text);
                                
                                m.Tip = textBoxTip.Text;
                                foreach (Model2 element in etiketaSelect.SelectedItems)
                                {
                                    m.Etikete.Add(element.Oznaka);
                                }

                                break;
                            }
                            s1++;
                        }
                    }

                    // MessageBox.Show("Izmenili ste zeljeni spomenik.");
                    main.statusBar.Text = "Izmenjen spomenik na poziciji " + TableExample.selektovaniIndex + " .";
                    main.statusBar.Foreground = Brushes.Green;

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

            if (kliknutoDugmeZaIzmenu == false) {

            }

        }

        
    
        private void click_browse(object sender, RoutedEventArgs e)
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

        private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (kliknutoDugmeZaIzmenu == false) {
                
                foreach (Model3 m3 in MainWindow.TipoviTree)
                {
                    if (TableExample.selektovaniSpomenik.Tip.Equals(m3.Oznaka))
                    {
                        m3.spomeniciUnutarTipova.Add(mTemp);
                        break;
                    }
                }
            }
        }
    }
}
