using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace PrimerCas4.Table
{
    public class Model3 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string ime;
        private string oznaka;
        private string opis;
        private ImageSource mapa;

        public static ObservableCollection<String> _sadrzaniSpomenici;
        public ObservableCollection<Model1> spomeniciUnutarTipova;

        public Model3() {
            spomeniciUnutarTipova = new ObservableCollection<Model1>();
        }

        public ObservableCollection<Model1> SpomeniciUnutarTipova
        {
            get
            {
                return spomeniciUnutarTipova;
            }
            set
            {
                if (value != spomeniciUnutarTipova)
                {
                    spomeniciUnutarTipova = value;
                    OnPropertyChanged("SpomeniciUnutarTipova");
                }
            }
        }


        public ObservableCollection<String> SadrzaniSpomenici
        {
            get
            {
                return _sadrzaniSpomenici;
            }
            set
            {
                if (value != _sadrzaniSpomenici)
                {
                    _sadrzaniSpomenici = value;
                    OnPropertyChanged("SadrzaneVrste");
                }
            }
        }


        public string Oznaka
        {
            get
            {
                return oznaka;
            }
            set
            {
                if (value != oznaka)
                {
                    oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

       


        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        public string Opis
        {
            get
            {
                return opis;
            }
            set
            {
                if (value != opis)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public ImageSource Ikonica
        {
            get
            {
                return mapa;
            }
            set
            {
                if (value != mapa)
                {
                    mapa = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

    }
}
