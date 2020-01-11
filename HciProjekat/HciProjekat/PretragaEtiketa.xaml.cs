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
    /// Interaction logic for PretragaEtiketa.xaml
    /// </summary>
    public partial class PretragaEtiketa : Window
    {

        public static string bojica;
        public static byte red;
        public static byte green;
        public static byte blue;
       
        public static String boja;

        public static Model2 etiketa;
        
        public PretragaEtiketa()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            etiketa = new Model2();

            if (textBoxBoja.SelectedColorText != "" && textBoxOznaka.Text != null)
            {
                etiketa.Boja = boja;
            }
            else
            {
                etiketa.Boja = "";
            }
            if (textBoxOpis.Text != "" && textBoxOpis.Text != null)
            {
                etiketa.Opis = textBoxOpis.Text;
            }
            else
            {
                etiketa.Opis = "";
            }
            if (textBoxOznaka.Text != "" && textBoxOznaka.Text != null)
            {
                etiketa.Oznaka = textBoxOznaka.Text;
            }
            else
            {
                etiketa.Oznaka = "";
            }
            


            PrikazEtiketa s = new PrikazEtiketa();
            s.Show();
            PrikazEtiketa.pretraga();
            this.Close();
        }
        private void cp_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (textBoxBoja.SelectedColor.HasValue)
            {
                Color C = textBoxBoja.SelectedColor.Value;
               // sveBoje.Add(textBoxBoja.SelectedColor.Value);


                red = new byte();

                red = C.R;
                green = C.G;
                blue = C.B;

                long colorVal = Convert.ToInt64(C.R * (Math.Pow(256, 0)) + C.G * (Math.Pow(256, 1)) + C.B * (Math.Pow(256, 2)));
                boja = "#" + C.R + C.G + C.B;

            }

        }
    }
}
