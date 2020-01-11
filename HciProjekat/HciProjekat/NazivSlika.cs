using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;

namespace PrimerCas4.Table
{
    public class NazivSlika : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string _ime;
        private ImageSource slika;

        public string Oznaka
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public ImageSource Slika
        {
            get
            {
                return slika;
            }
            set
            {
                if (value != slika)
                {
                    slika = value;
                    OnPropertyChanged("Slika");
                }
            }
        }


    }
}
