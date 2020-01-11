using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HciProjekat
{
    /// <summary>
    /// Interaction logic for Pomoc.xaml
    /// </summary>
    public partial class Pomoc : Window
    {
        public Pomoc(String kljuc)
        {
            InitializeComponent();
            String path = String.Format(@"C:\Users\Nemanja\Desktop\HCI_PROJEKAT\HciProjekat\HciProjekat\HTML\{0}.html", kljuc); // DODAJ PUTANJU DO STRANICE KADA JE NAPRAVIS
            if (!File.Exists(path))
            {
                kljuc = "error";
            }
            Uri uri = new Uri(String.Format(@"C:\Users\Nemanja\Desktop\HCI_PROJEKAT\HciProjekat\HciProjekat\HTML\{0}.html", kljuc));
            webPomoc.Navigate(uri);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
